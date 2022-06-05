using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapButtonEvent : MonoBehaviour, IMixedRealityTouchHandler
{
    [SerializeField] private Text textUI;

    public void OnTouchStarted(HandTrackingInputEventData eventData)
    {
        //throw new System.NotImplementedException();
        textUI.text = "Click";
        Debug.Log("Touch");
    }

    public void OnTouchCompleted(HandTrackingInputEventData eventData)
    {
        Debug.Log("Touch2");
    }

    public void OnTouchUpdated(HandTrackingInputEventData eventData)
    {
        Debug.Log("Touch3");
    }
}
