using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftZ : MonoBehaviour
{
    protected float z3D; //save the 3D z coord
    public static List<ShiftZ> allShiftZ; 
    public static float targetZ; 
    
    bool shifting;
    protected Rigidbody rb;

    protected virtual void Start(){
        targetZ = 0f;
        if (allShiftZ == null){
            allShiftZ = new List<ShiftZ>();
        }
        allShiftZ.Add(this);
        rb = transform.GetComponent<Rigidbody>(); 
    }
    protected virtual void FixedUpdate(){
    }

    public virtual void beginShift(){
        z3D = transform.position.z;
        
        shifting = true;
        transform.position = new Vector3(transform.position.x, transform.position.y, 
                                            targetZ);
        if (rb != null){
            rb.constraints = RigidbodyConstraints.FreezePositionZ | 
                                RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        }
    }
    public virtual void resetShift(){
        shifting = false;
        transform.position = new Vector3(transform.position.x, transform.position.y, z3D);
        if (rb != null){
            rb.constraints = RigidbodyConstraints.None;
        }
        
    }
}
