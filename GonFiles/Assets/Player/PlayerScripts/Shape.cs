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
    public MeshRenderer rend; 

    public PlayerMovement pm; 

    public CameraAnimationTriggers cat; 
    
    public virtual void Start(){
        cat = Camera.main.transform.parent.parent.GetComponent<CameraAnimationTriggers>();
        pm = GameObject.Find("Player").GetComponent<PlayerMovement>();
        //rend.material = materials[PerspectiveShift.curr3D ? 1 : 0];
        rb = transform.parent.GetComponent<Rigidbody>(); 
        grounded = GameObject.Find("1_Grounded").GetComponent<Grounded>();
        anim = transform.parent.GetComponent<Animator>();
        _fanPower = new Vector3(0, 0, 0);
        StartCoroutine(StartHelper());
        
        
    }
    protected IEnumerator StartHelper(){
        yield return new WaitForSeconds(0.02f);
        
        rend.material = materials[PerspectiveShift.curr3D ? 1 : 0];
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
        rend.material = materials[0];
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
    }
    public virtual void Switch3D(){
        rend.material = materials[1];
        rb.constraints = RigidbodyConstraints.None;
    }

    public virtual void FanAffect(Fan origin){
        
    }
    public virtual void FanLeave(Fan origin){
        
    }

    public virtual void BounceAnim(){
        int picker = Random.Range(1, 2);
        cat.PlayAnim("Collide1");
    }

    public void OnCollisionEnter(Collision collision){
        print("Collided");
        if (collision.collider.tag == "Ground" || collision.collider.tag == "Wall"){
            BounceAnim();
        }
    }
}
