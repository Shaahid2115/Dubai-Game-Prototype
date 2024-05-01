using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator; // Reference to the animator component
    private bool isWalking = false; // Flag to track if the player is walking

    void Update()
    {
        // Check for left mouse button click or hold
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            // Start walking animation
            isWalking = true;
            animator.SetBool("isWalking", true);
        }
        else
        {
            // Stop walking animation
            isWalking = false;
            animator.SetBool("isWalking", false);
        }
    }

    void FixedUpdate()
    {
        // If player is walking, move the player forward
        if (isWalking)
        {
            // Assuming the player is moving along the z-axis
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
    }
}
