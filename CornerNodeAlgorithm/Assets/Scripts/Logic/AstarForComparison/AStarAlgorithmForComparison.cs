using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class AStarAlgorithmForComparison
{
    private Cell[,] mapData;
    private int startX, startY, targetX, targetY;
    private int width, height;
    
    private List<AStarNodeForComparison> openList = new List<AStarNodeForComparison>();
    private List<AStarNodeForComparison> closeList = new List<AStarNodeForComparison>();
    private List<Vector3> pathList = new List<Vector3>();

    private int[,] direction = {{0, 1}, {1, 0}, {0, -1}, {-1, 0}};
    private int[,] diagonalDirection = {{1, 1}, {-1, 1}, {-1, -1}, {1, -1}};
    
    public List<Vector3> start(int startX, int startY, int targetX, int targetY, Cell[,] mapData)
    {
        //Stopwatch start
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        
        //
        this.startX = startX;
        this.startY = startY;
        this.targetX = targetX;
        this.targetY = targetY;
        this.mapData = mapData;
        width = mapData.GetLength(0);
        height = mapData.GetLength(1);

        AStarNodeForComparison startNode = new AStarNodeForComparison(startX, startY, 0, 0, null);
        Debug.Log("target position : " + targetX + "/" + targetY);
        openList.Add(startNode);
        aStarAlgorithm(startNode);
        
        //Stopwatch stop
        stopwatch.Stop();
        Debug.Log("Single A* Algorithm Done!! Time : " + stopwatch.Elapsed.ToString());
        
        return pathList;
    }

    private void aStarAlgorithm(AStarNodeForComparison ptr)
    {
        do
        {
            if (ptr.X == targetX && ptr.Y == targetY)
            {
                Debug.Log("Find path");
                while (true)
                {
                    pathList.Add(new Vector3(ptr.X, ptr.Y, 0));
                    if (ptr.X == startX && ptr.Y == startY)
                    {
                        return;
                    }
                    ptr = ptr.ParentNode;
                }
            }

            ptr = addCloseList();
            addOpenList(ptr);
        } while (openList.Count != 0);
    }

    private void addOpenList(AStarNodeForComparison ptr)
    {
        for (int i = 0; i < 4; i++) // Normal
        {
            int ptrX = ptr.X + direction[i, 0];
            int ptrY = ptr.Y + direction[i, 1];
            if (ptrX >= 0 && ptrY >= 0 && ptrX < width && ptrY < height)
            {
                if (mapData[ptrX, ptrY].Type == Constants.OPEN || mapData[ptrX, ptrY].Type == Constants.NODE )
                {
                    double hScore = Math.Sqrt(Math.Pow(targetX - ptrX, 2) + Math.Pow(targetY - ptrY, 2));
                    openList.Add(new AStarNodeForComparison(ptrX,ptrY,hScore, 1, ptr));
                    mapData[ptrX, ptrY].Type = Constants.ASTARCHECK;
                }
            }
        }
        
        for (int i = 0; i < 4; i++) // Normal
        {
            int ptrX = ptr.X + diagonalDirection[i, 0];
            int ptrY = ptr.Y + diagonalDirection[i, 1];
            if (ptrX >= 0 && ptrY >= 0 && ptrX < width && ptrY < height)
            {
                if (mapData[ptrX, ptrY].Type == Constants.OPEN || mapData[ptrX, ptrY].Type == Constants.NODE )
                {
                    double hScore = Math.Sqrt(Math.Pow(targetX - ptrX, 2) + Math.Pow(targetY - ptrY, 2));
                    openList.Add(new AStarNodeForComparison(ptrX,ptrY,hScore, 1.33, ptr));
                    mapData[ptrX, ptrY].Type = Constants.ASTARCHECK;
                }
            }
        }
    }

    private AStarNodeForComparison addCloseList()
    {
        if (openList.Count != 0)
        {
            AStarNodeForComparison minNode = openList[0];
            for (int i = 0; i < openList.Count; i++)
            {
                if (minNode.FScore > openList[i].FScore) minNode = openList[i];
            }
            closeList.Add(minNode);
            openList.Remove(minNode);

            return minNode;
        }

        return null;
    }
}
