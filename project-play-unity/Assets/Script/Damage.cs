using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour 
{
    public int damagePerSecond = 2;

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
        Healthmanager healthManager = enemy.GetComponent<Healthmanager>();

        while (healthManager.currentHealth > 0)
        {
            // Deal damage per second if the enemy is still valid
            healthManager.TakeDamage(damagePerSecond);

            // Wait for 1 second before applying the next damage
            yield return new WaitForSeconds(1f);
        }
    }
}