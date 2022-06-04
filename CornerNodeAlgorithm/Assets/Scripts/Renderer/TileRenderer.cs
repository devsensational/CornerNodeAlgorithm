using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class TileRenderer : MonoBehaviour
{
    public GameObject[] tileType;
    public GameObject startObj;
    public GameObject targetObj;
    public GameObject nodeCube;
    public GameObject mainCamera;
    public Text text;

    MapData2D mapGene;
    CornerGenerator cGene;
    private CornerNodeAlgorithmV2 CNA;
    private List<PathNode> pNodeList;
    private Cell[,] mapData;
    private AStarAlgorithm aStarAlgorithm = new AStarAlgorithm();
    private AStarAlgorithmV2 aStarAlgorithmV2 = new AStarAlgorithmV2();
    
    private PathNode startNode;
    private PathNode targetNode;
    private List<PathNode> pathList;
    private List<Vector3> pathListV2;
    private List<(int, int)> wallList;

    private List<Vector3> pathListForComparison;
    
    private int width, height;
    [Range(0,2)]
    public float tileWid;
    [Range(0,2)]
    public float tileHei;
    public string jsonFileName;

    public bool onOldPathLayDebug;
    public bool onPathLayDebug;
    public bool onPathLayForComparison;
    public bool onNodeNetworkDebug;
    public bool onStartNodeConnectoin;

    private System.Diagnostics.Stopwatch stopwatch = new Stopwatch();
    void Start() // Unity Start
    {
        //mapInit(); // Old map initialize
        //nodeGene(); // Old Node generator
        HttpMapDownloadAPI.DownloadFile();
        jsonMapInitialize();

        if (mapData != null) { text.text = "Done!"; }
        else { text.text = "null";  }
        cornerNodeV2Start(); //Node Create start
        renderConnectV2();
        aStarConfig();
        
        //pathList = aStarAlgorithm.startPathfinding(startNode, targetNode, pNodeList, mapData); // old
        aStarAlgorithmV2Start();
        //comparisonStart();

        //renderMap(); //Render map tiles
        //mainCamera.transform.position = new Vector3(284.2f ,0 ,47.2f);

        gameObject.GetComponent<LineRenderer>().SetVertexCount(pathListV2.Count);
        for (int i = 0; i < pathListV2.Count; i++)
        {
            GameObject cube = Instantiate(nodeCube);
            gameObject.GetComponent<LineRenderer>().SetPosition(i, pathListV2[i] * tileWid);
            //cube.transform.position = pathListV2[i] * tileWid;
        }
    }
    
    private void Update() // Unity Update
    {
        if(onNodeNetworkDebug) layDebug();
        //if(onOldPathLayDebug) pathLayDebug(); //Old Debug
        if(onPathLayDebug) pathLayDebugForComparison(pathListV2, Color.green);
        //if(onPathLayForComparison) pathLayDebugForComparison(pathListForComparison, Color.magenta);
        if(onStartNodeConnectoin) startNodeConnectionDebug();
    }

    private void startNodeConnectionDebug()
    {
        for (int i = 0; i < startNode.getCnn().Count; i++)
        {
            Debug.Log("vector = " + startNode.getCnn()[i].Item2.magnitude);
            Debug.DrawLine(startNode.getCnn()[i].Item2 * tileWid, startNode.getCnn()[i].Item2 * tileWid, Color.red);
        }
    }
    private void aStarAlgorithmV2Start()
    {
        pathListV2 = aStarAlgorithmV2.start(startNode, targetNode, pNodeList, mapData);
    }
    private void comparisonStart()
    {
        AStarAlgorithmForComparison algorithmForComparison = new AStarAlgorithmForComparison();
        pathListForComparison = algorithmForComparison.start((int)(startObj.transform.position.x / tileWid), (int)(startObj.transform.position.y/ tileHei),
            (int)(targetObj.transform.position.x/ tileWid), (int)(targetObj.transform.position.y/ tileHei), mapData);

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
            Debug.DrawLine(pathList[i].getPos() * tileWid, pathList[i + 1].getPos() * tileWid, Color.magenta);
        }
    }

    void pathLayDebugForComparison(List<Vector3> pathList, Color color) //Show Path for comparison
    {
        for (int i = 0; i < pathList.Count - 1; i++)
        {
            Debug.DrawLine(pathList[i] * tileWid, pathList[i + 1] * tileWid, color);
        }
    }

    void jsonMapInitialize()
    {
        JsonMapLoader jsonMapLoader = new JsonMapLoader();
        jsonMapLoader.start(jsonFileName);
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