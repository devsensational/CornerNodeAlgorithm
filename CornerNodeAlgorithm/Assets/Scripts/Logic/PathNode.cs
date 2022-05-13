using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PathNode // 
{
    private int x;
    private int y;
    private Vector3 pos;
    private bool isCheck = false;

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
    public bool IsCheck
    {
        get => isCheck;
        set => isCheck = value;
    }
}
