using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public float XForce = 0f; //Positive for right
    public float YForce = 0f;   //Positive for upwards
    public float ZForce = 0f; //Positive for Away from camera
    public ParticleSystem ps;
    public float ParticleSizeDivisor = 40;
    
    
    public void Update(){
        var main = ps.main; 
        main.startLifetime = transform.localScale.y  / ParticleSizeDivisor;
    }

    void OnTriggerEnter(Collider collider){
        if (collider.tag == "Player"){
            
            Transform temp = collider.transform;
            while (!temp.name.Equals("Player")){
                temp = temp.parent;
                if (temp == null) return;
            }
            
            if (temp.GetComponent<PlayerMovement>() != null){
                temp.GetComponent<PlayerMovement>().FanEnter(this);
            }
        }
    }
    void OnTriggerExit(Collider collider){
        if (collider.tag == "Player"){
            
            Transform temp = collider.transform;
            while (!temp.name.Equals("Player")){
                temp = temp.parent;
                if (temp == null) return;
            }
            
            if (temp.GetComponent<PlayerMovement>() != null){
                temp.GetComponent<PlayerMovement>().FanExit(this);
            }
        }
        
    }
}
