using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int currentHealth;

    void Start()
    {
        // Set initial health
        currentHealth = 10;
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
}