using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyPickup : MonoBehaviour
{
    // Event delegate for when the object is picked up
    public delegate void OnPickupAction();
    public TextMeshProUGUI text;

    public event OnPickupAction OnPickup;
    public int moneyValue = 10; // Amount of money to add when picked up
    public Text moneyText; // Reference to the UI Text component displaying the money amount

    private int totalMoney = 0; // Total money collected by the player

    // Boolean to track if the object is currently picked up
    private bool isPickedUp = false;

    private void OnMouseEnter()
    {
        // If the object is not already picked up, trigger the pickup event
        if (!isPickedUp)
        {
            if (OnPickup != null)
                OnPickup.Invoke();

            isPickedUp = true;
            Destroy(gameObject);
            UpdateMoneyUI(moneyValue);
            totalMoney = moneyValue;
            text = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        }
    }

    public void UpdateMoneyUI(int money)
    {
        if(moneyText != null)
        {
            moneyText.text = "10 " + totalMoney.ToString();
        }

       
        
    }
}
