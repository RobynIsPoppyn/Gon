using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    public bool isGrounded;

    void OnTriggerStay(Collider collider){
        if (collider.tag.Equals("Ground")){
            
            isGrounded = true;
        }
    }
    void OnTriggerExit(Collider collider){
        if (collider.tag.Equals("Ground")){
           
            isGrounded = false;
        }
    }
    public void Start(){
            transform.GetComponent<MeshRenderer>().enabled = DevMode.GroundedMesh;
        
    }

}
