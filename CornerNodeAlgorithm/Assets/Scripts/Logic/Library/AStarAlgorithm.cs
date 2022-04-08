using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AStarAlgorithm
{
    private List<AStarNode> openList = new List<AStarNode>();
    private List<AStarNode> closeList = new List<AStarNode>();
    private PathNode startNode;
    private PathNode targetNode;
    private List<PathNode> pNodeList;
    private Cell[,] map;
    public void startPathfinding(PathNode _startNode, PathNode _targetNode, List<PathNode> _pNodeList, Cell[,] _map)
    {
        //allocate
        startNode = _startNode;
        targetNode = _targetNode;
        pNodeList = _pNodeList;
        map = _map;
        
        Debug.Log("startNode pos = " + startNode.getPos());
        CheckWall checkWall = new CheckWall(map);
        for (int i = 0; i < pNodeList.Count - 1; i++)
        {
            checkWall.chkWall(startNode, pNodeList[i]);
        }
        pNodeList.Add(targetNode);
        for (int i = 0; i < pNodeList.Count - 1; i++)
        {
            checkWall.chkWall(targetNode, pNodeList[i]);
        }

        AStarNode ptr = new AStarNode(startNode, 0, 0, null);
        closeList.Add(ptr);
        //aStarAlgorithm(ptr);
        Tuple<PathNode, Vector3> nodePtr = ptr.GetNode.getCnn()[0];
        AStarNode temp = new AStarNode(nodePtr.Item1, Vector3.Magnitude(new Vector3(targetNode.getX(), targetNode.getY()) - new Vector3(nodePtr.Item1.getX(), nodePtr.Item1.getY())), Vector3.Magnitude(nodePtr.Item2), null);
        Debug.Log(temp);

    }

    private void aStarAlgorithm(AStarNode ptr)
    {
        while (ptr.GetNode != targetNode)
        {
            for (int i = 0; i <= ptr.GetNode.getCnn().Count; i++)
            {
                if (ptr.ParentNode == null || ptr.ParentNode.GetNode != ptr.GetNode.getCnn()[i].Item1)
                {
                    Tuple<PathNode, Vector3> nodePtr = ptr.GetNode.getCnn()[i];
                    AStarNode temp = new AStarNode(nodePtr.Item1, Vector3.Magnitude(new Vector3(targetNode.getX(), targetNode.getY()) - new Vector3(nodePtr.Item1.getX(), nodePtr.Item1.getY())), Vector3.Magnitude(nodePtr.Item2), null);
                    //if(openList.Contains(ptr.GetNode.getCnn()[i].Item1))
                    
                }
            }
        }
    }

    private void setCloseList(AStarNode ptr)
    {
        //
    }
}