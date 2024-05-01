using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoatController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;
    public float smoothing = 5f;



  void Start()
{
    agent = GetComponent<NavMeshAgent>();
    updateDestination();
    agent.updateRotation = false; // Disable the NavMeshAgent's auto-rotation
}

void Update()
{
    if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
    {
        if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
        {
            IterateWaypointIndex();
            updateDestination();
        }
    }

    // Control rotation manually
    if (agent.desiredVelocity != Vector3.zero)
    {
        Quaternion lookRotation = Quaternion.LookRotation(agent.desiredVelocity);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * smoothing);
    }
}


    void updateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    void IterateWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

}
