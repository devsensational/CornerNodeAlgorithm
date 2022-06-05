using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NavigationManager : MonoBehaviour
{
    [SerializeField] private GameObject startObject;
    [SerializeField] private GameObject targetObject;
    [SerializeField] private GameObject guideMap;
    [SerializeField] private GameObject MiniMapCanvas;
    [SerializeField] private GameObject NavigationCanvas;
    [SerializeField] private GameObject NavigationController;
    [SerializeField] private GameObject MiniMapLineRenderer;
    [SerializeField, Range(0,2)] private float tileSize;
    [SerializeField] private string jsonMapDataName;
    [SerializeField] private TextMeshProUGUI UICoordinateX;
    [SerializeField] private TextMeshProUGUI UICoordinateZ;
    [SerializeField] private TextMeshProUGUI UIrotateY;
    [SerializeField] private TextMeshProUGUI status;

    private Cell[,] mapData;
    private CornerNodeAlgorithmV2 CNA;
    private List<PathNode> pNodeList;
    private AStarAlgorithmV2 aStarAlgorithmV2;

    private PathNode startNode;
    private PathNode targetNode;
    private List<Vector3> pathListV2;
    private List<(int, int)> wallList;
    public int width, height;

    private bool isGuideMapOn = true;
    private bool isMiniMapOn = true;
    private bool isNavigationMapOn = false;
    public void OnClickMapUpdate()
    {
        HttpMapDownloadAPI.DownloadFile();
        jsonMapInitialize();
        cornerNodeV2Start(); //Node Create start
        if (mapData != null) status.text = "Complete!";
    }

    public void OnClickNavigationMenu()
    {
        if(!isNavigationMapOn) 
        { 
            NavigationCanvas.SetActive(true);
            NavigationController.SetActive(true);
            isNavigationMapOn = true;
        }
        else
        {
            NavigationCanvas.SetActive(false);
            NavigationController.SetActive(false);
            isNavigationMapOn = false;

        }
    }

    public void OnClickNavigationStart()
    {
        navigationStart();
        NavigationCanvas.SetActive(false);
        NavigationController.SetActive(false);
        isNavigationMapOn = false;
    }

    public void OnClickSimulatorDebug()
    {
        OnClickMapUpdate();
        navigationStart();

    }

    public void OnClickMiniMap()
    {
        if (isMiniMapOn) { MiniMapCanvas.SetActive(false); isMiniMapOn = false; }
        else { MiniMapCanvas.SetActive(true); isMiniMapOn = true; }
    }

    public void OnClickGuideMap()
    {
        if (isGuideMapOn) { guideMap.GetComponent<Renderer>().enabled = false; isGuideMapOn = false; }
        else { guideMap.GetComponent<Renderer>().enabled = true; isGuideMapOn = true; }

    }

    void Start()
    {
        Camera.main.transform.position = new Vector3(99.0f, 0, 15.0f);

    }
    void Update()
    {
        UICoordinateX.text = Camera.main.transform.position.x.ToString();
        UICoordinateZ.text = Camera.main.transform.position.z.ToString();
        UIrotateY.text = Camera.main.transform.rotation.y.ToString();
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

    private void navigationStart()
    {
        List<PathNode> tmp = pNodeList.ToList();
        aStarConfig();
        aStarAlgorithmV2Start();
        gameObject.GetComponent<LineRenderer>().SetVertexCount(pathListV2.Count);
        MiniMapLineRenderer.GetComponent<LineRenderer>().SetVertexCount(pathListV2.Count);
        for (int i = 0; i < pathListV2.Count; i++)
        {
            gameObject.GetComponent<LineRenderer>().SetPosition(i, (pathListV2[i] * tileSize) + new Vector3(0, -2.0f, 0));
            MiniMapLineRenderer.GetComponent<LineRenderer>().SetPosition(i, (pathListV2[i] * tileSize) + new Vector3(0, 202.0f, 0));
        }
        if (pathListV2.Count != 0) status.text = "ASTAR!";
        pNodeList = tmp;
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
        startNode = new PathNode((int)(startObject.transform.position.x / tileSize),(int)(startObject.transform.position.z / tileSize));
        //startNode = new PathNode((int)(Camera.main.transform.position.x / tileSize), (int)(Camera.main.transform.position.z / tileSize));
        targetNode = new PathNode((int)(targetObject.transform.position.x / tileSize),
            (int)(targetObject.transform.position.z / tileSize));
    }
    private void aStarAlgorithmV2Start()
    {
        aStarAlgorithmV2 = new AStarAlgorithmV2();
        pathListV2 = aStarAlgorithmV2.start(startNode, targetNode, pNodeList, mapData);
    }
}
