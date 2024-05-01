using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.SceneManagement;

public class ClickToMove : MonoBehaviour
{
    public Camera mainCamera; // The camera used to view the scene
    public NavMeshAgent agent; // NavMeshAgent component to move the character
    public float smoothing = 5f; // Smoothing factor for camera movement
    public Animator anim;// Animation Controller
    private bool isMoving=false; // Check if player is moving 

    private Vector3 cameraInitialPosition; // To store the initial camera position

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main; // Default to the main camera if not set
        }

        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>(); // Get the NavMeshAgent component
        }

        // Store the initial camera position relative to the player
        cameraInitialPosition = mainCamera.transform.position - transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) // Check if the left mouse button is held down
        {
           
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point); // Set the destination to the point where the ray intersects a collider
                anim.Play("Walk");
            }
           

        }


        // Update camera position to follow the player smoothly
        Vector3 desiredPosition = transform.position + cameraInitialPosition;
        Vector3 smoothedPosition = Vector3.Lerp(mainCamera.transform.position, desiredPosition, smoothing * Time.deltaTime);
        mainCamera.transform.position = smoothedPosition;
    }


   
}
