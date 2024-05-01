using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // The object to spawn
    public Transform spawnPoint; // The point where objects will be spawned
    public float spawnInterval = 10f; // Time interval between spawns
    public int maxObjects = 3; // Maximum number of objects allowed

    private int currentObjects = 0; // Current number of spawned objects
    private bool isSpawning = false; // Flag to prevent multiple simultaneous spawns

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (currentObjects < maxObjects)
            {
                SpawnObject();
            }
        }
    }

    private void SpawnObject()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);
            currentObjects++;
            StartCoroutine(ResetSpawnFlag());
        }
    }

    private IEnumerator ResetSpawnFlag()
    {
        yield return new WaitForSeconds(spawnInterval);
        isSpawning = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player entered the circle, do something if needed
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player exited the circle, do something if needed
        }
    }
}
