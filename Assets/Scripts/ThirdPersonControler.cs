using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonControler : MonoBehaviour
{
    // Variables for movement
    public float moveSpeed = 5.0f;

    // Internal variables
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;

        // Apply movement
        controller.Move(moveDirection * Time.deltaTime);
    }
}
