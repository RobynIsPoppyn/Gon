using System.Collections;
using UnityEngine;

public class JumpPlate : MonoBehaviour
{
    private Animator animator;
    public float bounceForce = 10f;  // Adjustable bounce strength
    public Rigidbody playerRB;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(SpringSequence());
        }
    }

    private IEnumerator SpringSequence()
    {
        //animator.SetTrigger("WeighDown");
        //animator.SetTrigger("IdleDown");

        animator.SetTrigger("Bounce");

        // Apply bounce force
        Rigidbody rb = playerRB;
        if (rb != null)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Reset vertical velocity before
            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        }

        animator.SetTrigger("IdleDown");
        yield return new WaitForSeconds(0f);
    }
}
