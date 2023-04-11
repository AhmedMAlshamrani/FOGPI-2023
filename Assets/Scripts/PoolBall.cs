using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolBall : MonoBehaviour
{
    [SerializeField] private float minimumSpeed = 0.2f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Slow down ball when its speed is below the minimum threshold
        if (rb.velocity.magnitude < minimumSpeed)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Play sound or any other effect when the ball collides with another object
        if (collision.gameObject.CompareTag("Ball") || collision.gameObject.CompareTag("Wall"))
        {
            // You can add code here to play a sound effect or any other interaction you want
        }
    }
}
