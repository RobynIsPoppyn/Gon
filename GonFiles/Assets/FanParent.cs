using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanParent : MonoBehaviour
{
    Fan windZone; 

    public float interval = 2f;
    public bool FanOn{get; private set;}
    public void Start(){
        windZone = transform.GetChild(0).GetComponent<Fan>();

    }
    
    private float m_timePass = 0f;
    public void Update(){
        if (interval != 0){
            m_timePass += Time.deltaTime;

            if (m_timePass > interval){
                m_timePass = 0;
                Toggle();
            }
        }
    }

    public void Toggle(){
        FanOn = !FanOn;
        windZone.gameObject.SetActive(FanOn);
    }
}
