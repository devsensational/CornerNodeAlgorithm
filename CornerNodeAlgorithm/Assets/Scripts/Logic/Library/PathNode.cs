using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PathNode // 
{
    private int x;
    private int y;
    private List<PathNode> cnnList = new List<PathNode>();

    public PathNode(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    
    public List<PathNode> getCnn()
    {
        return cnnList;
    }

    public void setCnn(PathNode node)
    {
        cnnList.Add(node);
    }
}
