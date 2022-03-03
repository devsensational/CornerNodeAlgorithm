using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRenderer : MonoBehaviour
{
    public GameObject[] tileType;

    MapData2D mapGene;
    CornerGenerator cGene;
    Cell[,] mapData;

    void Start()
    {
        mapInit();
        nodeGene();
        renderMap();
    }
    
    void mapInit()
    {
        mapGene = new MapData2D();
        mapGene.virtualMapGenerate();
        mapData = mapGene.getMap();
    }

    void nodeGene()
    {
        cGene = new CornerGenerator();
        cGene.setMap(mapData);
        cGene.geneStart();
    }

    void renderMap()
    {
        for(int ptrY = 0; ptrY < Constants.HEIGHT - 1; ptrY++)
        {
            for(int ptrX = 0; ptrX < Constants.WIDTH - 1; ptrX++)
            {
                geneTile(mapData[ptrX, ptrY].Type, ptrX, ptrY);
            }
        }
    }

    void geneTile(int type, int ptrX, int ptrY)
    {
        float tileWid = tileType[type].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        float tileHei = tileType[type].GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        GameObject tile = Instantiate(tileType[type]);
        tile.name = "X : " + ptrX + " / Y : " + ptrY;

        tile.transform.position = new Vector3(ptrX * tileWid, ptrY * tileHei, 1);
        tile.transform.name = "X = " + ptrX + " /Y = " + ptrY;
    }
}
