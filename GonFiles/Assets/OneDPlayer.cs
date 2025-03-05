using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneDPlayer : MonoBehaviour
{
    Rigidbody2D rb; 
    public float speed = 5f;
    public float torque = 5f;
    public float speedCap = 50f;
    public float torqueCap = 20f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        if (rb.velocity.x < speedCap)
            rb.AddForce(new Vector3(speed * Input.GetAxis("Horizontal"), 0, 0));
        if (rb.angularVelocity < torqueCap)
            rb.AddTorque(-1 * torque * Input.GetAxis("Horizontal"));
        */

        float input = Input.GetAxis("Horizontal");

        if (rb.velocity.x < speedCap)
            rb.AddForce(new Vector2(speed * input, 0));
        if (rb.angularVelocity < torqueCap)
            rb.AddTorque(-1 * torque * input);
    }
}
