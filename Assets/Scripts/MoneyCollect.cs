using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollect : MonoBehaviour
{
    public GameObject collectParticlePrefab; // Particle effect prefab to display when collected

    private bool isCollected = false; // Flag to track if the object has been collected

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollected) // Check if the object is collided with the player and not already collected
        {
            Collect(); // Call the collect function
        }
    }

    private void Collect()
    {
        isCollected = true; // Set the flag to true to prevent multiple collections

        // Display particle effect at the collectible's position
        Instantiate(collectParticlePrefab, transform.position, Quaternion.identity);

        // Optionally, you can deactivate or destroy the collectible object after collecting it
        gameObject.SetActive(false);
        // or
        // Destroy(gameObject);
    }
}
