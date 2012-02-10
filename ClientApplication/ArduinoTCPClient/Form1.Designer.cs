namespace ArduinoTCPClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bOpen = new System.Windows.Forms.Button();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.bStop = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.cbLogToFile = new System.Windows.Forms.CheckBox();
            this.bSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxSend = new System.Windows.Forms.TextBox();
            this.cbBaud = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbAutoscroll = new System.Windows.Forms.CheckBox();
            this.buttonRawSend = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bOpen
            // 
            this.bOpen.Location = new System.Drawing.Point(102, 19);
            this.bOpen.Name = "bOpen";
            this.bOpen.Size = new System.Drawing.Size(67, 21);
            this.bOpen.TabIndex = 0;
            this.bOpen.Text = "Open";
            this.bOpen.UseVisualStyleBackColor = true;
            this.bOpen.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbInfo
            // 
            this.tbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInfo.Location = new System.Drawing.Point(344, 3);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbInfo.Size = new System.Drawing.Size(538, 193);
            this.tbInfo.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(8, 19);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(75, 23);
            this.bStart.TabIndex = 3;
            this.bStart.Text = "START";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(170, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(0, 199);
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.Size = new System.Drawing.Size(891, 400);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.VirtualMode = true;
            this.listView1.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.listView1_RetrieveVirtualItem);
            // 
            // ColumnHeader
            // 
            this.ColumnHeader.Text = "";
            this.ColumnHeader.Width = 528;
            // 
            // bStop
            // 
            this.bStop.Location = new System.Drawing.Point(89, 19);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(75, 23);
            this.bStop.TabIndex = 6;
            this.bStop.Text = "STOP";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(170, 19);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(73, 23);
            this.bClear.TabIndex = 7;
            this.bClear.Text = "CLEAR";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // cbLogToFile
            // 
            this.cbLogToFile.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbLogToFile.Checked = true;
            this.cbLogToFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLogToFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbLogToFile.Location = new System.Drawing.Point(89, 48);
            this.cbLogToFile.Name = "cbLogToFile";
            this.cbLogToFile.Size = new System.Drawing.Size(75, 23);
            this.cbLogToFile.TabIndex = 8;
            this.cbLogToFile.Text = "Log to file";
            this.cbLogToFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbLogToFile.UseVisualStyleBackColor = true;
            this.cbLogToFile.CheckedChanged += new System.EventHandler(this.cbLogToFile_CheckedChanged);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(249, 19);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 10;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.tbInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(891, 199);
            this.panel1.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonRawSend);
            this.groupBox1.Controls.Add(this.buttonSend);
            this.groupBox1.Controls.Add(this.textBoxSend);
            this.groupBox1.Controls.Add(this.cbBaud);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.bOpen);
            this.groupBox1.Location = new System.Drawing.Point(3, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 76);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Remote";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(286, 45);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(43, 21);
            this.buttonSend.TabIndex = 5;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxSend
            // 
            this.textBoxSend.Location = new System.Drawing.Point(6, 46);
            this.textBoxSend.Name = "textBoxSend";
            this.textBoxSend.Size = new System.Drawing.Size(274, 20);
            this.textBoxSend.TabIndex = 4;
            // 
            // cbBaud
            // 
            this.cbBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaud.FormattingEnabled = true;
            this.cbBaud.Items.AddRange(new object[] {
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200"});
            this.cbBaud.Location = new System.Drawing.Point(6, 19);
            this.cbBaud.Name = "cbBaud";
            this.cbBaud.Size = new System.Drawing.Size(90, 21);
            this.cbBaud.TabIndex = 2;
            this.cbBaud.SelectedIndexChanged += new System.EventHandler(this.cbBaud_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(175, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 21);
            this.button1.TabIndex = 3;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbAutoscroll);
            this.groupBox2.Controls.Add(this.bStart);
            this.groupBox2.Controls.Add(this.bClear);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbLogToFile);
            this.groupBox2.Controls.Add(this.bSave);
            this.groupBox2.Controls.Add(this.bStop);
            this.groupBox2.Location = new System.Drawing.Point(2, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(336, 80);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Local";
            // 
            // cbAutoscroll
            // 
            this.cbAutoscroll.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbAutoscroll.Checked = true;
            this.cbAutoscroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoscroll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbAutoscroll.Location = new System.Drawing.Point(8, 48);
            this.cbAutoscroll.Name = "cbAutoscroll";
            this.cbAutoscroll.Size = new System.Drawing.Size(75, 24);
            this.cbAutoscroll.TabIndex = 11;
            this.cbAutoscroll.Text = "Autoscroll";
            this.cbAutoscroll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbAutoscroll.UseVisualStyleBackColor = true;
            // 
            // buttonRawSend
            // 
            this.buttonRawSend.Location = new System.Drawing.Point(248, 18);
            this.buttonRawSend.Name = "buttonRawSend";
            this.buttonRawSend.Size = new System.Drawing.Size(81, 21);
            this.buttonRawSend.TabIndex = 6;
            this.buttonRawSend.Text = "Raw Send";
            this.buttonRawSend.UseVisualStyleBackColor = true;
            this.buttonRawSend.Click += new System.EventHandler(this.buttonRawSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 599);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bOpen;
        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.Timer timer1;

        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ColumnHeader;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.CheckBox cbLogToFile;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbBaud;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbAutoscroll;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxSend;
        private System.Windows.Forms.Button buttonRawSend;
    }
}

