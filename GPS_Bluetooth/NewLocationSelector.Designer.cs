namespace GPS_Bluetooth
{
    partial class NewLocationSelector
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
            this.latA = new System.Windows.Forms.TextBox();
            this.lonA = new System.Windows.Forms.TextBox();
            this.mslA = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mslB = new System.Windows.Forms.TextBox();
            this.lonB = new System.Windows.Forms.TextBox();
            this.latB = new System.Windows.Forms.TextBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Latitude:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Longitude:";
            // 
            // latA
            // 
            this.latA.Location = new System.Drawing.Point(157, 36);
            this.latA.Name = "latA";
            this.latA.Size = new System.Drawing.Size(251, 31);
            this.latA.TabIndex = 4;
            this.latA.Text = "47,2824280548274";
            // 
            // lonA
            // 
            this.lonA.Location = new System.Drawing.Point(157, 74);
            this.lonA.Name = "lonA";
            this.lonA.Size = new System.Drawing.Size(251, 31);
            this.lonA.TabIndex = 7;
            this.lonA.Text = "8,99691177692526";
            // 
            // mslA
            // 
            this.mslA.Location = new System.Drawing.Point(157, 111);
            this.mslA.Name = "mslA";
            this.mslA.Size = new System.Drawing.Size(251, 31);
            this.mslA.TabIndex = 11;
            this.mslA.Text = "880,113252331982";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(80, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "MSL:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mslA);
            this.groupBox1.Controls.Add(this.lonA);
            this.groupBox1.Controls.Add(this.latA);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 165);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Point A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "MSL:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "Longitude:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "Latitude:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.mslB);
            this.groupBox2.Controls.Add(this.lonB);
            this.groupBox2.Controls.Add(this.latB);
            this.groupBox2.Location = new System.Drawing.Point(12, 196);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(443, 165);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Point B";
            // 
            // mslB
            // 
            this.mslB.Location = new System.Drawing.Point(157, 111);
            this.mslB.Name = "mslB";
            this.mslB.Size = new System.Drawing.Size(251, 31);
            this.mslB.TabIndex = 11;
            this.mslB.Text = "1110,65161883983";
            // 
            // lonB
            // 
            this.lonB.Location = new System.Drawing.Point(157, 74);
            this.lonB.Name = "lonB";
            this.lonB.Size = new System.Drawing.Size(251, 31);
            this.lonB.TabIndex = 7;
            this.lonB.Text = "9,00667882998178";
            // 
            // latB
            // 
            this.latB.Location = new System.Drawing.Point(157, 36);
            this.latB.Name = "latB";
            this.latB.Size = new System.Drawing.Size(251, 31);
            this.latB.TabIndex = 4;
            this.latB.Text = "47,2796947997491";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(236, 422);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(221, 47);
            this.cancelBtn.TabIndex = 18;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // confirmBtn
            // 
            this.confirmBtn.Location = new System.Drawing.Point(14, 422);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(221, 47);
            this.confirmBtn.TabIndex = 19;
            this.confirmBtn.Text = "Confirm";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(409, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(28, 27);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 367);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(443, 49);
            this.button1.TabIndex = 20;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NewLocationSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 481);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "NewLocationSelector";
            this.Text = "New Location";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox latA;
        private System.Windows.Forms.TextBox lonA;
        private System.Windows.Forms.TextBox mslA;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox mslB;
        private System.Windows.Forms.TextBox lonB;
        private System.Windows.Forms.TextBox latB;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
    }
}