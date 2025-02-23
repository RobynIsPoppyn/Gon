using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    public bool isGrounded;

    void OnTriggerEnter(Collider collider){
        if (collider.tag.Equals("Ground")){
            print("Grounded");
            isGrounded = true;
        }
    }
    void OnTriggerExit(Collider collider){
        if (collider.tag.Equals("Ground")){
            print("UnGrounded");
            isGrounded = false;
        }
    }

}
