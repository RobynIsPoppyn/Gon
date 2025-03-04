using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI buttonText; // Assign the TextMeshPro - Text component
    [SerializeField] private Color normalColor = Color.white; // Default text color
    [SerializeField] private Color hoverColor = new Color(0.541f, 0.749f, 0.980f, 1f); // Text color on hover
    [SerializeField] private float transitionSpeed = 1.5f; // Speed of the color transition
    public bool playClick = true;

    private bool isHovering = false;

    private void Update()
    {
        if (buttonText != null)
        {
            // Smoothly transition between colors
            buttonText.color = Color.Lerp(
                buttonText.color,
                isHovering ? hoverColor : normalColor,
                Time.deltaTime * transitionSpeed
            );
        }
    }

    // Called when the pointer enters the button
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
        AudioManager.instance.playUI(AudioManager.instance.uiHover);
    }

    // Called when the pointer exits the button
    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }

    // Called when the pointer clicks the button
    public void OnPointerClick(PointerEventData eventData)
    {
        if (playClick) AudioManager.instance.playUI(AudioManager.instance.uiSelect);
    }
}
