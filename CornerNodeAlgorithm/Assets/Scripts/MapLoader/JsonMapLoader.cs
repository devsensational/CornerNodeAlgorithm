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
    private List<(int, int)> wallList;
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
            
            mapData = new Cell[width,height];
            wallList = new List<(int, int)>();
            
            var mData = json.SelectToken("mapDataArr");
            int cnt = 0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int tokenValue = (int) mData[cnt];
                    mapData[i, j] = new Cell(tokenValue);
                    if(tokenValue == 1) wallList.Add((i,j)); // Add wall data at wallList
                    cnt++;
                }
            }
        }
    }

    public void start() // Start this method at other object
    {
        loadJson();
    }
    
    public Cell[,] MapData // MapData getter
    {
        get => mapData;
    }
    
    public int Width
    {
        get => width;
    } //Width getter

    public int Height //Height getter
    {
        get => height;
    }

    public List<(int, int)> WallList // WallList getter
    {
        get => wallList;
    }
}
