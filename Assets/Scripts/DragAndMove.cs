using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndMove : MonoBehaviour
{
    private Vector3 offset; // Offset between touch position and object position

    void OnMouseDown()
    {
        // Calculate offset between touch position and object position
        offset = gameObject.transform.position - GetTouchPosition();
    }

    void OnMouseDrag()
    {
        // Update object position based on touch position with offset
        Vector3 newPosition = GetTouchPosition() + offset;
        // Clamp the newPosition within the screen bounds
        newPosition.x = Mathf.Clamp(newPosition.x, 0f, Screen.width);
        newPosition.y = Mathf.Clamp(newPosition.y, 0f, Screen.height);
        // Convert the newPosition from screen coordinates to world coordinates
        newPosition = Camera.main.ScreenToWorldPoint(newPosition);
        // Update object position
        transform.position = newPosition;
    }

    Vector3 GetTouchPosition()
    {
        // Get touch position for both mouse and touch input
        Vector3 touchPosition = Input.mousePosition;
        // For touch input
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
        }
        return touchPosition;
    }
}
