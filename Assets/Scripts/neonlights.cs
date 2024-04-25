using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class neonlights : MonoBehaviour
{
     public Material material; // Reference to the material you want to change
    public float scrollSpeed = 0.5f; // Speed at which colors will scroll
    public Color[] colors; // Array of colors to scroll through

    private int currentIndex = 0;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        // Check if it's time to change color
        if (timer >= scrollSpeed)
        {
            // Increment current index and reset timer
            currentIndex = (currentIndex + 1) % colors.Length;
            timer = 0f;

            // Change material color
            material.color = colors[currentIndex];
        }
    }
}
