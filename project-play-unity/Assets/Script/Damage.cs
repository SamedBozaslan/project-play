using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Damage : MonoBehaviour 
{

    [Header("Player damage to Enemy")]
    public int damagePerSecondToEnemy = 2;
    [Header("Enemy damage to Player")]
    public int DamagePerSecondToPlayer = 10;


   

    private void OnParticleCollision(GameObject other)
    {
        // Check if the collided object has the "Enemy" tag
        if (other.CompareTag("Enemy"))
        {
            // Apply damage over time
            StartCoroutine(ApplyDamageOverTimeEnemy(other));
        }
        if (other.CompareTag("Player"))
        {
            // Apply damage to the player
            StartCoroutine(ApplyDamageOverTimePlayer(other));
            Debug.Log("damage");
        }
    }

    private System.Collections.IEnumerator ApplyDamageOverTimeEnemy(GameObject Enemy)
    {
        EnemyController healthManager = Enemy.GetComponent<EnemyController>();

        while (healthManager.currentHealth > 0)
        {
            // Deal damage per second if the enemy is still valid
            healthManager.TakeDamage(damagePerSecondToEnemy);

            // Wait for 1 second before applying the next damage
            yield return new WaitForSeconds(1f);
        } 
    }

    private System.Collections.IEnumerator ApplyDamageOverTimePlayer(GameObject Player)
    {
        PlayerHealthManager healthManager = Player.GetComponent<PlayerHealthManager>();

        while (healthManager.currentHealth > 0)
        {
            // Deal damage per second if the enemy is still valid
            healthManager.TakeDamage(DamagePerSecondToPlayer);

            // Wait for 1 second before applying the next damage
            yield return new WaitForSeconds(1f);
        }
    }
}