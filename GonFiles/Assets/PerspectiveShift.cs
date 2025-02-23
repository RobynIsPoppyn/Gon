using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveShift : MonoBehaviour
{
    public bool curr3D; //true if 3D, false if 2D
    Animator anim; 

    void Start()
    {
        curr3D = false;
        anim = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)){
            if (curr3D) PlayTransition("Def2DSwitchTO"); 
            else PlayTransition("Def3DSwitchTO"); 
        }
    }

    public void Switch2D(){
        Camera.main.orthographic = true;
        curr3D = false;
    }

    public void Switch3D(){
        Camera.main.orthographic = false; 
        curr3D = true;
    }

    public void PlayTransition(string animName){ //Don't include base layer
        anim.Play("Base Layer." + animName);
    }
}
