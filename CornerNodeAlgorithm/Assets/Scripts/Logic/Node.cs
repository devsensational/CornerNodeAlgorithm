using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    int type = 2; //���� ����, (0 = ���� ����, 1 = ��, 2 = ���� ����, 3 = �ڳʳ��)
    int stat = 0; //����� ����, ��) ȭ��� ���, ���� �� 


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
