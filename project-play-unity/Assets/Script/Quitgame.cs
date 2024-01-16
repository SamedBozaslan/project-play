using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quitgame : MonoBehaviour
{
    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Call a function to handle game exit (you can replace this with your own logic)
            ExitGame();
        }
    }

    void ExitGame()
    {
        // Log a message to the console (you can remove this line if you don't need it)
        Debug.Log("Exiting the game");

        // Quit the application (works for both standalone and editor)
        Application.Quit();
    }
}
