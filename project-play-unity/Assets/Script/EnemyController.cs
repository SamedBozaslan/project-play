using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float idleSpeed = 2f;         // Speed during idle wandering
    public float chaseSpeed = 5f;        // Speed when following the player
    public float detectionRadius = 5f;   // Radius to detect the player
    public float wanderingRadius = 10f;  // Radius for random wandering
    public float minWanderTime = 2f;     // Minimum time for random wandering
    public float maxWanderTime = 5f;     // Maximum time for random wandering

    private Transform player;            // Reference to the player's transform
    private Vector3 randomDestination;   // Random destination for wandering
    private bool isWandering = false;    // Flag to indicate random wandering
    private float wanderTimer;           // Timer for random wandering

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        SetRandomDestination();
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // If the player is within the detection radius, follow the player
            if (distanceToPlayer <= detectionRadius)
            {
                FollowPlayer();
            }
            else
            {
                // If not following the player, randomly wander
                Wander();
            }
        }
    }

    void FollowPlayer()
    {
        // Move towards the player with chaseSpeed
        Vector3 direction = player.position - transform.position;
        transform.Translate(direction.normalized * chaseSpeed * Time.deltaTime, Space.World);
    }

    void Wander()
    {
        // If not currently wandering, start the wandering process
        if (!isWandering)
        {
            isWandering = true;
            wanderTimer = Random.Range(minWanderTime, maxWanderTime);
        }

        // Move towards the random destination with idleSpeed
        transform.Translate((randomDestination - transform.position).normalized * idleSpeed * Time.deltaTime, Space.World);

        // Check if the enemy has reached the random destination
        if (Vector3.Distance(transform.position, randomDestination) < 0.2f)
        {
            // Set a new random destination and reset the wandering flag
            SetRandomDestination();
            isWandering = false;
        }

        // Decrease the wander timer
        wanderTimer -= Time.deltaTime;

        // If the wander timer reaches zero, set a new random destination
        if (wanderTimer <= 0f)
        {
            SetRandomDestination();
            wanderTimer = Random.Range(minWanderTime, maxWanderTime);
        }
    }

    void SetRandomDestination()
    {
        // Set a new random destination within the wandering radius
        randomDestination = transform.position + Random.insideUnitSphere * wanderingRadius;
        randomDestination.y = transform.position.y; // Keep the y-coordinate the same
    }
}
