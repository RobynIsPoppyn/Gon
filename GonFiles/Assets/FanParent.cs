using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanParent : MonoBehaviour
{
    Fan windZone; 
    public bool FanOn{get; private set;}
    public void Start(){
        windZone = transform.GetChild(0).GetComponent<Fan>();

    }

    public void Toggle(){
        FanOn = !FanOn;
        windZone.enabled = FanOn;
    }
}
