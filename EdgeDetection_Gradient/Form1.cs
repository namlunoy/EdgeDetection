using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        Bitmap source, result;

        private void Form1_Load(object sender, EventArgs e)
        {
            cbxOp.Items.AddRange(Enum.GetNames(typeof(OperatorType)));
            cbxType.Items.AddRange(Enum.GetNames(typeof(ImageType)));

            cbxOp.SelectedIndex = 0;
            cbxType.SelectedIndex = 0;
        }

        private void ClickDetect(object sender, EventArgs e)
        {
            EdgeDetection detect = new EdgeDetection();
            result = detect.Detect(source, (ImageType)cbxType.SelectedIndex, (OperatorType)cbxOp.SelectedIndex, int.Parse(txt_Nguong.Text));
            pic_2.Image = result;
        }

        private void Click_Source(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                source = new Bitmap(open.FileName);
                pic_1.Image = source;
            }
        }
    }
}
