using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public TextMeshProUGUI text;
    private void Start()
    {
        text = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        MoneyPickup pickupScript = GetComponent<MoneyPickup>();
        if (pickupScript != null)
        {
            pickupScript.OnPickup += HandlePickup;
        }

    }

    private void HandlePickup()
    {
        int newScore = int.Parse(text.text) + 1;
        text.text = newScore.ToString();
    }
}
