using System.Collections.Generic;
using Game.Level.Utility;
using Game.UI.Pool;
using UnityEngine;

namespace Game.Modules.Utility
{
    public sealed class UtilityModuleView : MonoBehaviour
    {
        public ComponentPoolFactory ToiletPaperPool;
        public ComponentPoolFactory SadaCanPool;

        [HideInInspector]
        public UtilityView UtilityView;
        [HideInInspector]
        public LoaderView[] LoaderViews;

        public readonly Dictionary<InventoryType, ComponentPoolFactory> InventoryMap;

        public UtilityModuleView()
        {
            InventoryMap = new Dictionary<InventoryType, ComponentPoolFactory>();
        }

        private void Awake()
        {
            LoaderViews = GetComponentsInChildren<LoaderView>();
            UtilityView = GetComponentInChildren<UtilityView>();

            InventoryMap[InventoryType.ToiletPaper] = ToiletPaperPool;
            InventoryMap[InventoryType.SodaCan] = SadaCanPool;
        }
    }
}

