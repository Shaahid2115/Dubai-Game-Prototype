using Game.Config;
using UnityEngine;

public sealed class CleanerView : EntityWithHudView
{
    [SerializeField] private ItemType _targetItem;
    [SerializeField] private CleanerConfig _config;
    [SerializeField] private CleanerUnitView _unitView;
    [SerializeField] private ItemView _itemBuyUpdateView;

    public ItemType TargetItem => _targetItem;
    public CleanerConfig Config => _config;
    public CleanerUnitView UnitView => _unitView;
    public ItemView ItemBuyUpdateView => _itemBuyUpdateView;
}
