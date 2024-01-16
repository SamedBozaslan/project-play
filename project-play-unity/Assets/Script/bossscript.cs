using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossscript : MonoBehaviour
{
    public float idleSpeed = 2f;
    public float chaseSpeed = 5f;
    public float detectionRadius = 5f;
    public int currentHealth = 50;

    public GameObject particleSystemPrefab; // Prefab of the particle system

    private Transform player;
    private Animator animator;

    private const string MoveEnemyTrigger = "Move";
    private bool particleSystemActivated = false;
    private GameObject particleSystemInstance; // Reference to the instantiated particle system

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

            if (distanceToPlayer <= detectionRadius)
            {
                RotateAndMoveTowardsPlayer();

                // Activate particle system if not already activated
                if (!particleSystemActivated)
                {
                    StartParticleSystem();
                }

                // Trigger the "MoveEnemy" animation
                animator.SetBool(MoveEnemyTrigger, true);
            }
            else
            {
                // Player is out of range, deactivate the particle system
                StopParticleSystem();

                // Idle state (you can add idle animations or behaviors here)
                // Reset the "MoveEnemy" animation trigger
                animator.SetBool(MoveEnemyTrigger, false);
            }
        }
    }

    void RotateAndMoveTowardsPlayer()
    {
        // Rotate towards the player
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion toRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * 5f);

        // Move towards the player with chaseSpeed
        transform.Translate(Vector3.forward * chaseSpeed * Time.deltaTime);
    }

    void StartParticleSystem()
    {
        // Instantiate the particle system as a child of the enemy
        if (particleSystemPrefab != null)
        {
            particleSystemInstance = Instantiate(particleSystemPrefab, transform);
            particleSystemActivated = true; // Set the flag to true once activated
        }
    }

    void StopParticleSystem()
    {
        // Player is out of range, deactivate the particle system
        if (particleSystemInstance != null)
        {
            Destroy(particleSystemInstance); // Destroy the particle system instance
            particleSystemActivated = false; // Set the flag to false once deactivated
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