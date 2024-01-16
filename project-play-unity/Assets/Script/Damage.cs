using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [Header("Player damage to Enemy")]
    public int damageToEnemy = 2;
    [Header("Enemy damage to Player")]
    public int damageToPlayer = 1;

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Enemy"))
        {
            ApplyDamageToEnemy(other);
        }
        if (other.CompareTag("Player"))
        {
            ApplyDamageToPlayer(other);
            Debug.Log("damage");
        }
    }

    private void ApplyDamageToEnemy(GameObject enemy)
    {
        EnemyController healthManager = enemy.GetComponent<EnemyController>();

        // Apply damage to the enemy
        healthManager.TakeDamage(damageToEnemy);
    }

    private void ApplyDamageToPlayer(GameObject player)
    {
        PlayerHealthManager healthManager = player.GetComponent<PlayerHealthManager>();

        // Apply damage to the player
        healthManager.TakeDamage(damageToPlayer);
    }
}