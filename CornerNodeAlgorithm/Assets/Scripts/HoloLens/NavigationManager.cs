using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationManager : MonoBehaviour
{
    [SerializeField] private GameObject startObject;
    [SerializeField] private GameObject targetObject;
    [SerializeField] private GameObject tmp;
    [SerializeField] private Text text;
    [SerializeField, Range(0,2)] private float tileSize;
    [SerializeField] private string jsonMapDataName;

    private Cell[,] mapData;
    CornerGenerator cGene;
    private CornerNodeAlgorithmV2 CNA;
    private List<PathNode> pNodeList;
    private AStarAlgorithmV2 aStarAlgorithmV2 = new AStarAlgorithmV2();

    private PathNode startNode;
    private PathNode targetNode;
    private List<Vector3> pathListV2;
    private List<(int, int)> wallList;
    private int width, height;

    public void OnClickMapUpdate()
    {
        HttpMapDownloadAPI.DownloadFile();
        jsonMapInitialize();
        cornerNodeV2Start(); //Node Create start
        if (mapData != null) text.text = "Complete!";
    }

    public void OnClickNavigation()
    {
        aStarConfig();
        aStarAlgorithmV2Start();
        gameObject.GetComponent<LineRenderer>().SetVertexCount(pathListV2.Count);
        for (int i = 0; i < pathListV2.Count; i++)
        {
            gameObject.GetComponent<LineRenderer>().SetPosition(i, (pathListV2[i] * 0.05f) + new Vector3(0, -1.5f, 0));
        }
        if (pathListV2.Count != 0) text.text = "ASTAR!";
    }
    void Start()
    {
        Camera.main.transform.position = new Vector3(67.0f, 0, 11.0f);

    }
    void Update()
    {
        
    }
    void jsonMapInitialize()
    {
        JsonMapLoader jsonMapLoader = new JsonMapLoader();
        jsonMapLoader.start(jsonMapDataName);
        mapData = jsonMapLoader.MapData;
        wallList = jsonMapLoader.WallList;
        width = jsonMapLoader.Width;
        height = jsonMapLoader.Height;
    }
    private void cornerNodeV2Start() // Start CNA V2
    {
        CNA = new CornerNodeAlgorithmV2();
        CNA.setMap(mapData);
        CNA.start(wallList);
        pNodeList = CNA.getPNodeList();
    }

    private void aStarConfig() // A* Algorithm config
    {
        startNode = new PathNode((int)(startObject.transform.position.x / tileSize),
            (int)(startObject.transform.position.y / tileSize));
        targetNode = new PathNode((int)(targetObject.transform.position.x / tileSize),
            (int)(targetObject.transform.position.y / tileSize));
    }
    private void aStarAlgorithmV2Start()
    {
        pathListV2 = aStarAlgorithmV2.start(startNode, targetNode, pNodeList, mapData);
    }
}
