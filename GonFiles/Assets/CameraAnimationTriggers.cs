using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimationTriggers : MonoBehaviour
{
    public Animator anim; 

    public void PlayAnim(string s){
        anim.Play("Base Layer." + s);
    }

    public void SetTrigger(string s){
        anim.SetTrigger(s);
    }
}
