using UnityEngine;

public class DoorLight : MonoBehaviour
{
    public Material noLight;
    public Material greenLight;
    public Renderer lightRenderer;
    private string lightState = "NoLight";

    public void SetLightActive(bool active)
    {
        if (lightRenderer != null)
        {
            lightRenderer.material = active ? greenLight : noLight;
            lightState = active ? "GreenLight" : "NoLight";
        }
    }
}