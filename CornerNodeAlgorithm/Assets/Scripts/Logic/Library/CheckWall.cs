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

    public void setMapData(Cell[,] map) //set map from CNA
    {
        this.map = map;
    }

    
}