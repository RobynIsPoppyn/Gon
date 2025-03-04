using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    public bool isGrounded;

    void OnTriggerStay(Collider collider){
        if (collider.tag.Equals("Ground") || collider.tag.Equals("Button")){
            
            isGrounded = true;
        }
    }
    void OnTriggerExit(Collider collider){
        if (collider.tag.Equals("Ground") || collider.tag.Equals("Button")){
           
            isGrounded = false;
        }
    }
    public void Start(){
            transform.GetComponent<MeshRenderer>().enabled = DevMode.GroundedMesh;
        
    }

}
