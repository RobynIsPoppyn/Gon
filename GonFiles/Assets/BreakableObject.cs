using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    void OnCollisionEnter(Collision collision){
        if (collision.collider.tag == "Player"){
            
            Transform temp = collision.collider.transform;
            while (!temp.name.Equals("Player")){
                temp = temp.parent;
                if (temp == null) return;
            }
            
            if (temp.GetComponent<PlayerMovement>().capableOfBreaking){
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}