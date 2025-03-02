using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleTrigger : MonoBehaviour
{
    [SerializeField] private GameObject titlePrefab;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("PlayerCollision"))
        {
            titlePrefab.SetActive(true);
        }
    }
}
