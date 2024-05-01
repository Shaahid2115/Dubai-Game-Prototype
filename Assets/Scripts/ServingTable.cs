using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServingTable : MonoBehaviour
{
    public static ServingTable Instance;
    public List<GameObject> Items = new List<GameObject>();
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool IsItemAvailable()
    {
        return Items.Count > 0;
    }

    public void TakeItem()
    {
        if (IsItemAvailable())
        {
            Items.RemoveAt(0);
        }
    }
}
