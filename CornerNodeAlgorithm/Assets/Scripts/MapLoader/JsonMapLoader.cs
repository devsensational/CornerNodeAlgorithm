using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class JsonMapLoader
{
    private Cell[,] mapData;
    private int width, height;



    private void loadJson()
    {
        string path = Application.dataPath + "/map.json";

        using (StreamReader file = File.OpenText(path))
        using (JsonTextReader reader = new JsonTextReader(file))
        {
            JObject json = (JObject) JToken.ReadFrom(reader);
            width = (int) json["width"];
            height = (int) json["height"];
            
            Debug.Log("J Width : " + width);
            Debug.Log("J Height : " + height);
            mapData = new Cell[width,height];
            var mData = json.SelectToken("mapDataArr");
            int cnt = 0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    mapData[i, j] = new Cell((int) mData[cnt]);
                    cnt++;
                }
            }
        }
    }

    public void start() // Start this method at other object
    {
        loadJson();
    }
    
    public Cell[,] MapData // MapData Getter
    {
        get => mapData;
    }
    
    public int Width
    {
        get => width;
    }

    public int Height
    {
        get => height;
    }
}
