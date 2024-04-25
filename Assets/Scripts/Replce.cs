using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replce : MonoBehaviour
{
    public GameObject replacementPrefab; // The prefab to replace the touched object with

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            // Get the touch position
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;

            // Check if the touch collides with any objects
            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);
            if (hit.collider != null)
            {
                // Destroy the touched object
                Destroy(hit.collider.gameObject);

                // Instantiate the replacement prefab in the same position
                Instantiate(replacementPrefab, hit.collider.transform.position, Quaternion.identity);
            }
        }
    }
}
