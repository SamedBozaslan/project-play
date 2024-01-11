using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 360f;
    public Rigidbody rb;

    public ParticleSystem mistParticleSystem;
    public Animator playerAnimator;

    void Update()
    {
        // Player Movement
        HandleMovement();

        // Mist Control
        HandleMistControl();

    }

    void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (movement != Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(horizontalInput, verticalInput) * Mathf.Rad2Deg;
            Vector3 rotationVector = new Vector3(0, targetAngle, 0);
            Quaternion toRotation = Quaternion.Euler(rotationVector);
            rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, toRotation, rotationSpeed * Time.deltaTime));

            // Move the player based on input and speed
            rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

            // Trigger the "Move" animation
            playerAnimator.SetBool("Move", true);
        }
        else
        {
            // If not moving, trigger the "Idle" animation
            playerAnimator.SetBool("Move", false);
        }
    }



    void HandleMistControl()
    {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            StartMist();
            playerAnimator.SetBool("Attack", true); // Replace "YourAnimationTriggerName" with the actual trigger name in your Animator controller
        } 

    // Check for left mouse button release
    if (Input.GetMouseButtonUp(0))
        {
            StopMist();
            playerAnimator.SetBool("Attack", false);
        }
    }

    void StartMist()
    {
        // Start the mist particle system
        mistParticleSystem.Play();
    }

    void StopMist()
    {
        // Stop the mist particle system
        mistParticleSystem.Stop();
    }


    
}





