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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pic_2 = new System.Windows.Forms.PictureBox();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbxOp = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txt_Nguong = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbb_LocNhieu = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.filterPicture = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.giuMau = new System.Windows.Forms.CheckBox();
            this.status = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_2)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filterPicture)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pic_1);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 422);
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
            this.pic_1.Size = new System.Drawing.Size(360, 403);
            this.pic_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_1.TabIndex = 0;
            this.pic_1.TabStop = false;
            this.pic_1.DoubleClick += new System.EventHandler(this.Click_Source);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pic_2);
            this.groupBox2.Location = new System.Drawing.Point(812, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(357, 419);
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
            this.pic_2.Size = new System.Drawing.Size(351, 400);
            this.pic_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
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
            this.groupBox3.Location = new System.Drawing.Point(12, 487);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(128, 52);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Loại ảnh - Type";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbxOp);
            this.groupBox4.Location = new System.Drawing.Point(382, 487);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(213, 52);
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
            this.cbxOp.Size = new System.Drawing.Size(173, 21);
            this.cbxOp.TabIndex = 4;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txt_Nguong);
            this.groupBox5.Location = new System.Drawing.Point(601, 487);
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
            this.button1.Location = new System.Drawing.Point(827, 487);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 52);
            this.button1.TabIndex = 8;
            this.button1.Text = "Detect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ClickDetect);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1006, 487);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 52);
            this.button2.TabIndex = 9;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbb_LocNhieu);
            this.groupBox6.Location = new System.Drawing.Point(146, 487);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(218, 52);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Lọc nhiễu";
            // 
            // cbb_LocNhieu
            // 
            this.cbb_LocNhieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_LocNhieu.FormattingEnabled = true;
            this.cbb_LocNhieu.Location = new System.Drawing.Point(23, 19);
            this.cbb_LocNhieu.Name = "cbb_LocNhieu";
            this.cbb_LocNhieu.Size = new System.Drawing.Size(177, 21);
            this.cbb_LocNhieu.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(15, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Open in PhotoViewer";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.filterPicture);
            this.groupBox7.Location = new System.Drawing.Point(410, 41);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(366, 422);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Ảnh tiền xử lý";
            // 
            // filterPicture
            // 
            this.filterPicture.BackColor = System.Drawing.SystemColors.ControlDark;
            this.filterPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterPicture.Location = new System.Drawing.Point(3, 16);
            this.filterPicture.Name = "filterPicture";
            this.filterPicture.Size = new System.Drawing.Size(360, 403);
            this.filterPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.filterPicture.TabIndex = 0;
            this.filterPicture.TabStop = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(413, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(128, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "Open in PhotoViewer";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.giuMau);
            this.groupBox8.Location = new System.Drawing.Point(755, 487);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(66, 52);
            this.groupBox8.TabIndex = 8;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Giữ màu";
            // 
            // giuMau
            // 
            this.giuMau.AutoSize = true;
            this.giuMau.Location = new System.Drawing.Point(25, 23);
            this.giuMau.Name = "giuMau";
            this.giuMau.Size = new System.Drawing.Size(15, 14);
            this.giuMau.TabIndex = 0;
            this.giuMau.UseVisualStyleBackColor = true;
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(966, 463);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 13);
            this.status.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1181, 611);
            this.Controls.Add(this.status);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edge Detection - Gradient Based Method";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.filterPicture)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pic_1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pic_2;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbxOp;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txt_Nguong;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.PictureBox filterPicture;
        private System.Windows.Forms.ComboBox cbb_LocNhieu;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.CheckBox giuMau;
        private System.Windows.Forms.Label status;
    }
}

