using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDamage : MonoBehaviour
{
    public int damagePerSecond = 2;
    public int totalEnemyHealth = 10;

    private void OnParticleCollision(GameObject other)
    {
        // Check if the collided object has the "Enemy" tag
        if (other.CompareTag("Enemy"))
        {
            // Apply damage over time
            StartCoroutine(ApplyDamageOverTime(other));
        }
    }

    private System.Collections.IEnumerator ApplyDamageOverTime(GameObject enemy)
    {
        while (totalEnemyHealth > 0 && enemy != null)
        {
            // Deal damage per second if the enemy is still valid
            if (Object.ReferenceEquals(enemy, null))
                break; // Exit the loop if the enemy is destroyed

            enemy.GetComponent<EnemyHealth>().TakeDamage(damagePerSecond);

            // Wait for 1 second before applying the next damage
            yield return new WaitForSeconds(1f);
        }
    }
}
