using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthmanager : MonoBehaviour
{
    public int currentHealth = 50;

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

