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

    public Material[] materials = new Material[2]; //First material is the 2D one
    public MeshRenderer renderer; 

    public PlayerMovement pm; 
    public virtual void Start(){
        pm = GameObject.Find("Player").GetComponent<PlayerMovement>();
        renderer.material = materials[PerspectiveShift.curr3D ? 1 : 0];
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
        renderer.material = materials[0];
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
    }
    public virtual void Switch3D(){
        renderer.material = materials[1];
        rb.constraints = RigidbodyConstraints.None;
    }

    public virtual void FanAffect(Fan origin){
        
    }
    public virtual void FanLeave(Fan origin){
        
    }

}
