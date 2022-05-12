using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UnityEditorInternal;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class AStarAlgorithm
{
    private List<AStarNode> openList = new List<AStarNode>();
    private List<AStarNode> closeList = new List<AStarNode>();
    private List<PathNode> pathList = new List<PathNode>();
    private PathNode startNode;
    private PathNode targetNode;
    private List<PathNode> pNodeList;
    private Cell[,] map;
    private CheckWall checkWall;
    
    public List<PathNode> startPathfinding(PathNode _startNode, PathNode _targetNode, List<PathNode> _pNodeList, Cell[,] _map)
    {
        //Stopwatch start
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        
        //Allocate
        startNode = _startNode;
        targetNode = _targetNode;
        pNodeList = _pNodeList;
        map = _map;
        checkWall = new CheckWall(map);
        openList.Clear();
        closeList.Clear();
        pathList.Clear();
        
        cnnNode(startNode);
        cnnNode(targetNode);

        AStarNode firstCLoseNode = new AStarNode(startNode, 0, 0, null);
        closeList.Add(firstCLoseNode);
        aStarAlgorithm(firstCLoseNode);
        
        //Stopwatch stop
        stopwatch.Stop();
        Debug.Log("Pathfinding Done!! Time : " + stopwatch.Elapsed.ToString());
        return pathList;
    }

    private void cnnNode(PathNode ptr)
    {
        pNodeList.Add(ptr);
        for (int i = 0; i < pNodeList.Count - 1; i++)
        {
            checkWall.chkWall(ptr, pNodeList[i]);
            
        }
        for (int i = 0; i < ptr.getCnn().Count; i++)
        {
            ptr.getCnn()[i].Item1.setCnn(ptr, ptr.getCnn()[i].Item2);
        }
    }

    private void aStarAlgorithm(AStarNode ptr)
    {
        do
        {
            ptr = addCloseList(addOpenList(ptr));
            if (ptr == null)
            {
                Debug.Log("failed");
                break;
            } //failed

            if (ptr.GetNode == targetNode)
            {
                while (ptr.GetNode != startNode)
                {
                    pathList.Add(ptr.GetNode);
                    ptr = ptr.ParentNode;
                }
                pathList.Add(startNode); 
                Debug.Log("done");
                break;
            } //done
        } while (openList.Count != 0);
        if(openList.Count == 0) Debug.Log("OpenList is empty");
        
    }

    private AStarNode addOpenList(AStarNode ptr)
    {
        for (int i = 0; i < ptr.GetNode.getCnn().Count; i++)
        {
            Tuple<PathNode, Vector3> nodePtr = ptr.GetNode.getCnn()[i];
            AStarNode tmpPtr = createNewAStarNode(nodePtr, ptr);
            if (ptr.ParentNode == null || tmpPtr.GetNode != ptr.ParentNode.GetNode)
            {
                if (closeList.Find(x => x.GetNode == tmpPtr.GetNode) != null)
                    continue;
                AStarNode comp = openList.Find(x => x.GetNode == tmpPtr.GetNode);
                if (comp != null && comp.FScore < tmpPtr.FScore)
                {
                    openList.Remove(comp);
                }
                openList.Add(tmpPtr);
            }
        }

        AStarNode minPtr = null;
        for (int i = 0; i < openList.Count; i++)
        {
            if (minPtr == null || minPtr.FScore > openList[i].FScore)
                minPtr = openList[i];
        }

        return minPtr;
    }

    private AStarNode createNewAStarNode(Tuple<PathNode, Vector3> nodePtr, AStarNode parentNode)
    {
        return new AStarNode(nodePtr.Item1,
            Vector3.Magnitude(new Vector3(targetNode.getX(), targetNode.getY()) -
                              new Vector3(nodePtr.Item1.getX(), nodePtr.Item1.getY())),
            Vector3.Magnitude(nodePtr.Item2),
            parentNode);
    }
    private AStarNode addCloseList(AStarNode ptr)
    {
        if (ptr == null) return null;
        closeList.Add(ptr);
        openList.Remove(ptr);
        return ptr;
    }
}