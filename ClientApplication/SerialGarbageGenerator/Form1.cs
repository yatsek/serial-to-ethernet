using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace SerialGarbageGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SerialPort _com;
        Random _r = new Random();


        private void button1_Click(object sender, EventArgs e)
        {
            _com = new SerialPort("COM6",9600);
            _com.Open();
            timer1.Start();
            button1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {/*
            string s=string.Empty;

            int N = _r.Next(300);
            for(int i=0;i<N;i++)
                s+=(char)(32+_r.Next(100));

            
            _com.Write(s);
           
          */ 

            _com.Write("= 0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 =\n");
        }
    }
}
