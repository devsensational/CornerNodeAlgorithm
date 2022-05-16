using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;
using System.Net.Mime;

namespace test150x
{
    public class Program
    {
        public static void Main()
        {
            var image = Image.Load<Rgba32>("C:/Users/kwona/Desktop/123456.png");
            var width = image.Width;
            var height = image.Height;
            Console.WriteLine($"Width/Height: {width}/{height}");

            var pixelArray = new byte[width, height];
            var mapDataObject = new MapDataObject();

            mapDataObject.height = height; //Json Map Data height
            mapDataObject.width = width; //Json Map Data width
            
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var pixel = image[x, y];
                    var r = (int) pixel.Rgb.R;
                    var g = (int) pixel.Rgb.G;
                    var b = (int) pixel.Rgb.B;

                    if (r < 128 && g < 128 && b < 128) //Black
                    {
                        mapDataObject.mapDataArr.Add(1); //Add black to list
                        //pixelArray[x, y] = 1;
                    }
                    else //White
                    {
                        mapDataObject.mapDataArr.Add(0); //Add white to list
                        //pixelArray[x, y] = 0;
                    }
                }
            }

            var jsonString = JsonConvert.SerializeObject(mapDataObject);
            File.WriteAllText("C:/Users/kwona/source/repos/test150x/mapData.json", jsonString);

            Console.WriteLine($"Done in {stopwatch.ElapsedMilliseconds}ms");
            Console.WriteLine($"Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}