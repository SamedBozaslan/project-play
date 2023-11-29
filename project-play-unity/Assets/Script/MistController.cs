using UnityEngine;

public class MistController : MonoBehaviour
{
    public ParticleSystem mistParticleSystem;

    void Update()
    {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            StartMist();
        }

        // Check for left mouse button release
        if (Input.GetMouseButtonUp(0))
        {
            StopMist();
        }
    }

    void StartMist()
    {
        // Start the mist particle system
        mistParticleSystem.Play();
    }

    void StopMist()
    {
        // Stop the mist particle system
        mistParticleSystem.Stop();
    }
}
