using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public float Speed; 
    public Rigidbody rb; 
    public Grounded grounded;

    public Animator anim; 



    public void Start(){
        rb = transform.parent.GetComponent<Rigidbody>(); 
        grounded = GameObject.Find("1_Grounded").GetComponent<Grounded>();
        anim = transform.parent.GetComponent<Animator>();
    }
    public virtual void Move(Vector3 direction, bool curr3D){
        rb.Move(rb.position + (check3D(direction, curr3D) * Speed), rb.rotation); 
    }

    public virtual void Action(){
        print("Default action, did nothing");
    }

    public virtual void Close(){
        print("Default close animation");
    }

    public virtual void Open(){
        print("Default open animation");
    }

    public Vector3 check3D(Vector3 direction, bool curr3D){
        if (!curr3D) {
            direction = new Vector3(direction.x, direction.y, 0); 
        }
        return direction;
    }

}
