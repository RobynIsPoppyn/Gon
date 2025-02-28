using System.Collections;
using UnityEngine;

public class JumpPlate : MonoBehaviour
{
    private Animator animator;
    public float bounceForce = 10f;  // Adjustable bounce strength

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(SpringSequence(other));
        }
    }

    private IEnumerator SpringSequence(Collider other)
    {
        animator.SetTrigger("WeighDown");
        yield return new WaitForSeconds(0.1f);

        animator.SetTrigger("IdleDown");
        yield return new WaitForSeconds(0.2f);

        // Apply bounce force
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Reset vertical velocity before
            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        }

        animator.SetTrigger("Bounce");
        yield return new WaitForSeconds(0.2f);

        animator.SetTrigger("IdleUp");
    }
}
