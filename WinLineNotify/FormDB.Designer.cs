namespace WinLineNotify
{
    partial class FormDB
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.StartdateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.txtCountTimer = new System.Windows.Forms.TextBox();
            this.btnAutoTrans = new System.Windows.Forms.Button();
            this.labTransStatu = new System.Windows.Forms.Label();
            this.EnddateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnStop = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMTrans = new System.Windows.Forms.Button();
            this.timerPre = new System.Windows.Forms.Timer(this.components);
            this.txtResult = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gold;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.StartdateTimePicker);
            this.panel1.Controls.Add(this.txtCountTimer);
            this.panel1.Controls.Add(this.btnAutoTrans);
            this.panel1.Controls.Add(this.labTransStatu);
            this.panel1.Controls.Add(this.EnddateTimePicker);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnMTrans);
            this.panel1.Location = new System.Drawing.Point(1, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(483, 94);
            this.panel1.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 14.25F);
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(440, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 19);
            this.label7.TabIndex = 20;
            this.label7.Text = "秒";
            // 
            // StartdateTimePicker
            // 
            this.StartdateTimePicker.Location = new System.Drawing.Point(108, 6);
            this.StartdateTimePicker.Name = "StartdateTimePicker";
            this.StartdateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.StartdateTimePicker.TabIndex = 9;
            // 
            // txtCountTimer
            // 
            this.txtCountTimer.Location = new System.Drawing.Point(383, 59);
            this.txtCountTimer.Name = "txtCountTimer";
            this.txtCountTimer.Size = new System.Drawing.Size(51, 22);
            this.txtCountTimer.TabIndex = 19;
            // 
            // btnAutoTrans
            // 
            this.btnAutoTrans.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnAutoTrans.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAutoTrans.Location = new System.Drawing.Point(319, 5);
            this.btnAutoTrans.Name = "btnAutoTrans";
            this.btnAutoTrans.Size = new System.Drawing.Size(75, 23);
            this.btnAutoTrans.TabIndex = 14;
            this.btnAutoTrans.Text = "定時轉檔";
            this.btnAutoTrans.UseVisualStyleBackColor = false;
            this.btnAutoTrans.Click += new System.EventHandler(this.btnAutoTrans_Click);
            // 
            // labTransStatu
            // 
            this.labTransStatu.AutoSize = true;
            this.labTransStatu.Font = new System.Drawing.Font("新細明體", 14.25F);
            this.labTransStatu.ForeColor = System.Drawing.Color.Blue;
            this.labTransStatu.Location = new System.Drawing.Point(254, 62);
            this.labTransStatu.Name = "labTransStatu";
            this.labTransStatu.Size = new System.Drawing.Size(123, 19);
            this.labTransStatu.TabIndex = 18;
            this.labTransStatu.Text = "目前轉檔狀態";
            // 
            // EnddateTimePicker
            // 
            this.EnddateTimePicker.Location = new System.Drawing.Point(108, 34);
            this.EnddateTimePicker.Name = "EnddateTimePicker";
            this.EnddateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.EnddateTimePicker.TabIndex = 10;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Gold;
            this.btnStop.ForeColor = System.Drawing.Color.DimGray;
            this.btnStop.Location = new System.Drawing.Point(319, 34);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 17;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(7, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "開始日期";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(7, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "結束日期";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkRed;
            this.btnExit.ForeColor = System.Drawing.Color.Transparent;
            this.btnExit.Location = new System.Drawing.Point(400, 34);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "離開";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMTrans
            // 
            this.btnMTrans.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnMTrans.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMTrans.Location = new System.Drawing.Point(393, 6);
            this.btnMTrans.Name = "btnMTrans";
            this.btnMTrans.Size = new System.Drawing.Size(75, 23);
            this.btnMTrans.TabIndex = 15;
            this.btnMTrans.Text = "手動轉檔";
            this.btnMTrans.UseVisualStyleBackColor = false;
            this.btnMTrans.Click += new System.EventHandler(this.btnMTrans_Click);
            // 
            // timerPre
            // 
            this.timerPre.Interval = 300;
            this.timerPre.Tick += new System.EventHandler(this.timerPre_Tick);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(1, 118);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(483, 270);
            this.txtResult.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(80, 20);
            this.toolStripMenuItem1.Text = "TCP/IP訊息";
            this.toolStripMenuItem1.Visible = false;
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Enabled = false;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(79, 20);
            this.toolStripMenuItem2.Text = "資料庫訊息";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(115, 20);
            this.toolStripMenuItem3.Text = "機台通知訊息維護";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(86, 20);
            this.toolStripMenuItem4.Text = "訊息log查詢";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // FormDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 411);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(500, 450);
            this.Name = "FormDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "line通知訊息發送作業";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAutoTrans;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMTrans;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker StartdateTimePicker;
        private System.Windows.Forms.TextBox txtCountTimer;
        private System.Windows.Forms.Label labTransStatu;
        private System.Windows.Forms.DateTimePicker EnddateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timerPre;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
    }
}

