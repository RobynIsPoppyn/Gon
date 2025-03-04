using UnityEngine;

public class WeightedPlates : MonoBehaviour
{
    private Animator animator;
    private bool isWeighedDown = false;
    public PuzzleDoor door;
    public int[] doorLightIndexes; // which lights this plate controls

    private void Start()
    {
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
            WeighDown();
            for (int i = 0; i < doorLightIndexes.Length; i++)
            {
                door.SwitchLightState(doorLightIndexes[i]);
            }
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
        ResetPlate();
    }

    private void WeighDown()
    {
        AudioManager.instance.playSFX(AudioManager.instance.springArm);
        // Set a bool parameter so that the plate remains depressed.
        animator.SetBool("IsPressed", true);
    }

    private void ResetPlate()
    {
        AudioManager.instance.playSFX(AudioManager.instance.springSound);
        animator.SetBool("IsPressed", false);
        animator.SetTrigger("BackUp");
        animator.SetTrigger("IdleUp");
    }
}
