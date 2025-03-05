using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSkybox : MonoBehaviour
{
    
    public Camera cam; 
    // Update is called once per frame
    void Update()
    {
        if (PerspectiveShift.curr3D){
            cam.clearFlags = CameraClearFlags.Skybox; 
        }
        else {
            cam.clearFlags = CameraClearFlags.SolidColor;
        }
    }
}
