using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.Experimental.GraphView;
using Debug = UnityEngine.Debug;

public class CornerNodeAlgorithmV2
{
    private int[,] direction = {{1, 0}, {1, 1}, {0, 1}, {-1, 1}, {0, -1}, {-1, -1}, {-1, 0}, {1, -1}};
    private int width, height;

    private Cell[,] mapData;
    private List<PathNode> pNodeList = new List<PathNode>();
    private List<(int, int)> wallList;

    private void createCorner(int x, int y, int beforeDirection)
    {
        if (x < 0 || y < 0 || x >= width || y >= height) { /*Debug.Log("Out of range");*/ return;} // Out of range
        if (mapData[x, y].Type == Constants.CHECK) { /*Debug.Log("Checked cell");*/ return;} // Checked cell

        /*
        if (beforeDirection != -1)
        {
            int bufferX = x + direction[beforeDirection, 0];
            int bufferY = y + direction[beforeDirection, 1];
            if (bufferX >= 0 && bufferY >= 0 && bufferX < width && bufferY < height)
            {
                if (mapData[bufferX, bufferY].Type == Constants.WALL)
                {
                    mapData[bufferX, bufferY].Type = Constants.CHECK;
                    createCorner(bufferX, bufferY, beforeDirection);
                    return;
                }
            }
        }
        */
        

        if (/*map[x, y].Type == Constants.CLOSE ||*/ mapData[x, y].Type == Constants.OPEN ) // is Corner?
        {
            int wallCount = 0;
            for (int i = 0; i < 8; i++)
            {
                int nextX = x + direction[i, 0];
                int nextY = y + direction[i, 1];
                if (!(nextX < 0 || nextY < 0 || nextX >= width || nextY >= height))
                    if (mapData[nextX, nextY].Type == Constants.WALL || mapData[nextX, nextY].Type == Constants.CHECK)
                        wallCount++;
                if (wallCount > 1) break;
            }
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

    private void createCornerV2(int x, int y)
    {
        for (int i = 0; i < 8; i++)
        {
            int nextX = x + direction[i, 0];
            int nextY = y + direction[i, 1];
            if (!(nextX < 0 || nextY < 0 || nextX >= width || nextY >= height))
            {
                if (mapData[nextX, nextY].Type == Constants.OPEN)
                {
                    checkCorner(nextX, nextY);
                }
            }
        }

        mapData[x, y].Type = Constants.CHECK;
    }

    private void checkCorner(int x, int y)
    {
        int wallCount = 0;
        for (int i = 0; i < 8; i++)
        {
            int nextX = x + direction[i, 0];
            int nextY = y + direction[i, 1];
            if (!(nextX < 0 || nextY < 0 || nextX >= width || nextY >= height))
                if (mapData[nextX, nextY].Type == Constants.WALL || mapData[nextX, nextY].Type == Constants.CHECK)
                    wallCount++;
            if (wallCount > 1) break;
        }

        if (wallCount == 1)
        {
            //Debug.Log("check CornerV2");
            mapData[x, y].Type = Constants.NODE;
            pNodeList.Add(new PathNode(x, y));
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

    public List<PathNode> getPNodeList()
    {
        return pNodeList;
    }

    public void start(List<(int, int)> wallList) //Start
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 0; i < wallList.Count; i++)
        {
            int x = wallList[i].Item1;
            int y = wallList[i].Item2;
            if(mapData[x,y].Type == Constants.WALL)
            {
                createCornerV2(x, y);
            }
        }
        createConnect();
        stopwatch.Stop();
        Debug.Log("Node Create Done!! Time : " + stopwatch.Elapsed.ToString());
    }
    
}