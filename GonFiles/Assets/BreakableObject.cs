using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : ShiftZ
{
    void OnCollisionEnter(Collision collision){
        if (collision.collider.tag == "Player"){
            
            Transform temp = collision.collider.transform;
            while (!temp.name.Equals("Player")){
                temp = temp.parent;
                if (temp == null) return;
            }
            
            if (temp.GetComponent<PlayerMovement>().capableOfBreaking){
                if (transform.GetComponent<ShiftZ>()){
                    ShiftZ.allShiftZ.Remove(transform.GetComponent<ShiftZ>());
                }
                transform.GetChild(0).gameObject.SetActive(true);
                //transform.GetChild(0).GetComponent<ParticleSystem>().Play();
                transform.GetChild(0).parent = null;
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}