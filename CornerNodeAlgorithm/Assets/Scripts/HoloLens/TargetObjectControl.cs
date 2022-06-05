using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObjectControl : MonoBehaviour
{
    public GameObject targetObject;

    public void ClickOnMoveLeft()
    {
        targetObject.transform.position = targetObject.transform.position + new Vector3(-3, 0, 0);
    }

    public void ClickOnMoveRight()
    {
        targetObject.transform.position = targetObject.transform.position + new Vector3(3, 0, 0);

    }
    public void ClickOnMoveUp()
    {
        targetObject.transform.position = targetObject.transform.position + new Vector3(0, 0, 3);

    }
    public void ClickOnMoveDown()
    {
        targetObject.transform.position = targetObject.transform.position + new Vector3(0, 0, -3);
    }
}
