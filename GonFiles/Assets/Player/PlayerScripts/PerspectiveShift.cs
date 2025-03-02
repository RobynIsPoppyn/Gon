using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveShift : MonoBehaviour
{
    public static bool curr3D; //true if 3D, false if 2D
    Animator anim;

    public delegate void ParallaxCameraDelegate(float deltaMovement);
    public ParallaxCameraDelegate onCameraTranslate;
    private float oldPosition;

    void Start()
    {
        curr3D = !Camera.main.orthographic;
        anim = transform.GetComponent<Animator>();
        oldPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (DevMode.ShiftButton && Input.GetKeyDown(KeyCode.F)){
            if (curr3D) PlayTransition("Def2DSwitchTO"); 
            else PlayTransition("Def3DSwitchTO"); 
        }

        if (transform.position.x != oldPosition)
        {
            if (onCameraTranslate != null)
            {
                float delta = oldPosition - transform.position.x;
                onCameraTranslate(delta);
            }

            oldPosition = transform.position.x;
        }
    }

    public void Switch2D(){
        Camera.main.orthographic = true;
        curr3D = false;
        foreach(ShiftZ x in ShiftZ.allShiftZ){
                x.beginShift();
            }
    }

    public void Switch3D(){
        Camera.main.orthographic = false; 
        curr3D = true;
        foreach(ShiftZ x in ShiftZ.allShiftZ){
                x.resetShift();
        }
    }

    //public CallAnimation(string ani)
    //asdfl
    public void PlayTransition(string animName){ //Don't include base layer
        anim.Play("Base Layer." + animName);
    }
}
