using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData2D : AbstractMapData2D
{
    private Node[,] mapData;
    public MapData2D()
    {
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
        //Hall way
        squGene(1, 7, 28, 3, 1);
        squGene(2, 8, 26, 1, 0);
        //Room1
        squGene(19, 1, 5, 5, 1);
        squGene(20, 6, 3, 1, 1);
        squGene(20, 2, 3, 3, 0);
        squGene(21, 5, 1, 3, 0);
        //Room2
        squGene(3, 11, 5, 5, 1);
        squGene(4, 10, 3, 1, 1);
        squGene(4, 12, 3, 3, 0);
        squGene(5, 9, 1, 3, 0);
        //Diagonal hall way
        
        squGene(12, 9, 5, 1, 1);
        squGene(12, 10, 5, 1, 1);
        squGene(13, 11, 4, 1, 1);
        squGene(14, 12, 4, 1, 1);
        squGene(15, 13, 4, 1, 1);
        squGene(16, 14, 4, 1, 1);
        squGene(17, 15, 3, 1, 1);

        squGene(13, 9, 3, 1, 0);
        squGene(13, 10, 3, 1, 0);
        squGene(14, 11, 2, 1, 0);
        squGene(15, 12, 2, 1, 0);
        squGene(16, 13, 2, 1, 0);
        squGene(17, 14, 2, 1, 0);
        

        /*
        //Diagonal hall way 2
        squGene(28, 8, 1, 1, 0);
        squGene(29, 7, 1, 3, 1);
        squGene(30, 8, 1, 3, 1);
        squGene(31, 9, 1, 3, 1);
        squGene(32, 10, 1, 2, 1);

        squGene(29, 8, 1, 1, 0);
        squGene(30, 9, 1, 1, 0);
        squGene(31, 10, 1, 1, 0);
        //squGene(32, 14, 1, 1, 0);
        */


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
