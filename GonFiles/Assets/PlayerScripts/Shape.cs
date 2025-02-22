using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public float Speed; 
    public Rigidbody rb; 
    public Grounded grounded;



    public void Start(){
        rb = transform.parent.GetComponent<Rigidbody>(); 
        grounded = GameObject.Find("1_Grounded").GetComponent<Grounded>();
    }
    public void Move(Vector3 direction){
        rb.Move(rb.position + (direction * Speed), rb.rotation); 
    }

    public virtual void Action(){
        print("Default action, did nothing");
    }

}
