using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PixelSwapper : MonoBehaviour
{

    public RenderTexture[] rts; 
    public RawImage ri; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Camera>().orthographic){
            GetComponent<Camera>().targetTexture = rts[1];
        }
        else GetComponent<Camera>().targetTexture = rts[0];
    }
}
