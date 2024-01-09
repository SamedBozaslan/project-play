using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int currentHealth = 50;

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
