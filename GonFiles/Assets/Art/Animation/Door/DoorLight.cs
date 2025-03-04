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
                AudioManager.instance.playSFX(AudioManager.instance.lightOn);
                lightRenderer.material = greenLight;
                lightState = "GreenLight";
           }
           else
           {
                AudioManager.instance.playSFX(AudioManager.instance.lightOff);
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
                AudioManager.instance.playSFX(AudioManager.instance.lightOff);
                lightRenderer.material = noLight;
                lightState = "NoLight";
            }
        }
    }
}