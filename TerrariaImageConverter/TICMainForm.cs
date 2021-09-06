using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace TerrariaImageConverter
{
    public partial class TICMainForm : Form
    {
        Bitmap TargetImage;
        Bitmap PixellatedImage;
        double XYRatio;
        double MultRatio;

        bool debug = true;
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
                    TargetImage = new Bitmap(openFileDialog.FileName);

                    PixelX.Maximum = TargetImage.Width;
                    PixelY.Maximum = TargetImage.Height;
                    Pixellation.Enabled = true;
                    progressBar1.Value = 0;

                    ImageViewer(TargetImage);

                }
            }
        }

        private void Pixellation_Click(object sender, EventArgs e)
        {
            ImageViewer(Do_pixellation((int)PixelX.Value, (int)PixelY.Value));
            Pixel2Wall.Enabled = true;
        }

        private void ImageViewer(Bitmap Image)
        {
            Invoke((MethodInvoker)delegate
            {
                int imagewidth = Image.Width;
                int imageheight = Image.Height;

                XYRatio = imagewidth / imageheight;

                if (XYRatio <= 1.0f)
                {
                    MultRatio = (double)(720.0 / (double)Image.Height);
                }
                else if (XYRatio > 1.0f)
                {
                    MultRatio = (double)(1280.0 / (double)Image.Width);
                }
                PixelX.Value = imagewidth;
                PixelY.Value = imageheight;

                int GCDofWidthHeight = GCD(imagewidth, imageheight);
                WidthHeightRatio.Text = $"{imagewidth / GCDofWidthHeight} : {imageheight / GCDofWidthHeight}";

                pictureBox1.Image = new Bitmap(Image, new Size((int)(Image.Width * MultRatio), (int)(Image.Height * MultRatio)));

            });
        }

        private Bitmap Do_pixellation(int desiredX, int desiredY)
        {
            progressBar1.Value = 0;

            int TargetWidth = TargetImage.Width;
            int TargetHeight = TargetImage.Height;

            PixellatedImage = new Bitmap(desiredX, desiredY);

            /*
            int widthDividedByX = flooredDivision(TargetImage.Width, desiredX);
            int heightDividedByY = flooredDivision(TargetImage.Height, desiredY);
            */
            double widthDividedByX = (double)TargetWidth / (double)desiredX;
            double heightDividedByY = (double)TargetHeight / (double)desiredY;

            // Console.WriteLine($"{widthDividedByX}, {heightDividedByY}");

            double size_of_pixellated_unit = widthDividedByX * heightDividedByY;

            if (debug)
            {
                Console.WriteLine($"Width divided by PixelX : {widthDividedByX}, Height divided by PixelY : {heightDividedByY}, Size of pixel unit : {size_of_pixellated_unit}");
            }

            int A, R, G, B;
            int pixelX;
            int pixelY;
            int setPixelX;
            int setPixelY;
            int pixelcount;

            Color color;

            for (int i = 0; i < desiredX * desiredY; i++)
            {
                A = 0;
                R = 0;
                G = 0;
                B = 0;
                pixelcount = 0;

                for (int j = 0; j < widthDividedByX; j++)
                {

                    pixelX = (int)((i % desiredX) * widthDividedByX) + j;  

                    for (int k = 0; k < heightDividedByY; k++)
                    {
                        pixelcount++;
                        pixelY = (int)(i / desiredX * heightDividedByY) + k;


                        if (debug)
                        {
                            Console.WriteLine($"index : {i} GetPixel X : {pixelX} Y : {pixelY}");
                        }

                        
                        color = TargetImage.GetPixel(pixelX, pixelY);
                        A += color.A;
                        R += color.R;
                        G += color.G;
                        B += color.B;

                    }
                }
                /*
                // R 
                if ((R / size_of_pixellated_unit) > 255)
                    R /= (int)(size_of_pixellated_unit + 1);
                else
                    R /= (int)size_of_pixellated_unit;

                // G
                if ((G / size_of_pixellated_unit) > 255)
                    G /= (int)(size_of_pixellated_unit + 1);
                else
                    G /= (int)size_of_pixellated_unit;

                // B
                if ((B / size_of_pixellated_unit) > 255)
                    B /= (int)(size_of_pixellated_unit + 1);
                else
                    B /= (int)size_of_pixellated_unit;
                */
                // A
                if ((A / pixelcount) > 230)
                {
                    A /= pixelcount;
                    R /= pixelcount;
                    G /= pixelcount;
                    B /= pixelcount; 
                }
                else if ((A / pixelcount) <= 230)
                {
                    A = 0;
                    R = 255;
                    G = 255;
                    B = 255;
                }


                setPixelX = i % desiredX;
                setPixelY = i / desiredX;

                if (debug)
                {
                    Console.WriteLine($"index : {i} setPixel X : {setPixelX} Y : {setPixelY}");
                }

                PixellatedImage.SetPixel(setPixelX, setPixelY, Color.FromArgb(A, R, G, B));
                progressBar1.Value = (int)((double)(i + 1) / (double)(desiredX * desiredY) * 100);
            }

            return PixellatedImage;
        }
        private static int GCD(int x, int y)
        {
            while (x != 0 && y != 0)
            {
                if (x > y)
                    x %= y;
                else
                    y %= x;
            }

            return x | y;
        }

        private void Pixel2Wall_Click(object sender, EventArgs e)
        {
            ImageViewer(ConvertPixellatedImage());
        }

        private Bitmap ConvertPixellatedImage()
        {
            Bitmap walledImage = new Bitmap(PixellatedImage.Width, PixellatedImage.Height);
            string JsonPath = Path.Combine(Application.StartupPath, "WallList.json");
            WallList WallPalette = JsonConvert.DeserializeObject<WallList>(File.ReadAllText(JsonPath));
            Wall NearestColorWall = new Wall();
            Color PixelColor;
            string[,] paintToolFile = new string[PixellatedImage.Width, PixellatedImage.Height];
            PaintToolFile paintToolFilePart = new PaintToolFile();

            for (int i = 0; i < PixellatedImage.Width; i++)
            {
                for (int j = 0; j < PixellatedImage.Height; j++)
                {
                    PixelColor = PixellatedImage.GetPixel(i, j);

                    if (PixelColor.A == 0)
                    {
                        walledImage.SetPixel(i, j, Color.FromArgb(0, 0, 0, 0));

                        paintToolFilePart.type = 0;
                        paintToolFilePart.frameX = 0;
                        paintToolFilePart.frameY = 0;
                        paintToolFilePart.wall = 0;
                        paintToolFilePart.liquid = 0;
                        paintToolFilePart.sTileHeader = 0;
                        paintToolFilePart.bTileHeader = 0;
                        paintToolFilePart.bTileHeader2 = 0;
                        paintToolFilePart.bTileHeader3 = 0;
                        paintToolFilePart.collisionType = 0;
                        paintToolFile[i, j] = JsonConvert.SerializeObject(paintToolFilePart);
                    }
                    double TempR = Math.Pow(PixelColor.R - 127, 2);
                    double TempB = Math.Pow(PixelColor.B - 127, 2);
                    double TempG = Math.Pow(PixelColor.G - 127, 2);

                    double distance2 = Math.Sqrt(TempB + TempG + TempR);

                    foreach (var wall in WallPalette.Walls)
                    {
                        double Red = Math.Pow(PixelColor.R - wall.R, 2);
                        double Green = Math.Pow(PixelColor.B - wall.B, 2);
                        double Blue = Math.Pow(PixelColor.G - wall.G, 2);

                        double distance1 = Math.Sqrt(Red + Green + Blue);

                        if (distance1 == 0)
                        {
                            NearestColorWall = wall;
                            break;
                        }
                        else if (distance1 < distance2)
                        {
                            distance2 = distance1;
                            NearestColorWall = wall;
                        }
                    }

                    walledImage.SetPixel(i, j, Color.FromArgb(NearestColorWall.R, NearestColorWall.G, NearestColorWall.B));


                    paintToolFilePart.type = 0;
                    paintToolFilePart.frameX = 0;
                    paintToolFilePart.frameY = 0;
                    paintToolFilePart.wall = (ushort)NearestColorWall.WallNumber;
                    paintToolFilePart.liquid = 0;
                    paintToolFilePart.sTileHeader = 0;
                    paintToolFilePart.bTileHeader = 0;
                    paintToolFilePart.bTileHeader2 = 1;
                    paintToolFilePart.bTileHeader3 = 1;
                    paintToolFilePart.collisionType = 0;
                    paintToolFile[i, j] = JsonConvert.SerializeObject(paintToolFilePart);
                }
            }
            string SavePath = Path.Combine(Application.StartupPath, "CheatSheet_PaintTools_1.json");
            if (File.Exists(SavePath))
            {
                File.Delete(SavePath);
            }
            using (StreamWriter sw = File.AppendText(SavePath))
            {
                sw.Write("[");
                for (int x = 0; x < PixellatedImage.Width; x++)
                {
                    sw.Write("[");
                    for (int y = 0; y < PixellatedImage.Height; y++)
                    {
                        sw.Write(paintToolFile[x, y]);
                        if (y < PixellatedImage.Height - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.Write("]");
                    if (x < PixellatedImage.Width - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write("]");
            }

            return walledImage;
        }

        private void SaveJson_Click(object sender, EventArgs e)
        {

        }
    }
}
