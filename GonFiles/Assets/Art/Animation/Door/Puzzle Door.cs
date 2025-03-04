using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PuzzleDoor : MonoBehaviour
{
    private Animator animator;
    public DoorLight[] doorLights;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (doorLights != null)
        {
            Debug.Log("need lights!");
        }
    }

    public void SetLightState(int lightIndex, bool active)
    {
        if (doorLights != null && lightIndex >= 0 && lightIndex < doorLights.Length)
        {
            doorLights[lightIndex].SetLightActive(active);
        }
    }

    //void SwitchLight(DoorLight light)
    //{
    //    if (light.lightState.Equals("NoLight"))
    //    {
    //        light.SetLightActive(true);
    //    }
    //    else
    //    {
    //        light.SetLightActive(false);
    //    }
    //}
}
