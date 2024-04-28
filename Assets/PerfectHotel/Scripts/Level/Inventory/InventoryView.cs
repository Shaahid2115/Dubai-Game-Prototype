using UnityEngine;

public enum InventoryType
{
    None,
    ToiletPaper,
    SodaCan
}

namespace Game.Level.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        public Vector3 Position
        {
            get { return transform.position; }
            set { transform.position = value; }
        }
    }
}