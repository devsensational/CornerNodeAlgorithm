using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using SixLabors.ImageSharp.PixelFormats;
using test150x;
using System.Threading;

namespace GGGGU
{
    public partial class Form2 : Form
    {
        Bitmap bitmap;
        public Form2(string filename)
        {
            InitializeComponent();
            setImgAndPath(filename);
        }

        private void setImgAndPath(string FileName)
        {
            if (FileName.Length > 0)
            {
                bitmap = new Bitmap(FileName);

                // 이미지 출력
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Image = bitmap;
                FilePath.Text = FileName;
            }
        }
        private void Retry_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = "png";
            openFile.Filter = "Graphics interchange Format (*.png)|*.png|All files(*.*)|*.*";
            openFile.ShowDialog();
            
            setImgAndPath(openFile.FileName);
        }

        private async void CreateMap_Click(object sender, EventArgs e) //맵 생성 버튼
		{
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            string savePath = dialog.SelectedPath;
            
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
            
            //var pixelArray = new byte[width, height];
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
            File.WriteAllText(savePath + "/mapData.json", jsonString);
            
            //파일 업로드
            await ServerAPI.UploadFile(savePath + "/mapData.json");
            Thread.Sleep(100);
            MessageBox.Show("Form2: " + ServerAPI.GlobalRes);
            await ServerAPI.UploadImg(FilePath.Text);
            
             
            FileInfo fi = new FileInfo(savePath + "/mapData.json");
            if (fi.Exists)
            {
                MessageBox.Show("저장이 완료되었습니다.");
                this.Close();
            }

            Console.WriteLine($"Done in {stopwatch.ElapsedMilliseconds}ms");
            Console.WriteLine($"Press any key to continue...");
            //Console.ReadKey(true);
		}
    }
}