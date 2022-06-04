using System;
using System.Collections.Generic;
using UnityEngine;

public class PathNode // 
{
    private int x;
    private int y;
    private Vector3 pos;
    private int status = 0; // 0 = NOT, 1 = OPEN LIST, 2 = CLOSE LIST
    private double fScore = -1.0;
    private AStarNode aStarNode;

    private List<Tuple<PathNode, Vector3>> cnnList = new List<Tuple<PathNode, Vector3>>();

    public PathNode(int x, int y)
    {
        this.x = x;
        this.y = y;
        pos = new Vector3(x, y);
    }
    public int getX()
    {
        return x;
    }
    public int getY()
    {
        return y;
    }
    public Vector3 getPos()
    {
        return pos;
    }
    public List<Tuple<PathNode, Vector3>> getCnn()
    {
        return cnnList;
    }
    public void setCnn(PathNode node, Vector3 v)
    {
        cnnList.Add(Tuple.Create(node,v));
    }
    public int Status
    {
        get => status;
        set => status = value;
    }

    public double FScore
    {
        get => fScore;
        set => fScore = value;
    }

    public AStarNode AStarNode
    {
        get => aStarNode;
        set => aStarNode = value;
    }
}
