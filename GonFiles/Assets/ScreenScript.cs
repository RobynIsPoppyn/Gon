using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenScript : MonoBehaviour
{
    
    public RawImage ri; 
    
    public bool ThreeDScreen;
    // Update is called once per frame
    void Update()
    {
        ri.enabled = ThreeDScreen == PerspectiveShift.curr3D; 
    }
    
}
