using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanMesh : MonoBehaviour
{
    public void On(){
        transform.parent.GetComponent<FanParent>().TurnOn();
    }
    public void Off(){
        transform.parent.GetComponent<FanParent>().TurnOff();
    }
}
