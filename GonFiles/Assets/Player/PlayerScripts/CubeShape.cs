using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeShape : Shape
{

    public bool thresholdReached; 
    public float smashThreshold; 
    public float downwardForce;
    public bool smashing;
    public float smashSpeedCap = 7f;
    public float cubeWeight = 2f;
    private float _defWeight = 1f; 
    public float torque = 1f;
    public float torqueCap = 1f;
    private bool m_slamInitiated = false;

    public override void Open(){
        m_slamInitiated = false;
        anim.Play("Base Layer.CubeOpen");
        StartCoroutine(OpenHelper());
        rb.drag = cubeWeight;
        rb.velocity = new Vector3(0, 0, 0);
        if (!PerspectiveShift.curr3D)
            rb.rotation = Quaternion.Euler(0, 0, rb.rotation.z);
        if (Mathf.Abs(rb.angularVelocity.x) > torqueCap){
            rb.angularVelocity = new Vector3(torqueCap * Mathf.Sign(rb.angularVelocity.x), 0, 0);
        }
        if (Mathf.Abs(rb.angularVelocity.z) > torqueCap){
            rb.angularVelocity = new Vector3(0, 0, torqueCap * Mathf.Sign(rb.angularVelocity.z));
        }
        
    }
    IEnumerator OpenHelper(){
        yield return new WaitForSeconds(0.02f); 
        cubeMeshAnim.Play("Base Layer.CubeDefault");
    }
    public override void Close(){
      //  rb.constraints = RigidbodyConstraints.None; 
        if (smashing)
            SmashEnd(false);
        anim.Play("Base Layer.CubeClose");
        rb.drag = _defWeight;
    }
    public override void Action(){
    
        if (!smashing && !m_slamInitiated && !grounded.isGrounded){
            rb.velocity = Vector3.zero; 
            m_slamInitiated = true;
            rb.rotation = Quaternion.Euler(0, rb.transform.eulerAngles.y, 0);
            rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            print(rb.constraints);
            SmashStart();
        }
    }

    public override void Move(Vector3 direction, bool curr3D){
        base.Move(direction, curr3D);
        if (Mathf.Abs(rb.angularVelocity.x) < torqueCap){
            rb.AddTorque(new Vector3(Input.GetAxis("Vertical") * torque * -1, 0, 0));
        }
        if (Mathf.Abs(rb.angularVelocity.z) < torqueCap){
            rb.AddTorque(new Vector3(0, 0, Input.GetAxis("Horizontal") * torque * -1));
        }
            
    }

    public void SmashStart(){
       
        
        AudioManager.instance.playSFX(AudioManager.instance.playerSmashWoosh);
        cubeMeshAnim.Play("Base Layer.CubePlunge");
        
    }
    public void SmashEnd(bool ExecuteAnim){
        
       
        
        cubeMeshAnim.Play("Base Layer.CubeSmash");
    
        cubeMeshAnim.SetTrigger("SmashSlowStop");
        
        smashing = false;
       // thresholdReached = false;
    }

    public void Gravity(bool grav){
        if (grav == true){
            smashing = true;
        }
        rb.useGravity = grav;
    }

    public void UnConstraint(){ //Called by ending smash
        if (PerspectiveShift.curr3D){
            rb.constraints = RigidbodyConstraints.None;
        }
        else {
            thresholdReached = false;
            m_slamInitiated = false;
            print("Unconstrainted'");
            rb.constraints = RigidbodyConstraints.FreezePositionZ | 
                        RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY; }
        pm.SmashAnim();
    }

    /*public void OnCollisionEnter(Collision collision){
        if (collision.collider.tag == "Ground" && smashing){
            SmashEnd();
        }
    }*/

    public override void Switch2D(){

        //rb.constraints = RigidbodyConstraints.FreezePositionZ | 
       //                 RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY; 
        rend.material = materials[0];
    }
    public override void Switch3D(){
        rb.constraints = RigidbodyConstraints.None;
        rend.material = materials[1];
        //WTF
    }

    private Animator cubeMeshAnim;
    


    

    public override void Start(){
        
        base.Start();
        _defWeight = rb.drag;
        cubeMeshAnim = transform.GetChild(0).GetChild(0).GetComponent<Animator>();

    }
    public void Update(){
        
        if (rb.velocity.y < -1 * smashThreshold && smashing){
          
            thresholdReached = true;
        }
        else {
            
        }

        if (!PerspectiveShift.curr3D && pm.currShape == this && !m_slamInitiated){
            rb.rotation = Quaternion.Euler(0, 0, pm.transform.eulerAngles.z);
        }
        

        if (grounded.isGrounded && smashing || !rb.useGravity && !thresholdReached && !smashing ){
            SmashEnd(true);
            if (thresholdReached)
                AudioManager.instance.playSFX(AudioManager.instance.playerSmashCollision);
            
        }
        else if (smashing && rb.velocity.y < -1 * smashSpeedCap){
            rb.AddForce(0, -1 * downwardForce, 0);
        }
        
       // transform.parent.eulerAngles = new Vector3(transform.parent.eulerAngles.x,  
        //                                FaceInput() == -1 ? transform.parent.eulerAngles.y : FaceInput(), transform.parent.eulerAngles.z);
       
        
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
