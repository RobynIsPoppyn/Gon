using UnityEngine;

public class JumpPlate : MonoBehaviour
{
    public float bounceForce = 10f;

    private Animator animator;
    private bool isWeighedDown = false;

    private void Start()
    {
        // Look for the Animator in the parent hierarchy.
        animator = GetComponentInParent<Animator>();
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

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>() ?? other.GetComponentInParent<PlayerMovement>();
        if (playerMovement == null) return;

        // If weighed down and the player is now in Sphere mode, trigger the bounce.
        if (isWeighedDown && playerMovement.currShape.GetComponent<SphereShape>() != null)
        {
            isWeighedDown = false;
            Bounce(playerMovement.currShape.GetComponentInParent<Rigidbody>());
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (!other.CompareTag("Player")) return;

    //    // Reset the weighed-down state when the player leaves.
    //    isWeighedDown = false;
    //    ResetPlateAnimation();
    //}

    private void WeighDownAnimation()
    {
        // Set a bool parameter so that the plate remains depressed.
        animator.SetBool("IsPressed", true);
    }

    private void Bounce(Rigidbody rb)
    {
        // Trigger the bounce animation.
        animator.SetTrigger("Bounce");

        // Apply upward force to the player.
        if (rb != null)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // Reset vertical velocity.
            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        }

        // Reset the depressed state and trigger the pop-up animation.
        animator.SetBool("IsPressed", false);
        animator.SetTrigger("IdleUp");
    }

    private void ResetPlateAnimation()
    {
        animator.SetBool("IsPressed", false);
        animator.SetTrigger("IdleUp");
    }
}
