using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanParent : MonoBehaviour
{
    Fan windZone; 

    public float intervalOn = 2f;
    public float intervalOff = 2f;
    public bool FanOn{get; private set;}
    public Animator anim; 
    public void Start(){
        windZone = transform.GetChild(0).GetComponent<Fan>();

    }
    
    private float m_timePass = 0f;
    private bool m_reset = false;
    public void Update(){
        if (intervalOn != 0 && intervalOff != 0 && !m_reset){
            m_timePass += Time.deltaTime;

            if (m_timePass > intervalOn && FanOn){
               m_reset = true;
                Toggle();
                print("Turn On");
            }
            else if (m_timePass > intervalOff && !FanOn){
               m_reset = true;
                print("Turn Off");
                Toggle();
            }
        }
    }

    public void Toggle(){
        
        if (FanOn){
            anim.SetTrigger("turnOn");
        }
        else anim.SetTrigger("turnOff");
        
    }

    public void TurnOn(){
        m_timePass = 0;
       m_reset = false;
        FanOn = false;
        windZone.gameObject.SetActive(true);
    }
    public void TurnOff(){
       m_reset = false;
        m_timePass = 0;
        FanOn = true;
        windZone.gameObject.SetActive(false);
    }
}
