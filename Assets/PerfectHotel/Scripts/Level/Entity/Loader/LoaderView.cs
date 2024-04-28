using Game.Config;
using UnityEngine;

public sealed class LoaderView : EntityWithHudView
{
    [SerializeField] private InventoryType _targetInventory;
    [SerializeField] private LoaderConfig _config;
    [SerializeField] private LoaderUnitView _unitView;
    [SerializeField] private ItemView _itemBuyUpdateView;

    public InventoryType TargetInventory => _targetInventory;
    public LoaderConfig Config => _config;
    public LoaderUnitView UnitView => _unitView;
    public ItemView ItemBuyUpdateView => _itemBuyUpdateView;
}
