using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Terraria;

namespace TerrariaImageConverter
{
    public partial class TICMainForm : Form
    {
        Bitmap Image;
        Bitmap PixellatedImage;
        double XYRatio;
        double MultRatio;
        public TICMainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ImageLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Load Image";
                openFileDialog.Filter = "Image files (*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ImagePath.Text = openFileDialog.FileName;
                    Image = new Bitmap(openFileDialog.FileName);
                    XYRatio = Image.Width / Image.Height;
                    if (XYRatio <= 1.0f)
                    {
                        MultRatio = (double)(720.0 / (double)Image.Height);
                    }
                    else if (XYRatio > 1.0f)
                    {
                        MultRatio = (double)(1280.0 / (double)Image.Width);
                    }
                    PixelX.Value = Image.Width;
                    PixelY.Value = Image.Height;
                    pictureBox1.Image = new Bitmap(Image, new Size((int)(Image.Width * MultRatio), (int)(Image.Height * MultRatio)));
                    Pixellation.Enabled = true;
                }
            }
        }

        private void Pixellation_Click(object sender, EventArgs e)
        {
        }
    }
}
