using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine.TestTools;
using UnityEngine;

public class CheckWall
{
    private const int OPEN = 0;
    private const int WALL = 1;
    private const int CLOSE = 2;
    private const int NODE = 3;
    private const int CHECK = 4;
    
    private Cell[,] map;

    public CheckWall(Cell[,] map) //set map from CNA
    {
        this.map = map;
    }

    public void chkWall(PathNode startNode, PathNode targetNode)
    {
        Vector3 startV = new Vector3(startNode.getX(), startNode.getY());
        Vector3 targetV = new Vector3(targetNode.getX(), targetNode.getY());
        Vector3 checkDir = targetV - startV;
        Vector3 dirNorm = checkDir.normalized;
        for (int i = 1; dirNorm.magnitude * i <= checkDir.magnitude; i++)
        {
            int ptrX = startNode.getX() + (int) (dirNorm * i).x;
            int ptrY = startNode.getY() + (int) (dirNorm * i).y;
            int nodeCnt = 0;
            if (map[ptrX, ptrY].Type == CLOSE || map[ptrX, ptrY].Type == WALL || map[ptrX, ptrY].Type == CHECK)
            {
                return;
            }
            if (map[ptrX, ptrY].Type == NODE) nodeCnt++;
            if (nodeCnt > 2) return;
        }
        startNode.setCnn(targetNode, checkDir);
        //targetNode.setCnn(startNode, checkDir);
    }
    
}