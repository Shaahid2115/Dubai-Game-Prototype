using Core;
using UnityEngine;

public enum ItemType
{
    None,
    Clean,
    CashPile,
    BuyUpdate,
    ReceptionDesk,
    DropInventory,
    ShowHud,
    GetInventory
}

public class ItemView : BehaviourWithModel<ItemModel>
{
    [SerializeField] private ItemType _type;
    public ItemType Type => _type;

    protected override void OnModelChanged(ItemModel model)
    {
    }

    public Vector3 Position
    {
        get { return transform.position; }
    }
}