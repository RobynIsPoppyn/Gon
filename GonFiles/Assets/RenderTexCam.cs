using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderTexCam : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        GetComponent<Camera>().orthographic = transform.parent.GetComponent<Camera>().orthographic;
    }
}
