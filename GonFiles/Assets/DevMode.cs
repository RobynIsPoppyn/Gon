using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevMode : MonoBehaviour
{
    public bool EnableShift;

    public static bool ShiftButton; 

    public bool EnableGroundedMesh; 
    public static bool GroundedMesh;

    public void Start(){
        ShiftButton = EnableShift;
        GroundedMesh = EnableGroundedMesh;
        print("Shiftting Button Enabled = " + ShiftButton);
        print("Grounded Mesh Enabled = " + EnableGroundedMesh);
    }
}
