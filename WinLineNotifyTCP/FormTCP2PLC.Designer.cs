namespace WinLineNotifyTCP
{
    partial class FormTCP2PLC
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.建立資料庫ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDisConn = new System.Windows.Forms.TextBox();
            this.btnDisconn = new System.Windows.Forms.Button();
            this.lbxMsg = new System.Windows.Forms.ListBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboIP = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.建立資料庫ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(80, 20);
            this.toolStripMenuItem1.Text = "TCP/IP訊息";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(91, 20);
            this.toolStripMenuItem3.Text = "機台訊息維護";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(86, 20);
            this.toolStripMenuItem4.Text = "訊息log查詢";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // 建立資料庫ToolStripMenuItem
            // 
            this.建立資料庫ToolStripMenuItem.Name = "建立資料庫ToolStripMenuItem";
            this.建立資料庫ToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.建立資料庫ToolStripMenuItem.Text = "建立資料庫";
            this.建立資料庫ToolStripMenuItem.Visible = false;
            this.建立資料庫ToolStripMenuItem.Click += new System.EventHandler(this.建立資料庫ToolStripMenuItem_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(38, 172);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 12;
            this.btnStart.Text = "btnStart";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(83, 71);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 22);
            this.txtPort.TabIndex = 14;
            this.txtPort.Text = "2455";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(119, 172);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 15;
            this.btnStop.Text = "btnStop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "PORT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "CONNID";
            // 
            // txtDisConn
            // 
            this.txtDisConn.Location = new System.Drawing.Point(83, 112);
            this.txtDisConn.Name = "txtDisConn";
            this.txtDisConn.Size = new System.Drawing.Size(100, 22);
            this.txtDisConn.TabIndex = 20;
            // 
            // btnDisconn
            // 
            this.btnDisconn.Location = new System.Drawing.Point(189, 112);
            this.btnDisconn.Name = "btnDisconn";
            this.btnDisconn.Size = new System.Drawing.Size(75, 23);
            this.btnDisconn.TabIndex = 21;
            this.btnDisconn.Text = "Dis";
            this.btnDisconn.UseVisualStyleBackColor = true;
            this.btnDisconn.Click += new System.EventHandler(this.btnDisconn_Click);
            // 
            // lbxMsg
            // 
            this.lbxMsg.FormattingEnabled = true;
            this.lbxMsg.ItemHeight = 12;
            this.lbxMsg.Location = new System.Drawing.Point(26, 236);
            this.lbxMsg.Name = "lbxMsg";
            this.lbxMsg.Size = new System.Drawing.Size(430, 148);
            this.lbxMsg.TabIndex = 22;
            // 
            // txtKey
            // 
            this.txtKey.Enabled = false;
            this.txtKey.Location = new System.Drawing.Point(83, 144);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(284, 22);
            this.txtKey.TabIndex = 23;
            this.txtKey.Text = "32uSLzsNSvN4VFdZhFCCjZ6xSsh1XFekZeiT9WXhdZn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 12);
            this.label4.TabIndex = 24;
            this.label4.Text = "KEY";
            // 
            // cboIP
            // 
            this.cboIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIP.FormattingEnabled = true;
            this.cboIP.Location = new System.Drawing.Point(83, 43);
            this.cboIP.Name = "cboIP";
            this.cboIP.Size = new System.Drawing.Size(121, 20);
            this.cboIP.TabIndex = 25;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(296, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormTCP2PLC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 411);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cboIP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.lbxMsg);
            this.Controls.Add(this.btnDisconn);
            this.Controls.Add(this.txtDisConn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.menuStrip1);
            this.MaximumSize = new System.Drawing.Size(500, 450);
            this.Name = "FormTCP2PLC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTCP2PLC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTCP2PLC_FormClosing);
            this.Load += new System.EventHandler(this.FormTCP2PLC_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDisConn;
        private System.Windows.Forms.Button btnDisconn;
        private System.Windows.Forms.ListBox lbxMsg;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboIP;
        private System.Windows.Forms.ToolStripMenuItem 建立資料庫ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}