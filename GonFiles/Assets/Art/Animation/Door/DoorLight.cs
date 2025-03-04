using UnityEngine;

public class DoorLight : MonoBehaviour
{
    public Material noLight;
    public Material greenLight;
    public Renderer lightRenderer;
    public string lightState = "NoLight"; // "GreenLight" for on, "NoLight" for off

    public void SwitchLight()
    {
        if (lightRenderer != null)
        {
           if (lightRenderer.sharedMaterial == noLight)
           {
                lightRenderer.material = greenLight;
                lightState = "GreenLight";
           }
           else
           {
                lightRenderer.material = noLight;
                lightState = "NoLight";
           }
        }
    }

    public void TurnOff()
    {
        if (lightRenderer != null)
        {
            if (lightRenderer.sharedMaterial == greenLight)
            {
                lightRenderer.material = noLight;
                lightState = "NoLight";
            }
        }
    }
}