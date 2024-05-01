using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemPickUp : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject grabbedObject;
    private Vector3 offset;
    public TextMeshProUGUI text;
    void Start()
    {
        mainCamera = Camera.main;
        text = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit hit;
                Ray ray = mainCamera.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null && hit.collider.CompareTag("Grabbable"))
                    {
                        grabbedObject = hit.collider.gameObject;
                        offset = grabbedObject.transform.position - hit.point;
                        int newScore = int.Parse(text.text) + 1;
                        text.text = newScore.ToString();
                    }
                }
            }
            else if (touch.phase == TouchPhase.Moved && grabbedObject != null)
            {
                Ray ray = mainCamera.ScreenPointToRay(touch.position);
                Vector3 newPosition = ray.GetPoint(offset.magnitude);
                grabbedObject.transform.position = newPosition + offset;
            }
            else if (touch.phase == TouchPhase.Ended && grabbedObject != null)
            {
                grabbedObject = null;
            }
        }
    }
}
