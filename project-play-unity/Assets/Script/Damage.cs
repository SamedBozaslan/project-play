using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Damage : MonoBehaviour 
{

    [Header("Player damage to Enemy")]
    public int damagePerSecond = 2;
    [Header("Enemy damage to Player")]
    public int damageAmount = 10;


    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            // Apply damage to the player
            collision.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(damageAmount);
        }
    }

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
        EnemyHealthManager healthManager = enemy.GetComponent<EnemyHealthManager>();

        while (healthManager.currentHealth > 0)
        {
            // Deal damage per second if the enemy is still valid
            healthManager.TakeDamage(damagePerSecond);

            // Wait for 1 second before applying the next damage
            yield return new WaitForSeconds(1f);
        } 
    } 
}