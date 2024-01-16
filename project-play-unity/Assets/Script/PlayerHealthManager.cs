using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerHealthManager : MonoBehaviour
{
    public int currentHealth = 50;
    public int healthPerHeart = 10;
    public int numOfHearts = 5;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public void TakeDamage(int damage)
    {
        // Reduce health
        currentHealth -= damage;

        // Ensure health doesn't go below 0
        currentHealth = Mathf.Max(0, currentHealth);

        // Update UI hearts based on current health
        for (int i = 0; i < hearts.Length; i++)
        {
            // Calculate the health value for the current heart
            int heartValue = (i + 1) * healthPerHeart;

            // Update sprite and enable/disable based on health value
            if (currentHealth >= heartValue)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            // Enable or disable hearts based on the number of hearts
            hearts[i].enabled = i < numOfHearts;
        }

        // Check if the player is defeated
        if (currentHealth <= 0)
        {
            // Perform defeat actions (e.g., play animation, game over)
            Debug.Log("Player defeated");
            // You can add more actions as needed
            Destroy(gameObject);
            SceneManager.LoadScene(2);

        }
    }
}

