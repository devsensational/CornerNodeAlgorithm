using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class ImageRotator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CameraObject;
    private float startX;
    private float startZ;
    //int direction = 1;
    void Start()
    {
        startX = CameraObject.transform.position.x;
        startZ = CameraObject.transform.position.z;
        //Timer timer = new Timer();
        //timer.Interval = 2000;
        //timer.Elapsed += (s, e) =>
        //{
        //    var random = new System.Random(DateTime.Now.Millisecond);
        //    var randomInt = random.Next(1, 3);
        //    if (randomInt == 1)
        //        direction = -1;
        //    if (randomInt == 2)
        //        direction = 1;
        //    Debug.Log(direction+ $"{randomInt}");
        //};
        //timer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Transform cameraTransform = Camera.main.transform;
        var cameraY = cameraTransform.rotation.eulerAngles.y;
        CameraObject.transform.rotation = Quaternion.Euler(90, (float)cameraY, CameraObject.transform.rotation.z);
        CameraObject.transform.position = new Vector3(cameraTransform.position.x, CameraObject.transform.position.y, cameraTransform.position.z);
    }
}
