using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeShape : Shape
{
    public override void Open(){
        
        anim.Play("Base Layer.CubeOpen");
        StartCoroutine(OpenHelper());
        if (!Camera.main.GetComponent<PerspectiveShift>().curr3D)
            rb.rotation = Quaternion.Euler(0, 0, rb.rotation.z);
        
    }
    IEnumerator OpenHelper(){
        yield return new WaitForSeconds(0.02f); 
        //cubeMeshAnim.Play("Base Layer.CubeIdle");
    }
    public override void Close(){
      //  rb.constraints = RigidbodyConstraints.None; 
        if (smashing)
            SmashEnd();
        anim.Play("Base Layer.CubeClose");
    }
    public override void Action(){
    
        if (!grounded.isGrounded){
            rb.velocity = Vector3.zero; 
            SmashStart();
        }
    }

    public void SmashStart(){
        cubeMeshAnim.Play("Base Layer.CubeSmashStart");
        smashing = true;
    }
    public void SmashEnd(){
        
        cubeMeshAnim.Play("Base Layer.CubeSmashEnd");
        smashing = false;
        thresholdReached = false;
    }

    public void Gravity(bool grav){
        rb.useGravity = grav;
    }

    /*public void OnCollisionEnter(Collision collision){
        if (collision.collider.tag == "Ground" && smashing){
            SmashEnd();
        }
    }*/

    public override void Switch2D(){

        rb.constraints = RigidbodyConstraints.FreezePositionZ | 
                        RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY; 
    }
    public override void Switch3D(){
        rb.constraints = RigidbodyConstraints.None;
    }

    private Animator cubeMeshAnim;
    public override void Move(Vector3 direction, bool curr3D){
        base.Move(direction, curr3D);
        
    }


    public bool thresholdReached; 
    public float smashThreshold; 
    public float downwardForce;
    public bool smashing;

    public override void Start(){
        base.Start();
        cubeMeshAnim = transform.GetChild(0).GetChild(0).GetComponent<Animator>();

    }
    public void Update(){
        
        if (rb.velocity.y > smashThreshold){
            //print("reached threshold");
            thresholdReached = true;
        }
        

        if (grounded.isGrounded && smashing){
            SmashEnd();
            
        }
        else if (smashing){
            rb.AddForce(0, -1 * downwardForce, 0);
        }
        
       // transform.parent.eulerAngles = new Vector3(transform.parent.eulerAngles.x,  
        //                                FaceInput() == -1 ? transform.parent.eulerAngles.y : FaceInput(), transform.parent.eulerAngles.z);
       print(_fanPower);
        
    }

    public float FaceInput(){
        
        // W = 0
        // S = 180 / -180
        // A = 270 / -90 
        // D = 90
        if (Input.GetAxis("Horizontal") > 0){
            
            if (Input.GetAxis("Vertical") > 0){
                return -45f; 

            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                return -135f;
            }
            else return -90f;
            
        }
        else if (Input.GetAxis("Horizontal") < 0){
            if (!cubeMeshAnim.IsInTransition(0))
                cubeMeshAnim.SetTrigger("Walk");
            if (Input.GetAxis("Vertical") > 0){
                return 45f; 

            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                return 135f;
            }
            else return 90f;
        }
        else if (Input.GetAxis("Vertical") < 0) {
            if (!cubeMeshAnim.IsInTransition(0))
                cubeMeshAnim.SetTrigger("Walk");
            return 0f;    
        }
        else if (Input.GetAxis("Vertical") > 0){
            if (!cubeMeshAnim.IsInTransition(0))
                cubeMeshAnim.SetTrigger("Walk");
            return 180f;
        }
        else {
            if (!cubeMeshAnim.IsInTransition(0))
                cubeMeshAnim.SetTrigger("Idle");
            return -1f;
        }
    }
}
