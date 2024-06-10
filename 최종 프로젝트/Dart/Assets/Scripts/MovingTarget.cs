using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody rb;
    private bool reverseDirection = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveTarget();
    }

    private void MoveTarget()
    {
        Vector3 movement = new Vector3(speed, 0f, 0f);
        rb.velocity = movement;

        if (reverseDirection)
        {
            speed *= -1;
            reverseDirection = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            reverseDirection = true;
        }
    }
}
