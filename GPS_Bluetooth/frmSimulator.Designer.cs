namespace GPS_Bluetooth
{
	partial class frmSimulator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSimulator));
            this.tbPort = new System.Windows.Forms.TextBox();
            this.cbOpen = new System.Windows.Forms.CheckBox();
            this.cbSend = new System.Windows.Forms.CheckBox();
            this.cbFixType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNumSV = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbHAcc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbVAcc = new System.Windows.Forms.TextBox();
            this.zoomInBtn = new System.Windows.Forms.Button();
            this.zoomOutBtn = new System.Windows.Forms.Button();
            this.centerBtn = new System.Windows.Forms.Button();
            this.samplePoint = new System.Windows.Forms.CheckBox();
            this.userControl12 = new GPS_Bluetooth.UserControl1();
            this.userControl11 = new GPS_Bluetooth.UserControl1();
            this.rtkCheck = new System.Windows.Forms.CheckBox();
            this.receiverCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(24, 23);
            this.tbPort.Margin = new System.Windows.Forms.Padding(6);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(150, 31);
            this.tbPort.TabIndex = 0;
            // 
            // cbOpen
            // 
            this.cbOpen.AutoSize = true;
            this.cbOpen.Location = new System.Drawing.Point(190, 27);
            this.cbOpen.Margin = new System.Windows.Forms.Padding(6);
            this.cbOpen.Name = "cbOpen";
            this.cbOpen.Size = new System.Drawing.Size(112, 29);
            this.cbOpen.TabIndex = 27;
            this.cbOpen.Text = "IsOpen";
            this.cbOpen.UseVisualStyleBackColor = true;
            // 
            // cbSend
            // 
            this.cbSend.AutoSize = true;
            this.cbSend.Location = new System.Drawing.Point(303, 29);
            this.cbSend.Margin = new System.Windows.Forms.Padding(6);
            this.cbSend.Name = "cbSend";
            this.cbSend.Size = new System.Drawing.Size(223, 29);
            this.cbSend.TabIndex = 28;
            this.cbSend.Text = "Send every 100ms";
            this.cbSend.UseVisualStyleBackColor = true;
            // 
            // cbFixType
            // 
            this.cbFixType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFixType.FormattingEnabled = true;
            this.cbFixType.Location = new System.Drawing.Point(543, 19);
            this.cbFixType.Margin = new System.Windows.Forms.Padding(6);
            this.cbFixType.Name = "cbFixType";
            this.cbFixType.Size = new System.Drawing.Size(158, 33);
            this.cbFixType.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(723, 35);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 25);
            this.label5.TabIndex = 31;
            this.label5.Text = "NumSV";
            // 
            // tbNumSV
            // 
            this.tbNumSV.Location = new System.Drawing.Point(821, 21);
            this.tbNumSV.Margin = new System.Windows.Forms.Padding(6);
            this.tbNumSV.Name = "tbNumSV";
            this.tbNumSV.Size = new System.Drawing.Size(98, 31);
            this.tbNumSV.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(943, 29);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 25);
            this.label6.TabIndex = 33;
            this.label6.Text = "hAcc (mm)";
            // 
            // tbHAcc
            // 
            this.tbHAcc.Location = new System.Drawing.Point(1069, 23);
            this.tbHAcc.Margin = new System.Windows.Forms.Padding(6);
            this.tbHAcc.Name = "tbHAcc";
            this.tbHAcc.Size = new System.Drawing.Size(126, 31);
            this.tbHAcc.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1213, 29);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 25);
            this.label7.TabIndex = 35;
            this.label7.Text = "vAcc (mm)";
            // 
            // tbVAcc
            // 
            this.tbVAcc.Location = new System.Drawing.Point(1339, 23);
            this.tbVAcc.Margin = new System.Windows.Forms.Padding(6);
            this.tbVAcc.Name = "tbVAcc";
            this.tbVAcc.Size = new System.Drawing.Size(126, 31);
            this.tbVAcc.TabIndex = 34;
            // 
            // zoomInBtn
            // 
            this.zoomInBtn.Location = new System.Drawing.Point(1504, 23);
            this.zoomInBtn.Name = "zoomInBtn";
            this.zoomInBtn.Size = new System.Drawing.Size(86, 37);
            this.zoomInBtn.TabIndex = 36;
            this.zoomInBtn.Text = "-";
            this.zoomInBtn.UseVisualStyleBackColor = true;
            this.zoomInBtn.Click += new System.EventHandler(this.zoomInBtn_Click);
            // 
            // zoomOutBtn
            // 
            this.zoomOutBtn.Location = new System.Drawing.Point(1596, 24);
            this.zoomOutBtn.Name = "zoomOutBtn";
            this.zoomOutBtn.Size = new System.Drawing.Size(86, 37);
            this.zoomOutBtn.TabIndex = 37;
            this.zoomOutBtn.Text = "+";
            this.zoomOutBtn.UseVisualStyleBackColor = true;
            this.zoomOutBtn.Click += new System.EventHandler(this.zoomOutBtn_Click);
            // 
            // centerBtn
            // 
            this.centerBtn.Location = new System.Drawing.Point(1688, 24);
            this.centerBtn.Name = "centerBtn";
            this.centerBtn.Size = new System.Drawing.Size(101, 37);
            this.centerBtn.TabIndex = 38;
            this.centerBtn.Text = "Center";
            this.centerBtn.UseVisualStyleBackColor = true;
            this.centerBtn.Click += new System.EventHandler(this.centerBtn_Click);
            // 
            // samplePoint
            // 
            this.samplePoint.AutoSize = true;
            this.samplePoint.Location = new System.Drawing.Point(1798, 29);
            this.samplePoint.Margin = new System.Windows.Forms.Padding(6);
            this.samplePoint.Name = "samplePoint";
            this.samplePoint.Size = new System.Drawing.Size(116, 29);
            this.samplePoint.TabIndex = 39;
            this.samplePoint.Text = "Sample";
            this.samplePoint.UseVisualStyleBackColor = true;
            this.samplePoint.CheckedChanged += new System.EventHandler(this.samplePoint_CheckedChanged);
            // 
            // userControl12
            // 
            this.userControl12.Location = new System.Drawing.Point(12, 76);
            this.userControl12.Margin = new System.Windows.Forms.Padding(12);
            this.userControl12.Name = "userControl12";
            this.userControl12.ShowCurrentPosition = false;
            this.userControl12.Size = new System.Drawing.Size(293, 612);
            this.userControl12.TabIndex = 25;
            this.userControl12.Zoomed = false;
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(317, 76);
            this.userControl11.Margin = new System.Windows.Forms.Padding(12);
            this.userControl11.Name = "userControl11";
            this.userControl11.ShowCurrentPosition = false;
            this.userControl11.Size = new System.Drawing.Size(1836, 612);
            this.userControl11.TabIndex = 24;
            this.userControl11.Zoomed = false;
            this.userControl11.Load += new System.EventHandler(this.userControl11_Load);
            this.userControl11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.userControl11_MouseDown);
            this.userControl11.MouseEnter += new System.EventHandler(this.userControl11_MouseEnter);
            this.userControl11.MouseLeave += new System.EventHandler(this.userControl11_MouseLeave);
            this.userControl11.MouseHover += new System.EventHandler(this.userControl11_MouseHover);
            this.userControl11.MouseMove += new System.Windows.Forms.MouseEventHandler(this.userControl11_MouseMove);
            this.userControl11.MouseUp += new System.Windows.Forms.MouseEventHandler(this.userControl11_MouseUp);
            // 
            // rtkCheck
            // 
            this.rtkCheck.AutoSize = true;
            this.rtkCheck.Location = new System.Drawing.Point(2067, 29);
            this.rtkCheck.Margin = new System.Windows.Forms.Padding(6);
            this.rtkCheck.Name = "rtkCheck";
            this.rtkCheck.Size = new System.Drawing.Size(86, 29);
            this.rtkCheck.TabIndex = 40;
            this.rtkCheck.Text = "RTK";
            this.rtkCheck.UseVisualStyleBackColor = true;
            // 
            // receiverCheck
            // 
            this.receiverCheck.AutoSize = true;
            this.receiverCheck.Location = new System.Drawing.Point(1926, 29);
            this.receiverCheck.Margin = new System.Windows.Forms.Padding(6);
            this.receiverCheck.Name = "receiverCheck";
            this.receiverCheck.Size = new System.Drawing.Size(129, 29);
            this.receiverCheck.TabIndex = 41;
            this.receiverCheck.Text = "Receiver";
            this.receiverCheck.UseVisualStyleBackColor = true;
            // 
            // frmSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2176, 700);
            this.Controls.Add(this.receiverCheck);
            this.Controls.Add(this.rtkCheck);
            this.Controls.Add(this.samplePoint);
            this.Controls.Add(this.centerBtn);
            this.Controls.Add(this.zoomOutBtn);
            this.Controls.Add(this.zoomInBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbVAcc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbHAcc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbNumSV);
            this.Controls.Add(this.cbFixType);
            this.Controls.Add(this.cbSend);
            this.Controls.Add(this.cbOpen);
            this.Controls.Add(this.userControl12);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.tbPort);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmSimulator";
            this.Text = "Torch Simulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSimulator_FormClosing);
            this.Load += new System.EventHandler(this.frmSimulator_Load);
            this.Resize += new System.EventHandler(this.frmSimulator_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbPort;
		private UserControl1 userControl11;
		private UserControl1 userControl12;
		private System.Windows.Forms.CheckBox cbOpen;
		private System.Windows.Forms.CheckBox cbSend;
		private System.Windows.Forms.ComboBox cbFixType;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbNumSV;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbHAcc;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbVAcc;
        private System.Windows.Forms.Button zoomInBtn;
        private System.Windows.Forms.Button zoomOutBtn;
        private System.Windows.Forms.Button centerBtn;
        private System.Windows.Forms.CheckBox samplePoint;
        private System.Windows.Forms.CheckBox rtkCheck;
        private System.Windows.Forms.CheckBox receiverCheck;
    }
}