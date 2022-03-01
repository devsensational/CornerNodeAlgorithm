using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Constants
{
    public const int WIDTH = 100;
    public const int HEIGHT = 100;
}
public abstract class AbstractMapData2D {
    public abstract Cell[,] getMap();
}
