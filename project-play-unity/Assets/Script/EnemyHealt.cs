using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    private int currentHealth;
    public float detectionRadius = 5f;
    public float walkSpeed = 3f;
    public float chaseSpeed = 5f;
    public float idleRotationSpeed = 50f;

    private Transform player;
    private NavMeshAgent navMeshAgent;
    private NavMeshObstacle navMeshObstacle;
    private bool playerInSight;

    void Start()
    {
        // Set initial health
        currentHealth = 50;

        // Find the player's Transform
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Initialize NavMesh components
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshObstacle = GetComponent<NavMeshObstacle>();

        // Set initial speeds
        navMeshAgent.speed = walkSpeed;
    }

    void Update()
    {
        // Check if the player is in sight
        playerInSight = Vector3.Distance(transform.position, player.position) <= detectionRadius;

        if (playerInSight)
        {
            // Chase the player using NavMeshAgent
            navMeshAgent.enabled = true;
            navMeshObstacle.enabled = false;

            navMeshAgent.speed = chaseSpeed;
            navMeshAgent.SetDestination(player.position);
        }
        else
        {
            // Move in circles when player is out of sight
            navMeshAgent.enabled = false;
            navMeshObstacle.enabled = true;

            transform.Rotate(Vector3.up, idleRotationSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damage)
    {
        // Reduce health
        currentHealth -= damage;

        // Check if the enemy is defeated
        if (currentHealth <= 0)
        {
            // Perform defeat actions (e.g., play animation, destroy enemy)
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is the player
        if (collision.collider.CompareTag("Player"))
        {
            // Player touched the enemy, apply damage to player
            //collision.collider.GetComponent<PlayerScript>().TakeDamage(10);
        }
    }
}