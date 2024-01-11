using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    public float idleSpeed = 2f;
    public float chaseSpeed = 5f;
    public float detectionRadius = 5f;
    public int currentHealth = 50;

    private Transform player;
    private Animator animator;

    private const string MoveEnemyTrigger = "MoveEnemy";

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
                // Trigger the "MoveEnemy" animation
                animator.SetBool("Move", true);
            }
            else
            {
                // Idle state (you can add idle animations or behaviors here)
                // Reset the "MoveEnemy" animation trigger
                animator.SetBool("Move", false);

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