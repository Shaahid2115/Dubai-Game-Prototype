using System;
using Core;
using Game.Config;
using Game.Core;
using Game.Level.Player.PlayerState;
using Injection;
using UnityEngine;

public sealed class UnitModel : Observable
{
    public float WalkSpeed;
    public float RotateSpeed;

    public UnitModel(float walkSpeed, float rotateSpeed)
    {
        WalkSpeed = walkSpeed;
        RotateSpeed = rotateSpeed;
    }
}

public abstract class StaffController : EntityUpdatableController
{
    public event Action<StaffController> ON_PURCHASED;
    public event Action<StaffController> ON_ARRIVED_HOME;
    public event Action<StaffController> ON_ARRIVED_TO_ITEM;
    public event Action<StaffController> ON_ARRIVED_TO_UTILITY;

    public abstract Transform InventoryHolder { get; }
    public abstract InventoryType TargetInventory { get; }
    public abstract int Area { get; }

    public int Inventories;

    public abstract void InitializeStaff();

    public abstract void Dispose();

    public abstract void WalkToItem(Vector3 position);

    public abstract void WalkHome();

    public abstract void ArrivedToUtility();

    public abstract void Idle();

    public abstract void ReadyToPurchase();

    public abstract void WalkToUtility(Vector3 position);

    public abstract void Hidden();

    public void FireStaffPurchased()
    {
        ON_PURCHASED?.Invoke(this);
    }

    public void FireStaffArrivedToUtility()
    {
        ON_ARRIVED_TO_UTILITY?.Invoke(this);
    }

    public void FireArrivedToItem()
    {
        ON_ARRIVED_TO_ITEM?.Invoke(this);
    }

    internal void FireArrivedHome()
    {
        ON_ARRIVED_HOME?.Invoke(this);
    }
}

public sealed class PlayerController : StaffController
{
    private const float _inventoryHeight = 0.6f;

    public event Action ON_IDLE;

    public readonly UnitModel Model;
    private readonly PlayerView _view;
    private readonly StateManager<PlayerState> _stateManager;

    public PlayerView View => _view;

    public override Transform InventoryHolder => _view.InventoryHolder;
    public override InventoryType TargetInventory => InventoryType.None;

    public override int Area => -1;

    public Vector3 GetInventoryPosition(int index)
    {
        return InventoryHolder.transform.position + new Vector3(0f, index * _inventoryHeight, 0f);
    }

    public PlayerController(PlayerView view, Context context)
    {
        _view = view;
        var subContext = new Context(context);
        var injector = new Injector(subContext);
        subContext.Install(this);
        subContext.InstallByType(this, typeof(PlayerController));
        subContext.Install(injector);
        _stateManager = new StateManager<PlayerState>();
        injector.Inject(_stateManager);

        var config = context.Get<GameConfig>();
        Model = new UnitModel(config.PlayerWalkSpeed, config.PlayerRotationSpeed);
    }

    public override void Dispose()
    {
        _stateManager.Dispose();
        GameObject.Destroy(_view.gameObject);
    }

    public void SwitchToState<T>(T instance) where T : PlayerState
    {
        _stateManager.SwitchToState(instance);
        _view.CurrentState = instance.GetType();
    }

    public override void WalkToItem(Vector3 position)
    {
    }

    public override void WalkHome()
    {
    }

    public override void ArrivedToUtility()
    {
    }

    public override void Idle()
    {
    }

    public override void WalkToUtility(Vector3 position)
    {
    }

    public override void InitializeStaff()
    {
    }

    public override void Hidden()
    {
    }

    public override void ReadyToPurchase()
    {
    }

    internal void FireIdle()
    {
        ON_IDLE?.Invoke();
    }
}

