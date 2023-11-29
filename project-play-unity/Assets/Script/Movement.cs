using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody rb;

    void Update()
    {
        // Get input for horizontal and vertical movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        // Normalize the movement vector to ensure consistent speed in all directions
        movement.Normalize();

        // Move the object based on the calculated movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }
}
