using UnityEngine;

public sealed class ItemUtilityView : ItemView
{
    [SerializeField] private InventoryType _inventory;
    [SerializeField] private Transform _aimTransform;

    public InventoryType Inventory => _inventory;
    public Vector3 AimPosition => _aimTransform.position;
}
