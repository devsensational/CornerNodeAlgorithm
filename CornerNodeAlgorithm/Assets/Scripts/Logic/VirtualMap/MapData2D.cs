using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData2D : AbstractMapData2D
{
    private Cell[,] mapData;
    public MapData2D()
    {
        mapData = new Cell[Constants.WIDTH, Constants.HEIGHT];
        for(int x = 0; x<Constants.WIDTH; x++)
        {
            for(int y = 0; y < Constants.HEIGHT; y++)
            {
                mapData[x, y] = new Cell();
            }
        }

    }
    public override Cell[,] getMap()
    {
        return mapData;
    }

    private void mapGene()
    {
        squGene(0, 0, Constants.WIDTH - 1, Constants.HEIGHT - 1, 2); //
        
        //Hallway
        squGene(4, 50, 60,10,1);
        squGene(5,51,58,8,0);
        
        //Room 1
        squGene(19,50,5,1,0); //Door
        squGene(18, 45, 7, 5, 1);
        squGene(19, 45,5,5,0);
        squGene(15,35,13,10,1); //room wall side
        squGene(16,36,11,8,0);//room open side
        squGene(19,44,5,1,0);//room open side
        
        //Room 2
        squGene(45, 64, 13, 10, 1);
        squGene(46,65,11,8,0);
        squGene(48, 60, 7, 5, 1);
        squGene(49,59,5,6,0);//door
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
