using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    int type = 2; 
    int stat = 0; 

    public int Type
    {
        get { return type; }
        set { type = value; }
    }
    public int Stat
    {
        get { return stat; }
        set { stat = value; }
    }
}
