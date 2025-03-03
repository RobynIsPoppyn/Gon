using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    private Camera mCam;
    private PerspectiveShift mCamMethods;
    [SerializeField] private string enterAnimName;
    [SerializeField] private string exitAnimName;

    private void Awake()
    {
        mCam = Camera.main;
    }

    private void Start()
    {
        mCamMethods = mCam.GetComponent<PerspectiveShift>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("PlayerCollision"))
        {
            mCamMethods.PlayTransition(enterAnimName);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("PlayerCollision") && exitAnimName != null)
        {
            mCamMethods.PlayTransition(exitAnimName);
        }
    }
}
