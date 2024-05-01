using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class PIckUP : MonoBehaviour
{
    public GameObject WhatCanIPickup;
    public GameObject PlayerHandLeft;
    public GameObject Dropoff;
    public Transform PickUpArea;
    public TextMeshProUGUI text;
    public bool iHaveSomething = false;

  
    public void PickUpObject()
    {
        if (iHaveSomething)
        {
            WhatCanIPickup.transform.parent = null;
            WhatCanIPickup.transform.localPosition=Dropoff.transform.position;
            iHaveSomething = false;
        }
        else
        {
            if (WhatCanIPickup != null)
            {
             
                WhatCanIPickup.transform.SetParent(PlayerHandLeft.transform);
                WhatCanIPickup.transform.localScale = new Vector3(1f, 1f,1f);
                float dist = Vector3.Distance(PickUpArea.position, transform.position);
                print("Distance to pickUpAREA");
                iHaveSomething = true;
            }
            else
            {
                print("Ï got the food");
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickable"))
        {
            WhatCanIPickup= other.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Pickable"))
        {
            WhatCanIPickup = other.gameObject;
        }
    }
}
