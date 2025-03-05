using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RollCredits : MonoBehaviour
{
    [SerializeField] private TransitionLoader loader;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerCollision"))
        {
            StartCoroutine(TransitionCredits());
        }
    }

    private IEnumerator TransitionCredits()
    {
        yield return new WaitForSeconds(20f);

        loader.LoadNextLevel(6, null);
    }
}
