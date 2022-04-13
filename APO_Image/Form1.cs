using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace APO_Image
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadImage = new OpenFileDialog();
            loadImage.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (loadImage.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = new Bitmap(loadImage.FileName);
        }

        private void getTextButton_Click(object sender, EventArgs e)
        {
            var ocr = new TesseractEngine(@".\tessdata", "eng", EngineMode.Default);
            var btm = (Bitmap)pictureBox1.Image;
            Pix image = PixConverter.ToPix(btm);
            var text = ocr.Process(image);
            richTextBox1.Text = text.GetText();
        }
    }
}
