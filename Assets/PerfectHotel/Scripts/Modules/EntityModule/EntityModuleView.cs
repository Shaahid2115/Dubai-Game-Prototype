using Game.Level.Utility;
using UnityEngine;

namespace Game.Level.Entity
{
    public sealed class EntityModuleView : MonoBehaviour
    {
        [HideInInspector] public AreaView[] AreaViews;
        [HideInInspector] public RoomView[] RoomViews;
        [HideInInspector] public CleanerView[] CleanerViews;
        //[HideInInspector] public LoaderView[] LoaderViews;
        [HideInInspector] public ToiletView[] ToiletViews;
        [HideInInspector] public UtilityView UtilityView;
        [HideInInspector] public ElevatorView[] ElevatorViews;

        private void Awake()
        {
            AreaViews = GetComponentsInChildren<AreaView>();
            RoomViews = GetComponentsInChildren<RoomView>();
            CleanerViews = GetComponentsInChildren<CleanerView>();
            //LoaderViews = GetComponentsInChildren<LoaderView>();
            ToiletViews = GetComponentsInChildren<ToiletView>();
            UtilityView = GetComponentInChildren<UtilityView>();
            ElevatorViews = GetComponentsInChildren<ElevatorView>();
        }
    }
}
