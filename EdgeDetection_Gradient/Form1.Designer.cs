namespace EdgeDetection_Gradient
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pic_1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pic_2 = new System.Windows.Forms.PictureBox();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbxOp = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txt_Nguong = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_2)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pic_1);
            this.groupBox1.Location = new System.Drawing.Point(12, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 243);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ảnh gốc";
            // 
            // pic_1
            // 
            this.pic_1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pic_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_1.Location = new System.Drawing.Point(3, 16);
            this.pic_1.Name = "pic_1";
            this.pic_1.Size = new System.Drawing.Size(285, 224);
            this.pic_1.TabIndex = 0;
            this.pic_1.TabStop = false;
            this.pic_1.DoubleClick += new System.EventHandler(this.Click_Source);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(135, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gradient Based Method";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pic_2);
            this.groupBox2.Location = new System.Drawing.Point(333, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 243);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ảnh đích";
            // 
            // pic_2
            // 
            this.pic_2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pic_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_2.Location = new System.Drawing.Point(3, 16);
            this.pic_2.Name = "pic_2";
            this.pic_2.Size = new System.Drawing.Size(285, 224);
            this.pic_2.TabIndex = 0;
            this.pic_2.TabStop = false;
            // 
            // cbxType
            // 
            this.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Location = new System.Drawing.Point(17, 19);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(90, 21);
            this.cbxType.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxType);
            this.groupBox3.Location = new System.Drawing.Point(15, 304);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(128, 52);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Loại ảnh - Type";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbxOp);
            this.groupBox4.Location = new System.Drawing.Point(336, 304);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(285, 181);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Operator - Mặt nạ";
            // 
            // cbxOp
            // 
            this.cbxOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOp.FormattingEnabled = true;
            this.cbxOp.Location = new System.Drawing.Point(17, 19);
            this.cbxOp.Name = "cbxOp";
            this.cbxOp.Size = new System.Drawing.Size(90, 21);
            this.cbxOp.TabIndex = 4;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txt_Nguong);
            this.groupBox5.Location = new System.Drawing.Point(172, 304);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(128, 52);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Ngưỡng - Threshold";
            // 
            // txt_Nguong
            // 
            this.txt_Nguong.Location = new System.Drawing.Point(22, 20);
            this.txt_Nguong.Name = "txt_Nguong";
            this.txt_Nguong.Size = new System.Drawing.Size(89, 20);
            this.txt_Nguong.TabIndex = 0;
            this.txt_Nguong.Text = "100";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(32, 371);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(251, 97);
            this.button1.TabIndex = 8;
            this.button1.Text = "Detect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ClickDetect);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 497);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Edge Detection";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pic_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pic_2;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbxOp;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txt_Nguong;
        private System.Windows.Forms.Button button1;
    }
}

