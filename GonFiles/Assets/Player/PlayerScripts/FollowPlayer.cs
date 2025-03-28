using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset;

    void Start(){
        offset = transform.position - target.position; 
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset; 
    }
}
