using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class AStarAlgorithmV2
{
    private PathNode startNode, targetNode;
    private List<PathNode> pNodeList;
    private Cell[,] mapData;
    private CheckWall checkWall;

    private List<AStarNode> openList = new List<AStarNode>();
    private List<AStarNode> closeList = new List<AStarNode>();
    private List<Vector3> pathResult = new List<Vector3>();
    
    public List<Vector3> start(PathNode startNode, PathNode targetNode, List<PathNode> pNodeList, Cell[,] mapData)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        
        this.startNode = startNode;
        this.targetNode = targetNode;
        this.pNodeList = pNodeList;
        this.mapData = mapData;
        
        checkWall = new CheckWall(mapData);
        
        pNodeList.Add(startNode);
        cnnNode(startNode);
        pNodeList.Add(targetNode);
        cnnNode(targetNode);
        
        openList.Add(new AStarNode(startNode,0,0,null));
        aStarAlgorithm(openList[0]);
        
        stopwatch.Stop();
        Debug.Log("A* + CNA Done! Time : " + stopwatch.ElapsedMilliseconds);
        return pathResult;
    }

    private void aStarAlgorithm(AStarNode ptr)
    {
        do
        {
            ptr = addCloseList();
            //Debug.Log(ptr.GetNode.getX() + " / " + ptr.GetNode.getY());
            addOpenList(ptr);
            
            if (ptr.GetNode == targetNode && ptr.GetNode == targetNode)
            {
                //done
                Debug.Log("Pathfinding Complete (A* + CNA)");
                while (true)
                {
                    pathResult.Add(new Vector3(ptr.GetNode.getX(), 0,ptr.GetNode.getY()));
                    if (ptr.GetNode.getX() == startNode.getX() && ptr.GetNode.getY() == startNode.getY())
                    {
                        return;
                    }
                    ptr = ptr.ParentNode;
                }
            }

        } while (openList.Count != 0);
        Debug.Log("Can't find path");
    }
    private void addOpenList(AStarNode ptr)
    {
        for (int i = 0; i < ptr.GetNode.getCnn().Count; i++)
        {
            Tuple<PathNode,Vector3> nodeBuffer = ptr.GetNode.getCnn()[i];
            double hScore = Math.Sqrt(Math.Pow(targetNode.getX() - nodeBuffer.Item1.getX(), 2) + Math.Pow(targetNode.getY() - nodeBuffer.Item1.getY(), 2));
            double gScore = Math.Sqrt(Math.Pow(ptr.GetNode.getX() - nodeBuffer.Item1.getX(), 2) + Math.Pow(ptr.GetNode.getY() - nodeBuffer.Item1.getY(), 2)) + ptr.GScore;
            double fScore = hScore + gScore;
            //Debug.Log(hScore + "+" +gScore);
            
            if (nodeBuffer.Item1.Status == 0) // When a node doesn't belong any list
            {
                AStarNode newAStarNode = new AStarNode(nodeBuffer.Item1,hScore, gScore , ptr);
                openList.Add(newAStarNode);
                nodeBuffer.Item1.Status = 1;
                nodeBuffer.Item1.AStarNode = newAStarNode;
                nodeBuffer.Item1.FScore = newAStarNode.FScore;
            } 
            
            else if (nodeBuffer.Item1.Status == 1) // When a node belong to open list
            {
                if (fScore < nodeBuffer.Item1.FScore)
                {
                    nodeBuffer.Item1.AStarNode.GScore = gScore;
                    nodeBuffer.Item1.AStarNode.HScore = hScore;
                    nodeBuffer.Item1.AStarNode.FScore = fScore;
                    nodeBuffer.Item1.AStarNode.ParentNode = ptr;
                }
            }
        }
        //Debug.Log("--------------------------");
    }

    private AStarNode addCloseList()
    {
        if (openList.Count != 0)
        {
            AStarNode minNode = openList[0];
            for (int i = 0; i < openList.Count; i++)
            {
                if (minNode.FScore > openList[i].FScore) minNode = openList[i];
            }

            minNode.GetNode.Status = 2;
            closeList.Add(minNode);
            openList.Remove(minNode);
            return minNode;
        }

        return null;
    }
    
    private void cnnNode(PathNode ptr)
    {
        for (int i = 0; i < pNodeList.Count - 1; i++)
        {
            checkWall.chkWall(ptr, pNodeList[i]);
            
        }
        /*
        for (int i = 0; i < ptr.getCnn().Count; i++)
        {
            ptr.getCnn()[i].Item1.setCnn(ptr, ptr.getCnn()[i].Item2);
        }
        */
    }
    
}
