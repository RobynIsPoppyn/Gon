using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereShape : Shape
{
     
    public float jumpForce = 10f; 
    public override void Action(){
        if (grounded.isGrounded)
        rb.AddForce(new Vector3(0, jumpForce, 0));
    }
}
