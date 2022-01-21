using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData2D : AbstractMapData2D
{
    private Node[,] mapData;
    public MapData2D()
    {
        Debug.Log("¸Ê »ý¼º ¿Ï·á");
        mapData = new Node[Constants.WIDTH, Constants.HEIGHT];
        for(int x = 0; x<Constants.WIDTH; x++)
        {
            for(int y = 0; y < Constants.HEIGHT; y++)
            {
                mapData[x, y] = new Node();
            }
        }

    }
    public override Node[,] getMap()
    {
        return mapData;
    }

    private void mapGene()
    {
        squGene(0, 0, Constants.WIDTH - 1, Constants.HEIGHT - 1, 2); //ÀüºÎ ´ÝÈù °ø°£
        //º¹µµ
        squGene(1, 7, 28, 3, 1);
        squGene(2, 8, 26, 1, 0);
        //¹æ1
        squGene(19, 1, 5, 5, 1);
        squGene(20, 6, 3, 1, 1);
        squGene(20, 2, 3, 3, 0);
        squGene(21, 5, 1, 3, 0);
        //¹æ2
        squGene(3, 11, 5, 5, 1);
        squGene(4, 10, 3, 1, 1);
        squGene(4, 12, 3, 3, 0);
        squGene(5, 9, 1, 3, 0);
    }

    private void squGene(int startX, int startY, int wid, int hei, int type)
    {
        for(int y = startY; y < startY + hei; y++)
        {
            for(int x = startX; x < startX + wid; x++)
            {
                mapData[x, y].Type = type;
            }
        }
    }

    public void virtualMapGenerate()
    {
        mapGene();
    }
    
}
