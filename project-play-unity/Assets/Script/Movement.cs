using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody rb;

    void Update()
    {
        // Get input for forward and backward movement
        float forwardInput = Input.GetAxisRaw("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(0f, 0f, forwardInput);

        // Normalize the movement vector to ensure consistent speed in all directions
        movement.Normalize();

        // Move the object based on the calculated movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }
}
