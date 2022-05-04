using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.WSA;

public class TileRenderer : MonoBehaviour
{
    public GameObject[] tileType;
    public GameObject startObj;
    public GameObject targetObj;

    MapData2D mapGene;
    CornerGenerator cGene;
    private CornerNodeAlgorithmV2 CNA;
    private List<PathNode> pNodeList;
    Cell[,] mapData;
    private AStarAlgorithm aStarAlgorithm = new AStarAlgorithm();

    private PathNode startNode;
    private PathNode targetNode;
    private List<PathNode> pathList;

    private int width, height;
    private float tileWid;
    private float tileHei;

    void Start() //오브젝트가 생기는 즉시 실행하는 구분(like 생성자)
    {
        //mapInit();
        //nodeGene(); //Node Create start
        jsonMapInitialize();
        cornerNodeV2Start();
        renderMap();
        //renderConnectV2();
        //aStarConfig();
        //pathList = aStarAlgorithm.startPathfinding(startNode, targetNode, pNodeList, mapData);
    }

    private void cornerNodeV2Start() // Start CNA V2
    {
        CNA = new CornerNodeAlgorithmV2();
        CNA.setMap(mapData);
        CNA.start(5, 2);
    }
    
    private void aStarConfig() // A* Algorithm config
    {
        startNode = new PathNode((int) (startObj.transform.position.x / tileWid),
            (int) (startObj.transform.position.y / tileHei));
        targetNode = new PathNode((int) (targetObj.transform.position.x / tileWid),
            (int) (targetObj.transform.position.y / tileHei));
    }

    private void Update() // Unity Update
    {
        //layDebug();
        //pathLayDebug();
    }

    void renderConnect()
    {
        pNodeList = cGene.getPNodeList();
    }

    void renderConnectV2()
    {
        pNodeList = CNA.getPNodeList();
    }

    void pathLayDebug() //Show Path
    {
        tileWid = tileType[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        tileHei = tileType[0].GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        for (int i = 0; i < pathList.Count - 1; i++)
        {
            Debug.DrawLine(pathList[i].getPos() * tileWid, pathList[i + 1].getPos() * tileWid, Color.green);
        }
    }

    void mapInit() // 
    {
        mapGene = new MapData2D();
        mapGene.virtualMapGenerate();
        mapData = mapGene.getMap();
    }

    void jsonMapInitialize()
    {
        JsonMapLoader jsonMapLoader = new JsonMapLoader();
        jsonMapLoader.start();
        mapData = jsonMapLoader.MapData;
        width = jsonMapLoader.Width;
        height = jsonMapLoader.Height;
    }

    void nodeGene()
    {
        cGene = new CornerGenerator();
        cGene.setMap(mapData);
        cGene.geneStart();
    }

    void renderMap()
    {
        for (int ptrY = 0; ptrY < height; ptrY++)
        {
            for (int ptrX = 0; ptrX < width; ptrX++)
            {
                geneTile(mapData[ptrX, ptrY].Type, ptrX, ptrY);
            }
        }
    }

    void geneTile(int type, int ptrX, int ptrY)
    {
        tileWid = tileType[type].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        tileHei = tileType[type].GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        GameObject tile = Instantiate(tileType[type]);
        tile.name = "X : " + ptrX + " / Y : " + ptrY;

        tile.transform.position = new Vector3(ptrX * tileWid, ptrY * tileHei, 0);
        tile.transform.name = "X = " + ptrX + " /Y = " + ptrY;
    }

    void layDebug()
    {
        tileWid = tileType[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        tileHei = tileType[0].GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        for (int i = 0; i < pNodeList.Count; i++)
        {
            for (int j = 0; j < pNodeList[i].getCnn().Count; j++)
            {
                Debug.DrawLine(new Vector3(pNodeList[i].getX() * tileWid, pNodeList[i].getY() * tileHei, 0),
                    new Vector3(pNodeList[i].getCnn()[j].Item1.getX() * tileWid,
                        pNodeList[i].getCnn()[j].Item1.getY() * tileHei, 0), Color.red);
            }
        }
    }
}