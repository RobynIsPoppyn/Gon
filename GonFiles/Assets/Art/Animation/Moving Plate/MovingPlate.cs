using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlate : MonoBehaviour
{
    public Waypoint[] waypoints;
    public float moveSpeed = 2f;

    private Animator animator;

    private int currentWaypointIndex = 0;
    private bool isWaiting = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWaiting)
        {
            MovePlate();
        }
    }

    void MovePlate()
    {
        Transform dest = waypoints[currentWaypointIndex].point; // destination
        transform.position = Vector3.MoveTowards(transform.position, dest.position, moveSpeed * Time.deltaTime);
        animator.SetBool("IsMoving", true);

        if (Vector3.Distance(transform.position, dest.position) < 0.01f) 
        {
            StartCoroutine(WaitAtWaypoint());
        }
    }

    IEnumerator WaitAtWaypoint()
    {
        isWaiting = true;

        animator.SetBool("IsMoving", false);

        if (waypoints[currentWaypointIndex].hasDelay)
        {
            yield return new WaitForSeconds(waypoints[currentWaypointIndex].delayDuration);
        }

        currentWaypointIndex = (currentWaypointIndex + 1) % 2;
        isWaiting = false;
    }
}
