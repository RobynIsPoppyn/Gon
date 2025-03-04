using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PuzzleDoor : MonoBehaviour
{
    private Animator animator;
    public DoorLight[] doorLights;
    private bool doorOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (doorLights == null)
        {
            Debug.Log("need lights!");
        }
    }
    private void Update()
    {
        CheckAllLights();
    }

    public void SwitchLightState(int lightIndex)
    {
        if (doorLights != null && lightIndex >= 0 && lightIndex < doorLights.Length)
        {
            doorLights[lightIndex].SwitchLight();
        }
    }

    // Reset lights
    public void TurnOffLights(int lightIndex)
    {
        if (doorLights != null && lightIndex >= 0 && lightIndex < doorLights.Length && !doorOpened)
        {
            doorLights[lightIndex].TurnOff();
        }
    }

    public void CheckAllLights()
    {
        bool allLit = true;
        for (int i = 0; i < doorLights.Length; i++)
        {
            if (!doorLights[i].lightState.Equals("GreenLight"))
            {
                allLit = false;
                break;
            }
        }

        if (allLit && !doorOpened)
        {
            doorOpened = true;
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        animator.SetTrigger("Open");
    }
}
