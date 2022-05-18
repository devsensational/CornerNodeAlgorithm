using System;
using System.Windows.Forms;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;
using test150x;
using OpenCvSharp;
using System.Drawing;

namespace GGGGU
{
	public partial class Form1 : Form
	{

        Bitmap bitmap;
        

        public Form1()
		{
			InitializeComponent();
		}

		

        private void button2_Click(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}


		private void button2_Click_1(object sender, EventArgs e) 
		{
            // 이미지 로드
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = "png";
            openFile.Filter = "Graphics interchange Format (*.png)|*.png|All files(*.*)|*.*";
            openFile.ShowDialog();

            
            if (openFile.FileName.Length > 0)
            {
                bitmap = new Bitmap(openFile.FileName);

                // 이미지 출력
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = bitmap;


            }




        }

		private void button1_Click_1(object sender, EventArgs e) // 맵 데이터 생성 및 이진화
		{

			System.Drawing.Color col;
            int Average;

            for (int i = 0; i < bitmap.Size.Width; i++)
            {
                for (int j = 0; j < bitmap.Size.Height; j++)
                {
                    col = bitmap.GetPixel(i, j);
                    Average = (col.R + col.G + col.B) / 3;

                    //이진화 흑, 백 위치를 변경하려면 아래 if문 주석위치 변경.
                    //이진화에 한계값은 70으로지정
                    if (Average <= 70)
                    {
                        //image2.SetPixel(i, j, Color.White);
                        bitmap.SetPixel(i, j, System.Drawing.Color.Black);
                    }
                    else
                    {
                        //image2.SetPixel(i, j, Color.Black);
                        bitmap.SetPixel(i, j, System.Drawing.Color.White);
                    }
                }
            }
            //pictureBox1.Image = bitmap;


            byte[] result = null;
            if(bitmap != null)
			{
                MemoryStream stream = new MemoryStream();
                bitmap.Save(stream, bitmap.RawFormat);
                result = stream.ToArray();
			}


            var image = SixLabors.ImageSharp.Image.Load<Rgba32>(result);
            var width = image.Width;
            var height = image.Height;
            Console.WriteLine($"Width/Height: {width}/{height}");



            var pixelArray = new byte[width, height];
            var mapDataObject = new MapDataObject();


            //var count = 0;
            //var count2 = 0;

            mapDataObject.height = height; //Json Map Data 높이
            mapDataObject.width = width; //Json Map Data 길이

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var pixel = image[x, y];
                    var r = (int)pixel.Rgb.R;
                    var g = (int)pixel.Rgb.G;
                    var b = (int)pixel.Rgb.B;


                    if (r < 128 && g < 128 && b < 128) //검은색
                    {



                        mapDataObject.mapDataArr.Add(1); //Add black to list
                        /*for(int i = 0; i < mapDataObject.mapDataArr.Count; i++)
						{
                            if(mapDataObject.mapDataArr.)
                            mapDataObject.mapCountArr.Add(mapDataObject.mapDataArr.Count);
						}*/


                        //pixelArray[x, y] = 1;
                    }
                    else //흰색
                    {
                        mapDataObject.mapDataArr.Add(0); //Add white to list
                        /*for (int i = 0; i < mapDataObject.mapDataArr.Count; i++)
                        {
                            mapDataObject.mapCountArr.Add(mapDataObject.mapDataArr.Count);
                        }
                        */

                        //pixelArray[x, y] = 0;
                    }
                }
            }

            var jsonString = JsonConvert.SerializeObject(mapDataObject);
            File.WriteAllText("C:/Users/kwona/source/repos/test150x/mapData.json", jsonString);

            Console.WriteLine($"Done in {stopwatch.ElapsedMilliseconds}ms");
            Console.WriteLine($"Press any key to continue...");
            //Console.ReadKey(true);
        }

		private void pictureBox1_Click_1(object sender, EventArgs e)
		{

		}
	}
}
