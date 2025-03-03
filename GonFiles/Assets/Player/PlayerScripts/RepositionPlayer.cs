using UnityEngine;

public class RepositionPlayer : MonoBehaviour
{
    [SerializeField] private GameObject spawnPt;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("PlayerCollision"))
        {
            Transform player = collision.transform.parent;

            if (player != null)
            {
                player.position = spawnPt.transform.position;
            }
        }
    }
}
