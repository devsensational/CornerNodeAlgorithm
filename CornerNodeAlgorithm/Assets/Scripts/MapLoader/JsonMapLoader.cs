
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class JsonMapLoader
{
    private Cell[,] mapData;
    private List<(int, int)> wallList;
    private int width, height;
    
    private void loadJson(string fileName)
    {
        string path = Application.dataPath + "/" + fileName + ".json";

        using (StreamReader file = File.OpenText(path))
        using (JsonTextReader reader = new JsonTextReader(file))
        {
            JObject json = (JObject) JToken.ReadFrom(reader);
            width = (int) json["width"];
            height = (int) json["height"];
            
            mapData = new Cell[width,height];
            wallList = new List<(int, int)>();
            
            var mData = json.SelectToken("mapDataArr");
            // var mData = json.SelectToken("mapDataArr2");
            // var mCount = json.SelectToken("mapCountArr");
            // Debug.Log("mdata cnt : " + mData.Count());
            // Debug.Log("mCount cnt : " + mCount.Count());
            int cnt = 0, ptrX = 0, ptrY = 0, idx = 0;
            
            /*
            for(int i = 0 ; i < mCount.Count(); i++)
            {
                
                for (int j = 0; j < (int)mCount[i]; j++)
                {
                    if (ptrY >= width)
                    {
                        ptrX = 0;
                        ptrY++;
                    }
                    
                    int tokenValue = (int) mData[i];
                    mapData[ptrX, ptrY] = new Cell(tokenValue);
                    if(tokenValue == 1) wallList.Add((ptrX,ptrY));
                    ptrX++;
                    cnt++;
                    //Debug.Log("cnt : " + cnt + " / x : " + ptrX + " / Y : " + ptrY + " / idx : " + idx);
                }
            }
            */
            
           
            for (int i = 0; i < width; i++)
            {
                for (int j = height - 1; j >= 0; j--)
                {
                    int tokenValue = (int) mData[cnt];
                    mapData[i, j] = new Cell(tokenValue);
                    if(tokenValue == 1) wallList.Add((i,j)); // Add wall data at wallList
                    cnt++;
                }
            }
            Debug.Log("Number of walls = " + wallList.Count);
        }
    }

    public void start(string fileName) // Start this method at other object
    {
        loadJson(fileName);
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
