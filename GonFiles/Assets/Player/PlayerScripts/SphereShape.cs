using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereShape : Shape
{
     
    public float jumpForce = 10f; 
    public float sphereSpeedModifier = 1f;
    public float horizontalSpeedCap = 50f;
    public float deacceleration = 1f;

    public override void Action(){
        if (grounded.isGrounded)
        rb.AddForce(new Vector3(0, jumpForce, 0));
    }

    public override void Move(Vector3 direction, bool curr3D){
        direction = check3D(direction, curr3D);
        if (!(rb.velocity.x >= horizontalSpeedCap || rb.velocity.z >= horizontalSpeedCap)){
            rb.AddForce(direction * Speed * sphereSpeedModifier);
            if (rb.velocity.x / Input.GetAxis("Horizontal") < 0){
                rb.AddForce(new Vector3(direction.x * deacceleration, 0, 0));
                
            }
            if (rb.velocity.z / Input.GetAxis("Vertical") < 0) {
                rb.AddForce(new Vector3(0, 0, direction.z * deacceleration));
                
            }
        }

        
    }

    public override void Open(){
        anim.Play("SphereOpen");
    }

    public override void Close(){
        anim.Play("SphereClose");
    }




}
