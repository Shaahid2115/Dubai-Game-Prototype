using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManeger : MonoBehaviour
{
    public static CustomerManeger Instance;
    public GameObject customerPrefab; // The prefab of the customer object
    public float spawnInterval = 30f; // Time interval between spawning new customers
    public Transform[] spawnPoint; // The position where customers will spawn
    public int maxQueueSize = 5; // Maximum number of customers allowed in the queue
    private int currentQueueSize = 0; // current number of customer in the queue
    public List<GameObject> SpawnCustomers = new List<GameObject>();
    public bool isCustomerQueueFull;
    public bool iscustomerwalk;

    public Transform[] TablePositions;
    public object money;
    public object food;

    void Start()
    {
        Instance = this;
        // Start spawning customers
        iscustomerwalk = false;
        isCustomerQueueFull = false;
        StartCoroutine(SpawnCustomer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnCustomer()
    {
        while (!isCustomerQueueFull)
        {
            if (currentQueueSize < maxQueueSize)
            {
             GameObject TempGameObject= Instantiate(customerPrefab, spawnPoint[currentQueueSize].position, spawnPoint[currentQueueSize].rotation);
                SpawnCustomers.Add(TempGameObject);
                NPCController npcCust = TempGameObject.GetComponent<NPCController>();
                npcCust.SetNewTarget(npcCust.currentTargetIndex);
                npcCust.currentTargetIndex++;
                iscustomerwalk = true;
                if(iscustomerwalk)
                {
                    ShuffleCustomers();
                }
                currentQueueSize++;
               
            }else
            {
                isCustomerQueueFull = true;
            }    

            yield return new WaitForSeconds(spawnInterval);
        }
    }
    public void CustomerLeft()
    {
        SpawnCustomers.RemoveAt(0);
        if(currentQueueSize==4&&isCustomerQueueFull)
        {
            isCustomerQueueFull = false;
            StartCoroutine(SpawnCustomer());
        }
        currentQueueSize--;

      

    }
    public void CustomerWalktoservingtable()
    {
        foreach (GameObject customer in SpawnCustomers)
        {
            NPCController npcController = customer.GetComponent<NPCController>();
            npcController.SetNewTarget(npcController.currentTargetIndex);
            npcController.currentTargetIndex++; // Move the customer to the serving table
            npcController.PickUpFoodAndDropMoney(); // Customer picks up food and drops money
        }

    }
    public void ShuffleCustomers()
    {
        
        for (int i = 1;i< SpawnCustomers.Count;i++)
        { 
            SpawnCustomers[i].GetComponent<NPCController>().WalkinintheQueue(spawnPoint[i - 1].transform);

        }
    }
}
