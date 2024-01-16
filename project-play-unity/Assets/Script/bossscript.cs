using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossscript : MonoBehaviour
{
    public float idleSpeed = 2f;
    public float chaseSpeed = 4f;
    public float detectionRadius = 5f;
    public int currentHealth = 50;

    public ParticleSystem particleSystemm; // Reference to the particle system

    private Transform player;
    private Animator animator;

    private const string MoveEnemyTrigger = "Move";

    private bool particleSystemActivated = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= detectionRadius && !particleSystemActivated)
            {
                // Player is within range, start particle system
                StartParticleSystem();
            }
            else if (distanceToPlayer > detectionRadius && particleSystemActivated)
            {
                // Player is out of range, stop particle system
                StopParticleSystem();
            }
            else if (distanceToPlayer > detectionRadius && !particleSystemActivated)
            {
                // Player is out of range, particle system was not activated
                // You can add idle state logic here
            }

            // Update other enemy behaviors based on distance, if needed
        }
    }

    void StartParticleSystem()
    {
        // Trigger the "MoveEnemy" animation
        animator.SetBool(MoveEnemyTrigger, true);

        // Activate the particle system
        if (particleSystemm != null && !particleSystemm.isPlaying)
        {
            particleSystemm.Play();
            particleSystemActivated = true; // Set the flag to true once activated
        }
    }

    void StopParticleSystem()
    {
        // Player is out of range, deactivate the particle system
        if (particleSystemm != null && particleSystemm.isPlaying)
        {
            particleSystemm.Stop();
            particleSystemActivated = false; // Set the flag to false once deactivated

            // Idle state (you can add idle animations or behaviors here)
            // Reset the "MoveEnemy" animation trigger
            animator.SetBool(MoveEnemyTrigger, false);
        }
    }

    public void TakeDamage(int damage)
    {
        // Reduce health
        currentHealth -= damage;

        // Check if the enemy is defeated
        if (currentHealth <= 0)
        {
            // Perform defeat actions for the enemy (e.g., play animation, destroy enemy)
            Destroy(gameObject);
        }
    }
}