using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereShape : Shape
{
     
    public float jumpForce = 10f; 
    public float sphereSpeedModifier = 1f;
    public float torque = 1f;
    public float horizontalSpeedCap = 50f;
    public float deacceleration = 1f;
    public float fanWeight = 1f;
    public float friction = 5f;
    

    public override void Action(){
        if (grounded.isGrounded){
            rb.AddForce(new Vector3(0, jumpForce, 0));
            AudioManager.instance.playSFX(AudioManager.instance.playerJump);
        }
    }

    

    public override void Move(Vector3 direction, bool curr3D){

        if (grounded.isGrounded && !direction.Equals(Vector3.zero))
        {

            print(Input.GetAxis("Horizontal"));
            AudioManager.instance.toggleRollSound(true);
        }
        direction = check3D(direction, curr3D);
        if (Mathf.Abs(rb.velocity.x) < horizontalSpeedCap){
            rb.AddForce(new Vector3(direction.x * Speed * sphereSpeedModifier, 0, 0));
            if (rb.velocity.x / Input.GetAxis("Horizontal") < 0){
                rb.AddForce(new Vector3(direction.x * deacceleration, 0, 0));
                
            }
        }
        else if (rb.velocity.x / Input.GetAxis("Horizontal") < 0){
                rb.AddForce(new Vector3(direction.x * deacceleration, 0, 0));
                
        }
        if (Mathf.Abs(rb.velocity.z) < horizontalSpeedCap){
            rb.AddForce(new Vector3(0, 0, direction.z * Speed * sphereSpeedModifier));
            if (rb.velocity.z / Input.GetAxis("Vertical") < 0) {
                rb.AddForce(new Vector3(0, 0, direction.z * deacceleration));

            }
        }
        else if (rb.velocity.z / Input.GetAxis("Vertical") < 0) {
                rb.AddForce(new Vector3(0, 0, direction.z * deacceleration));

        }
        
        if (!grounded.isGrounded){
           
            rb.AddTorque(new Vector3(Input.GetAxis("Vertical") * torque * -1, 0, Input.GetAxis("Horizontal") * torque * -1));
        }
            

        
    }

    public void FixedUpdate(){
        if (transform.parent.GetComponent<PlayerMovement>().currShape.Equals(this))
            rb.AddForce(fanWeight * _fanPower);

        if (!PerspectiveShift.curr3D && pm.currShape == this){
            rb.rotation = Quaternion.Euler(0, 0, pm.transform.eulerAngles.z);
        }

        if (Input.GetAxis("Horizontal") == 0 && rb.velocity.x != 0 && grounded){
            rb.AddForce(new Vector3(-1 * rb.velocity.x * friction, 0, 0));
        }
        if (Input.GetAxis("Vertical") == 0 && rb.velocity.z != 0 && grounded){
            rb.AddForce(new Vector3(0, 0, -1 * rb.velocity.z * friction));
        }

        if (Input.GetAxis("Horizontal") == 0) {
            if (Input.GetAxis("Vertical") == 0 || !PerspectiveShift.curr3D){
                AudioManager.instance.toggleRollSound(false);
            }
        }
        if (!grounded.isGrounded)
            AudioManager.instance.toggleRollSound(false);
        
    }

    public override void Open(){
        _fanPower = Vector3.zero;
        anim.Play("SphereOpen");
    }

    public override void Close(){
        
        anim.Play("SphereClose");
    }

    public void ApplyFanForce(Fan fan){
    
    }

    public override void FanAffect(Fan origin){
        print("added fan power");
        _fanPower += new Vector3(origin.XForce, origin.YForce, origin.ZForce);
    }
    public override void FanLeave(Fan origin){
        print("subtracted fan power");
         _fanPower -= new Vector3(origin.XForce, origin.YForce, origin.ZForce);
    }



}
