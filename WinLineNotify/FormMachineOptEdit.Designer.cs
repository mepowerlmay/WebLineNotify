namespace WinLineNotify
{
    partial class FormMachineOptEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtMachineNo = new System.Windows.Forms.TextBox();
            this.txtAlertNo = new System.Windows.Forms.TextBox();
            this.txtAlertName = new System.Windows.Forms.TextBox();
            this.labTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F);
            this.label1.Location = new System.Drawing.Point(50, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "機台代碼";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 12F);
            this.label2.Location = new System.Drawing.Point(50, 133);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "異常項目代碼";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 12F);
            this.label3.Location = new System.Drawing.Point(50, 187);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "異常項目名稱";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSave.Font = new System.Drawing.Font("新細明體", 12F);
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.Location = new System.Drawing.Point(52, 275);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 45);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "儲存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Orange;
            this.btnBack.Font = new System.Drawing.Font("新細明體", 12F);
            this.btnBack.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBack.Location = new System.Drawing.Point(234, 275);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(112, 45);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "返回";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtMachineNo
            // 
            this.txtMachineNo.Location = new System.Drawing.Point(196, 79);
            this.txtMachineNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtMachineNo.Name = "txtMachineNo";
            this.txtMachineNo.Size = new System.Drawing.Size(148, 27);
            this.txtMachineNo.TabIndex = 5;
            // 
            // txtAlertNo
            // 
            this.txtAlertNo.Location = new System.Drawing.Point(196, 133);
            this.txtAlertNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtAlertNo.Name = "txtAlertNo";
            this.txtAlertNo.Size = new System.Drawing.Size(148, 27);
            this.txtAlertNo.TabIndex = 6;
            // 
            // txtAlertName
            // 
            this.txtAlertName.Location = new System.Drawing.Point(196, 183);
            this.txtAlertName.Margin = new System.Windows.Forms.Padding(4);
            this.txtAlertName.Name = "txtAlertName";
            this.txtAlertName.Size = new System.Drawing.Size(148, 27);
            this.txtAlertName.TabIndex = 7;
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Font = new System.Drawing.Font("新細明體", 16F);
            this.labTitle.Location = new System.Drawing.Point(50, 36);
            this.labTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(75, 22);
            this.labTitle.TabIndex = 8;
            this.labTitle.Text = "labTitle";
            // 
            // FormMachineOptEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 367);
            this.Controls.Add(this.labTitle);
            this.Controls.Add(this.txtAlertName);
            this.Controls.Add(this.txtAlertNo);
            this.Controls.Add(this.txtMachineNo);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("新細明體", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMachineOptEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormMachineOptEdit";
            this.Activated += new System.EventHandler(this.FormMachineOptEdit_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMachineOptEdit_FormClosing);
            this.Load += new System.EventHandler(this.FormMachineOptEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtMachineNo;
        private System.Windows.Forms.TextBox txtAlertNo;
        private System.Windows.Forms.TextBox txtAlertName;
        private System.Windows.Forms.Label labTitle;
    }
}