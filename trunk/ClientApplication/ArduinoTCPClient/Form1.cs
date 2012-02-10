using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using System.Threading;

namespace ArduinoTCPClient
{
    public partial class Form1 : Form
    {
        
        const string IP = "192.168.0.133";


        const int PORT =80;
        const string ERROR = "SOCKET ERROR";
        StreamWriter logfile = 	null;


        
        int _counter=0;
        List<ListViewItem> _data = new List<ListViewItem>();
        ListViewItem _nullitem;
        const int MAXTAILSIZE = 10000;
        string  _tail=null;

        public Form1()
        {
            InitializeComponent();
            listView1.VirtualListSize = 0;
            _nullitem = new ListViewItem();
            _nullitem.Text = "NULL";
            ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem(); 
            _nullitem.SubItems.Add(lvsi); 		






        }



        private void Form1_Load(object sender, EventArgs e)
        {
            cbBaud.Text = "9600";
            CheckLogFile();

        }


        #region SEND COMMAND

        void a_Completed(object sender, SocketAsyncEventArgs e)
        {
            completed = true;
        }


        const long SEC3 = 10000*1000*3;

        const int SENDBUFSIZE=20;
        const int RECVDBUFSIZE=2048;
        ASCIIEncoding  encoding=new System.Text.ASCIIEncoding();
        byte[] recv=new byte[RECVDBUFSIZE];
        byte[] send = new byte[SENDBUFSIZE];
        bool completed;
        void Command(string cmd)
        {
            Socket server =null;
            try
            {
                IPEndPoint ipep =     new IPEndPoint(IPAddress.Parse(IP), PORT);
                server = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
                server.Connect(ipep);

                byte[] data = encoding.GetBytes(cmd);
                //for(int i=0;i<SENDBUFSIZE;i++) send[i] = 32;
                Array.Clear(send,0,SENDBUFSIZE);
                Array.Copy(data,send,data.Length>SENDBUFSIZE ? SENDBUFSIZE : data.Length);

                server.Send(send);

                Array.Clear(recv,0,RECVDBUFSIZE);
                //server.Receive(recv);
                SocketAsyncEventArgs a = new SocketAsyncEventArgs();
                a.SetBuffer(recv,0,RECVDBUFSIZE);
                a.Completed += new EventHandler<SocketAsyncEventArgs>(a_Completed);
                completed = false;
                
                a.SocketFlags = SocketFlags.None;
                

                server.ReceiveAsync(a);


                long t = DateTime.Now.Ticks;
                
                while (DateTime.Now.Ticks-t<SEC3)
                {
                    Thread.Sleep(1);
                    if (completed) break; 
                    
                }

                if (!completed) throw new Exception("Timeout");
                if (a.BytesTransferred!=0)
                {
                    string str = encoding.GetString(recv, 0, recv.Length);
                    ProcessString(str);
                }

                server.Close();
            }
            catch
            {

                InsertItem(ERROR);
                if (server!=null) server.Close();
            }

        }

        #endregion


        void InsertItem(string s)
        {
            if (string.IsNullOrEmpty(s)) return;

            ListViewItem lvi = new ListViewItem(); 	
            lvi.Text = s;
            
            ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem(); 
            lvi.SubItems.Add(lvsi); 			
            _data.Add(lvi);

            listView1.VirtualListSize = _data.Count;   
            listView1.Update();

            if (cbAutoscroll.Checked)
                listView1.EnsureVisible(listView1.VirtualListSize-1);
        
        }


        char[] SPLIT = new char[]{'\n'};
        char[] TRIM = new char[]{'\n','\r',' ','\t','\0'};
        char[] TRIM0 = new char[]{'\0'};

        void ProcessString(string str)
        {
            str = str.Trim(TRIM0);

            if (logfile!=null)
            {
                logfile.Write(str);
                logfile.Flush();
            }

            if (_tail!=null)
            {
                str = _tail+str;
                _tail = null;
            }

            if (!str.EndsWith("\n"))
            {
                int n = str.LastIndexOf("\n");
                if (n==-1)
                {   _tail = str;
                    return;
                }

                _tail = str.Substring(n+1);
                str = n==0 ? string.Empty : str.Substring(0,n);


            }

            string[] split = str.Split(SPLIT);
            foreach(string s in split)
                InsertItem(s.Trim(TRIM));


            tbInfo.Text = _tail==null ? string.Empty : _tail;

        
        }


        void Clear()
        {
            _data.Clear();
            _counter =0;
            timer1.Stop();
            listView1.VirtualListSize=0;
            tbInfo.Text = string.Empty;
            Refresh();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Command("START "+cbBaud.Text);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text =  (_counter++).ToString();
            Command("GET");
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Clear();
            Command("CLEAR");
            timer1.Start();
        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if ((e==null) || (e.ItemIndex>=_data.Count) || (e.ItemIndex<0) || (_data==null)) 
            {   e.Item = _nullitem;
                return;
            }

            e.Item = _data[e.ItemIndex];

        }

        private void bClear_Click(object sender, EventArgs e)
        {
            _data.Clear();
            listView1.VirtualListSize=0;
            listView1.Refresh();
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog()!=DialogResult.OK) return;

            StreamWriter outfile = 	new StreamWriter(ofd.FileName);
            foreach(ListViewItem i in _data)
                outfile.WriteLine(i.Text);
            outfile.Close();

        }

        private void cbBaud_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void cbLogToFile_CheckedChanged(object sender, EventArgs e)
        {
            CheckLogFile();
        }


        string GetLogFileName()
        {
            DateTime t = DateTime.Now;
            return string.Format("LOG_{0:yyMMdd_HHmmss}.txt",t);
        
        }


        void CheckLogFile()
        {
            if (cbLogToFile.Checked) 
            {
                if (logfile ==	null)
                {
                    logfile = new StreamWriter(GetLogFileName());
                }
            
            } else
            {
                if (logfile!=null)
                {
                    logfile.Close();
                    logfile = null;
                }
            }
        
        
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Command("STOP");
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            Command("PUT "+textBoxSend.Text+"\r\n");
        }

        private void buttonRawSend_Click(object sender, EventArgs e)
        {
            Command(textBoxSend.Text);
        }



    }
}
