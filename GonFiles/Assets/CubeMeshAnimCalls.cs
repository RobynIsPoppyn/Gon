using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMeshAnimCalls : MonoBehaviour
{
    void GravityOff(){
        transform.parent.parent.GetComponent<CubeShape>().Gravity(false);
    }
    void GravityOn(){
        transform.parent.parent.GetComponent<CubeShape>().Gravity(true);
    }

    void ConstraintsOff(){
        transform.parent.parent.GetComponent<CubeShape>().UnConstraint();
    }
}
