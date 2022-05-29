using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;

namespace test150x
{



    public class Program
    {
        public static void Main()
        {
            var image = Image.Load<Rgba32>("C:/Users/kwona/Desktop/77777.png");
            var width = image.Width;
            var height = image.Height;
            Console.WriteLine($"Width/Height: {width}/{height}");

            var pixelArray = new byte[width, height];

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var pixel = image[x, y];
                    var r = (int)pixel.Rgb.R;
                    var g = (int)pixel.Rgb.G;
                    var b = (int)pixel.Rgb.B;

                    if (r < 128 && g < 128 && b < 128) //Black
                        pixelArray[x, y] = 1;
                    else //White
                        pixelArray[x, y] = 0;
                }
            }
            var jsonString = JsonConvert.SerializeObject(pixelArray);
            File.WriteAllText("C:/Users/kwona/source/repos/test150x/map.json", jsonString);
            Console.WriteLine($"Done in {stopwatch.ElapsedMilliseconds}ms");
            Console.WriteLine($"Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}

