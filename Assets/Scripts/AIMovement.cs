using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public Transform[] waypoints; // Array of waypoint transforms
    public float moveSpeed = 5f; // Speed of AI movement
    private int currentWaypointIndex = 0; // Index of the current waypoint

    void Start()
    {
        if (waypoints.Length > 0)
        {
            MoveToNextWaypoint();
        }
        else
        {
            Debug.LogError("No waypoints assigned to AIMovement!");
        }
    }

    void Update()
    {
        // Check if AI has reached the current waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            // Move to the next waypoint
            MoveToNextWaypoint();
        }
        else
        {
            // Move towards the current waypoint
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, moveSpeed * Time.deltaTime);
        }
    }

    void MoveToNextWaypoint()
    {
        currentWaypointIndex++;
        // If all waypoints have been visited, reset to the first one
        if (currentWaypointIndex >= waypoints.Length)
        {
            currentWaypointIndex = 0;
        }
    }
}
