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
    private Vector3 m_saveScale;

    public void Start(){
        windZone = transform.GetChild(0).GetComponent<Fan>();
        m_saveScale = transform.GetChild(0).localScale;
    }
    
    private float m_timePass = 0f;
    private bool m_reset = false;
    public void Update(){
        if (intervalOn != 0 && intervalOff != 0 && !m_reset){
            m_timePass += Time.deltaTime;

            if (m_timePass > intervalOn && FanOn){
               m_reset = true;
                Toggle();
                //AudioManager.instance.playSFX(AudioManager.instance.fanOn);
            }
            else if (m_timePass > intervalOff && !FanOn){
               m_reset = true;
               // AudioManager.instance.playSFX(AudioManager.instance.fanOff);
                Toggle();
            }
        }
    }
    public void ParticlesOn(){
        windZone.ps.Play();
    }
    public void ParticlesOff(){
        windZone.ps.Stop();
    }

    public void Toggle(){
        
        if (FanOn){
            anim.SetTrigger("turnOn");
            windZone.ps.Play();
            print("Starting wind");
        }
        else {
            anim.SetTrigger("turnOff");
            windZone.ps.Stop();
            print("Stopping wind");
        }

        
    }

    public void TurnOn(){
        m_timePass = 0;
       m_reset = false;
        FanOn = false;
        windZone.transform.localScale = m_saveScale;
        
    }
    public void TurnOff(){
       m_reset = false;
        m_timePass = 0;
        FanOn = true;
        windZone.transform.localScale = new Vector3(0, 0, 0);
        
    }
}
