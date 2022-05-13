using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarAlgorithmV2
{
    private int startX, startY, targetX, targetY;
    private List<PathNode> pNodeList;
    private List<Vector3> pathList;
    private Cell[,] mapData;

    public List<Vector3> start(int startX, int startY, int targetX, int targetY, List<PathNode> pNodeList, Cell[,] mapData)
    {
        this.startX = startX;
        this.startY = startY;
        this.targetX = targetX;
        this.targetY = targetY;
        this.pNodeList = pNodeList;
        this.mapData = mapData;
        
        return pathList;
    }
}
