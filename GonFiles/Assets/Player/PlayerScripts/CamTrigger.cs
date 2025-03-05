using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    private Camera mCam;
    private PerspectiveShift mCamMethods;
    [SerializeField] private string enterAnimName;
    [SerializeField] private string exitAnimName;
    [SerializeField] private bool destroyOnLeave = false;

    private void Start()
    {
        mCam = Camera.main;
        mCamMethods = mCam.GetComponent<PerspectiveShift>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("PlayerCollision"))
        {
            Debug.Log("HELLOO");
            mCamMethods.PlayTransition(enterAnimName);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("PlayerCollision") && exitAnimName != null)
        {
            mCamMethods.PlayTransition(exitAnimName);
            if (destroyOnLeave)
            {
                Destroy(gameObject);
            }
        }
    }
}
