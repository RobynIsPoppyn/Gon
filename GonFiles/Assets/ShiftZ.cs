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

    protected void Start(){
        targetZ = -5f;
        if (allShiftZ == null){
            allShiftZ = new List<ShiftZ>();
        }
        allShiftZ.Add(this);
        rb = transform.GetComponent<Rigidbody>(); 
    }
    protected void FixedUpdate(){
        if (shifting){
            
            
            
        }
    }

    public void beginShift(){
        z3D = transform.position.z;
        print(z3D);
        shifting = true;
        transform.position = new Vector3(transform.position.x, transform.position.y, 
                                            targetZ);
    }
    public void resetShift(){
        shifting = false;
        transform.position = new Vector3(transform.position.x, transform.position.y, z3D);

        
    }
}
