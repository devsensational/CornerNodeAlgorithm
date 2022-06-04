using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject mainCamera;
    public Text textX;
    public Text textY;
    public Text textZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textX.text = "x :" + mainCamera.transform.position.x;
        textY.text = "y :" + mainCamera.transform.position.y;
        textZ.text = "z :" + mainCamera.transform.position.z;
    }
}
