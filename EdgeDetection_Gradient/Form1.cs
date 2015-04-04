using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdgeDetection_Gradient
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap source, result, filterImage;
        String fileInput;
        String fileFilter = "locnhieu.jpg";
        private void Form1_Load(object sender, EventArgs e)
        {
            cbxOp.Items.AddRange(Enum.GetNames(typeof(OperatorType)));
            cbxType.Items.AddRange(Enum.GetNames(typeof(ImageType)));
            cbb_LocNhieu.Items.AddRange(Enum.GetNames(typeof(FilterType)));

            cbxOp.SelectedIndex = 1;
            cbxType.SelectedIndex = 0;
            cbb_LocNhieu.SelectedIndex = 0;
        }

        private void ClickDetect(object sender, EventArgs e)
        {
            status.Text = "đang xử lý";
            EdgeDetection detect = new EdgeDetection(source);
           
            filterImage = detect.LocNhieu(source, (FilterType)cbb_LocNhieu.SelectedIndex);
            filterPicture.Image = filterImage;
            filterImage.Save(fileFilter, ImageFormat.Jpeg);

            result = detect.Detect(filterImage, (ImageType)cbxType.SelectedIndex, (OperatorType)cbxOp.SelectedIndex, int.Parse(txt_Nguong.Text));
            pic_2.Image = result;
            status.Text = "";
        }

        private void Click_Source(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileInput = open.FileName;
                source = new Bitmap(open.FileName);
                pic_1.Image = source;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog f = new SaveFileDialog();
            //f.Filter = ".jpg"; 
            if(f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                result.Save(f.FileName,  ImageFormat.Jpeg);
               
                Process.Start(f.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start(fileInput);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start(fileFilter);
        }
    }
}
