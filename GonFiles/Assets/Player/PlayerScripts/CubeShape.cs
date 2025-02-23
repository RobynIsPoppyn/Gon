using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeShape : Shape
{
    public override void Open(){
        print("Cube Open");
        anim.Play("Base Layer.CubeOpen");
    }
    public override void Close(){
        anim.Play("Base Layer.CubeClose");
    }
}
