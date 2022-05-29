using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;
using System.Net.Mime;
using System.Linq;

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

            //var pixelArray = new byte[width, height];
            var mapDataObject = new MapDataObject();
            var mapDataObjectRes = new MapDataObjectRes();

            
            

            mapDataObject.height = height; //Json Map Data height
            mapDataObject.width = width; //Json Map Data width

            mapDataObjectRes.height = height;
            mapDataObjectRes.width = width;
            
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

                        mapDataObject.mapDataArr.Add(1);
                        /*foreach(var data in mapDataObject.mapDataArr)
						{
                            count++;
                            if(lastData != data)
							{
                                mapDataObject.mapDataArr.Add(data);
                                mapDataObject.mapCountArr.Add(count);

                                count = 0;
                                lastData = data;
							}
						}*/

                        /*
                        mapDataObject.mapDataArr.Add(1);
                        var lastData = mapDataObject.mapDataArr.First();
                        mapDataObject.mapDataArr.Add(lastData);
                        count++;
                        if (lastData != 0)
						{
                            
                            mapDataObject.mapCountArr.Add(count);


							//lastData = data;

						}
                        */




                        //mapDataObject.mapDataArr.Add(1); //Add black to list



                        //pixelArray[x, y] = 1;
                    }
                    else //White
                    {
                        mapDataObject.mapDataArr.Add(0);
                        /*foreach (var data in mapDataObject.mapDataArr)
                        {
                            count++;
                            if (lastData != data)
                            {
                                mapDataObject.mapDataArr.Add(data);
                                mapDataObject.mapCountArr.Add(count);

                                count = 0;
                                lastData = data;
                            }
                        }*/

                        
                        //mapDataObject.mapDataArr.Add(0);
                        


                        //pixelArray[x, y] = 0;
                    }
                    
                }
            }
            var count = 0;
            var lastData = mapDataObject.mapDataArr.First();
            mapDataObjectRes.mapDataArr2.Add(lastData);

            foreach (var data in mapDataObject.mapDataArr)
            {
                count++;
                if (lastData != data)
                {
                    mapDataObjectRes.mapDataArr2.Add(data);
                    mapDataObjectRes.mapCountArr.Add(count);

                    

                    count = 0;
                    lastData = data;
                }
            }

            var jsonString = JsonConvert.SerializeObject(mapDataObjectRes);
            File.WriteAllText("C:/Users/kwona/source/repos/test150x/mapDataTest.json", jsonString);

            Console.WriteLine($"Done in {stopwatch.ElapsedMilliseconds}ms");
            Console.WriteLine($"Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}