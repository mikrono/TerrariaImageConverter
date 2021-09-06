using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Drawing;

namespace ColorJsonGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            WallList wallList;
            string DirectoryPath = Path.Combine(Environment.CurrentDirectory, "Path.txt");

            if (!File.Exists(DirectoryPath))
            {
                File.WriteAllText(DirectoryPath, "Put path of the folder that has wall image files.");

                return;
            }

            string path = File.ReadAllText(DirectoryPath);
            if (Directory.Exists(path))
            {
                string[] WallImages = GetWallFiles(path);
                wallList = ConvertWallImagesToWallList(WallImages);
                File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "WallList.json"), JsonConvert.SerializeObject(wallList));
            }


            Console.WriteLine("Done!");
            Console.ReadLine();
        }




        public static string[] GetWallFiles(string path)
        {
            var files = Directory.EnumerateFiles(path, "*.*")
            .Where(filename => filename.Contains("Wall_") && filename.EndsWith(".png") && !filename.Contains("Outline"));

            return files.ToArray();
        }

        public static WallList ConvertWallImagesToWallList(string[] WallImages)
        {
            Bitmap WallImage;
            WallList wallList = new WallList();

            foreach (var filename in WallImages)
            {
                WallImage = new Bitmap(filename);
                string IdPattern = "Wall_(.+).png";
                int wallId = int.Parse(Regex.Match(filename, IdPattern).Groups[1].Value);

                Wall WallRGB = RGBavgOfWall(WallImage, wallId);

                wallList.Walls.Add(WallRGB);
            }

            return wallList;
        }

        public static Wall RGBavgOfWall(Bitmap Image, int wallId)
        {
            int R = 0;
            int G = 0;
            int B = 0;

            Color color;

            int count = 0;

            for (int i = 0; i < Image.Height; i++)
            {
                for (int j = 0; j < Image.Width; j++)
                {
                    color = Image.GetPixel(j, i);
                    if (color.A > 127)
                    {
                        R += color.R;
                        G += color.G;
                        B += color.B;

                        count++;
                    }
                }
            }

            Wall wall = new Wall();

            wall.WallNumber = wallId;
            wall.R = (byte)(R / count);
            wall.G = (byte)(G / count);
            wall.B = (byte)(B / count);

            return wall;
        }
    }
}
