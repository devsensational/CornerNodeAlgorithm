using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerGenerator : AbstractConerGenerator
{
    Node[,] map;
    int[,] direction = { { 1, 0 }, { 0, -1 }, { -1, 0 }, { 0, 1 } };
    int selection = 0;
    int ptrX = 0, ptrY = 0;

    public override void setMap(Node[,] map)
    {
        this.map = map;
        //throw new System.NotImplementedException();
    }

    private void cornerGene()
    {
        if (findStart())
        {
            //Map에 벽 존재 X
            return;
        }

        int startX = ptrX;
        int startY = ptrY;
        int cnt = 0;
        Debug.Log("PtrX = " + ptrX + " ptrY = " + ptrY);
        Debug.Log("startX = " + startX + " startY = " + startY);
        do
        {
            Debug.Log(cnt++);
            if (ptrX + direction[selection, 0] != Constants.WIDTH && ptrY + direction[selection, 1] != Constants.HEIGHT)
            {
                ptrX = ptrX + direction[selection, 0];
                ptrY = ptrY + direction[selection, 1];
            }

            if (map[ptrX + direction[selection, 0], ptrY + direction[selection, 1]].Type == 1)
            {
                continue;
            }
            else if (map[ptrX + direction[selection, 0], ptrY + direction[selection, 1]].Type == 2)
            {
                dirSelection();
            }
            else
            {
                map[ptrX, ptrY].Type = 3;
                dirSelection();
            }
        } while (ptrX != startX || ptrY != startY);
    }

    private bool findStart()
    {
        while (map[ptrX, ptrY].Type != 1)
        {
            Debug.Log("찾기");
            ptrX++;
            if(ptrX == Constants.WIDTH)
            {
                ptrX = 0;
                ptrY++;
            }

            if(ptrX == Constants.WIDTH - 1 && ptrY == Constants.HEIGHT - 1)
            {
                Debug.Log("못찾음");
                return true;
            }
        }
        Debug.Log("찾음" + ptrX + "  " + ptrY);
        ptrX++;
        return false;
    }

    private void dirSelection()
    {
        Debug.Log("방향선택 수행");
        int right = selection + 1 > 3 ? 0 : selection + 1;
        int left = selection - 1 < 0 ? 3 : selection - 1;
        if (map[ptrX + direction[right, 0], ptrY + direction[right, 1]].Type == 1)
            selection = right;
        else if (map[ptrX + direction[left, 0], ptrY + direction[left, 1]].Type == 1)
            selection = left;
    }

    public void geneStart()
    {
        cornerGene();
    }
}
