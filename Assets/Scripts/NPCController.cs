using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
public List<Transform> targets;
private NavMeshAgent agent;
public int currentTargetIndex = 0;
private bool isMoving = false;
private Animator anim;


void Start()
    {
       
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        // MoveToNextTarget();
        foreach (Transform Pos in CustomerManeger.Instance.TablePositions)
        {
            targets.Add(Pos);
        }
      
    }
void Update()
    {
        Debug.Log("Outsideif"+agent.remainingDistance);
        if (agent.remainingDistance < 0.1f)
        {
            anim.Play("Idle");

            // after customer reached check the serving table
           if(ServingTable.Instance.IsItemAvailable()&&currentTargetIndex==1)
            {
                ServingTable.Instance.TakeItem();

                SetNewTarget(currentTargetIndex);
            }
            else
            {
                Debug.Log("No Items on the table");
                SetNewTarget(currentTargetIndex);
            }
           
        }
    }

void MoveToNextTarget()
    {
        if (currentTargetIndex < targets.Count)
        {
            anim.Play("Walk");
            agent.SetDestination(targets[currentTargetIndex].position);
            isMoving = true;
            currentTargetIndex++;
        }
        else
        {
            
            Debug.Log("No more targets to move to.");
        }
    }

public void SetNewTarget(int newTargetValue)
    {
        agent.SetDestination(targets[newTargetValue].position);
        isMoving = true;
    }
    public void WalkinintheQueue(Transform newQueuePosition)
    {
        agent.SetDestination(newQueuePosition.position);
    }

    internal void PickUpFoodAndDropMoney()
    {
        throw new NotImplementedException();
    }

}
