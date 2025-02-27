using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public float Speed; 
    public Rigidbody rb; 
    public Grounded grounded;

    public Animator anim; 
    protected Vector3 _fanPower;



    public virtual void Start(){
        rb = transform.parent.GetComponent<Rigidbody>(); 
        grounded = GameObject.Find("1_Grounded").GetComponent<Grounded>();
        anim = transform.parent.GetComponent<Animator>();
        _fanPower = new Vector3(0, 0, 0);
    }
    public virtual void Move(Vector3 direction, bool curr3D){
        return;
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

    public virtual void Switch2D(){
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
    }
    public virtual void Switch3D(){
        rb.constraints = RigidbodyConstraints.None;
    }

    public void FanAffect(Fan origin){
        print("added fan power");
        _fanPower += new Vector3(origin.XForce, origin.YForce, origin.ZForce);
    }
    public void FanLeave(Fan origin){
        print("subtracted fan power");
        _fanPower -= new Vector3(origin.XForce, origin.YForce, origin.ZForce);
    }

}
