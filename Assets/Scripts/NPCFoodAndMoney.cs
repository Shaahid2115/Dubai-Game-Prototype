using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFoodAndMoney : MonoBehaviour
{
    public GameObject foodPrefab; // The prefab for the food item
    public GameObject moneyPrefab; // The prefab for the money item
    public Transform dropPoint; // The point where money will be dropped

    private bool hasFood = false; // Flag to track if NPC has food

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food")) // Check if the NPC has collided with food
        {
            Destroy(other.gameObject); // Destroy the food item
            hasFood = true; // Set flag to true
        }
    }

    private void Update()
    {
        if (hasFood)
        {
            DropMoney(); // Call method to drop money
            hasFood = false; // Reset flag
        }
    }

    private void DropMoney()
    {
        GameObject money = Instantiate(moneyPrefab, dropPoint.position, Quaternion.identity); // Instantiate money prefab
        Destroy(money, 5f); // Destroy money after 5 seconds (adjust as needed)
    }
}
