using UnityEngine;

public class Button : MonoBehaviour
{
    private Animator animator;
    private bool isWeighedDown = false;

    private void Start()
    {
        // Look for the Animator in the parent hierarchy.
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // Locate the PlayerMovement script.
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>() ?? other.GetComponentInParent<PlayerMovement>();
        if (playerMovement == null) return;

        // If in Cube mode, weigh down the plate.
        if (playerMovement.currShape.GetComponent<CubeShape>() != null)
        {
            isWeighedDown = true;
            WeighDownAnimation();
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (!other.CompareTag("Player")) return;

    //    PlayerMovement playerMovement = other.GetComponent<PlayerMovement>() ?? other.GetComponentInParent<PlayerMovement>();
    //    if (playerMovement == null) return;
    //}

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // Reset the weighed-down state when the player leaves.
        isWeighedDown = false;
        ResetPlateAnimation();
    }

    private void WeighDownAnimation()
    {
        // Set a bool parameter so that the plate remains depressed.
        animator.SetBool("IsPressed", true);
    }

    private void ResetPlateAnimation()
    {
        animator.SetBool("IsPressed", false);
        animator.SetTrigger("BackUp");
        animator.SetTrigger("IdleUp");
    }
}
