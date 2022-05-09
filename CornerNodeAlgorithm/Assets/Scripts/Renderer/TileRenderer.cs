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
    private List<(int, int)> wallList;

    private int width, height;
    [Range(0,2)]
    public float tileWid;
    [Range(0,2)]
    public float tileHei;
    
    void Start() // Unity Start
    {
        //mapInit(); // Old map initialize
        //nodeGene(); // Old Node generator
        jsonMapInitialize();
        cornerNodeV2Start(); //Node Create start
        renderMap();
        renderConnectV2();
        aStarConfig();
        pathList = aStarAlgorithm.startPathfinding(startNode, targetNode, pNodeList, mapData);
    }
    
    private void Update() // Unity Update
    {
        layDebug();
        pathLayDebug();
    }

    private void cornerNodeV2Start() // Start CNA V2
    {
        CNA = new CornerNodeAlgorithmV2();
        CNA.setMap(mapData);
        CNA.start(wallList);
    }
    
    private void aStarConfig() // A* Algorithm config
    {
        startNode = new PathNode((int) (startObj.transform.position.x / tileWid),
            (int) (startObj.transform.position.y / tileHei));
        targetNode = new PathNode((int) (targetObj.transform.position.x / tileWid),
            (int) (targetObj.transform.position.y / tileHei));
    }

    void renderConnectV2()
    {
        pNodeList = CNA.getPNodeList();
    }

    void pathLayDebug() //Show Path
    {
        //tileWid = tileType[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        //tileHei = tileType[0].GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        for (int i = 0; i < pathList.Count - 1; i++)
        {
            Debug.DrawLine(pathList[i].getPos() * tileWid, pathList[i + 1].getPos() * tileWid, Color.green);
        }
    }

    void jsonMapInitialize()
    {
        JsonMapLoader jsonMapLoader = new JsonMapLoader();
        jsonMapLoader.start();
        mapData = jsonMapLoader.MapData;
        wallList = jsonMapLoader.WallList;
        width = jsonMapLoader.Width;
        height = jsonMapLoader.Height;
    }


    void geneTile(int type, int ptrX, int ptrY)
    {
        
        //tileWid = tileType[type].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        //tileHei = tileType[type].GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        
        GameObject tile = Instantiate(tileType[type]);
        tile.name = "X : " + ptrX + " / Y : " + ptrY;

        tile.transform.position = new Vector3(ptrX * tileWid, ptrY * tileHei, 0);
        tile.transform.name = "X = " + ptrX + " /Y = " + ptrY;
    }

    void layDebug()
    {
        //tileWid = tileType[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        //tileHei = tileType[0].GetComponent<SpriteRenderer>().sprite.bounds.size.y;
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
    
    void mapInit() // 
    {
        mapGene = new MapData2D();
        mapGene.virtualMapGenerate();
        mapData = mapGene.getMap();
    }

    void renderConnect()
    {
        pNodeList = cGene.getPNodeList();
    }
}