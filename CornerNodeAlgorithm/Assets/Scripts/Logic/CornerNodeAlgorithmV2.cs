using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CornerNodeAlgorithmV2
{
    private int[,] direction = {{1, 0}, {1, 1}, {0, 1}, {-1, 1}, {0, -1}, {-1, -1}, {-1, 0}, {1, -1}};
    private int width, height;

    private Cell[,] mapData;
    private List<PathNode> pNodeList = new List<PathNode>();

    private void createCorner(int x, int y, int beforeDirection)
    {
        Debug.Log("Ptr X = " + x + " / ptr Y = " + y);
        if (x < 0 || y < 0 || x >= width || y >= height) {Debug.Log("Out of range"); return;}
        if (mapData[x, y].Type == Constants.CHECK) {Debug.Log("Checked cell"); return;}
        if (/*map[x, y].Type == Constants.CLOSE ||*/ mapData[x, y].Type == Constants.OPEN )
        {
            int wallCount = 0;
            for (int i = 0; i < 8; i++)
            {
                int nextX = x + direction[i, 0];
                int nextY = y + direction[i, 1];
                if (!(nextX < 0 || nextY < 0 || nextX >= width || nextY >= height))
                    if (mapData[nextX, nextY].Type == Constants.WALL || mapData[nextX, nextY].Type == Constants.CHECK)
                        wallCount++;
            }
            Debug.Log("X : " + x + " / Y : " + y + " / WallCount = " + wallCount);
            if (wallCount == 1)
            {
                mapData[x, y].Type = Constants.NODE;
                pNodeList.Add(new PathNode(x, y));
            }
            return;
        }

        if (mapData[x, y].Type == Constants.WALL)
        {
            mapData[x, y].Type = Constants.CHECK;
            int backward = directionSelector(beforeDirection - 4);
            for (int i = 0; i < 7; i++)
            {
                int nextDirection = directionSelector(backward + i);
                int nextX = x + direction[nextDirection, 0];
                int nextY = y + direction[nextDirection, 1];
                createCorner(nextX, nextY, nextDirection);
            }
        }
    }

    private int directionSelector(int directionNumber)
    {
        if (directionNumber > 7) return directionNumber % 8;
        if (directionNumber < 0) return 8 + directionNumber;
        return directionNumber;
    }

    private void createConnect()
    {
        CheckWall ckWall = new CheckWall(mapData);
        for (int i = 0; i < pNodeList.Count; i++)
        {
            for (int j = i + 1; j < pNodeList.Count; j++)
            {
                ckWall.chkWall(pNodeList[i], pNodeList[j]);
            }
        }
    }

    public void setMap(Cell[,] map) // Set the generated map data
    {
        this.mapData = map;
        width = map.GetLength(0);
        height = map.GetLength(1);
        Debug.Log("width : " + width);
        Debug.Log("height : " + height);
    }
    
    public void setMapData(Cell[,] map)
    {
        this.mapData = map;
        width = map.GetLength(0);
        height = map.GetLength(1);
    }

    public List<PathNode> getPNodeList()
    {
        return pNodeList;
    }

    public void start(int x, int y) //Start
    {
        
        createCorner(x, y, 0);
        createConnect();
    }
    
}