//Virtual map data

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData2D
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
    public Cell[,] getMap()
    {
        return mapData;
    }

    private void mapGene()
    {
        squGene(0, 0, Constants.WIDTH - 1, Constants.HEIGHT - 1, Constants.CLOSE); //
        
        //Hallway 1
        squGene(4, 50, 60,10,Constants.WALL);
        squGene(5,51,58,8,Constants.OPEN);
        
        //Room 1
        squGene(19,50,5,1,Constants.OPEN); //Door
        squGene(18, 45, 7, 5, Constants.WALL);
        squGene(19, 45,5,5,Constants.OPEN);
        squGene(15,35,13,10,Constants.WALL); //room wall side
        squGene(16,36,11,8,Constants.OPEN);//room open side
        squGene(19,44,5,1,Constants.OPEN);//room open side
        
        //Room 2
        squGene(45, 64, 13, 10, Constants.WALL);
        squGene(46,65,11,8,Constants.OPEN);
        squGene(48, 60, 7, 5, Constants.WALL);
        squGene(49,59,5,6,Constants.OPEN);//door
        
        //Diagonal Hallway
        squGene(64, 51, 1, 10, Constants.WALL);
        squGene(65, 52, 1, 10, Constants.WALL);
        squGene(66, 53, 1, 10, Constants.WALL);
        squGene(67, 54, 1, 10, Constants.WALL);
        squGene(68, 55, 1, 9, Constants.WALL);
        squGene(63, 51, 1, 8, Constants.OPEN);
        squGene(64, 52, 1, 8, Constants.OPEN);
        squGene(65, 53, 1, 8, Constants.OPEN);
        squGene(66, 54, 1, 8, Constants.OPEN);
        squGene(67, 55, 1, 8, Constants.OPEN);
        
        //Diagonal Hallway 2
        squGene(19, 59, 5, 1, Constants.OPEN);
        squGene(19, 60, 7, 1, Constants.WALL);
        squGene(20, 61, 7, 1, Constants.WALL);
        squGene(21, 62, 7, 1, Constants.WALL);
        squGene(22, 63, 7, 1, Constants.WALL);
        squGene(23, 64, 7, 1, Constants.WALL);
        squGene(20, 60, 5, 1, Constants.OPEN);
        squGene(21, 61, 5, 1, Constants.OPEN);
        squGene(22, 62, 5, 1, Constants.OPEN);
        squGene(23, 63, 5, 1, Constants.OPEN);
        squGene(24, 64, 5, 1, Constants.OPEN);
        
        // Hallway 2
        squGene(23, 65, 7, 7, Constants.WALL);
        squGene(24, 65, 5, 6, Constants.OPEN);
        
        
        
        
        
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
