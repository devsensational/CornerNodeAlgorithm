using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    int type = 2; //벽의 종류, (0 = 열린 공간, 1 = 벽, 2 = 닫힌 공간, 3 = 코너노드)
    int stat = 0; //노드의 상태, 예) 화재로 폐쇄, 정상 등 


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
