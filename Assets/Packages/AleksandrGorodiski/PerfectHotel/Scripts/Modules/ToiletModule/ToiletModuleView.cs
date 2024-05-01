using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Modules.ToiletModule
{
    public sealed class ToiletModuleView : MonoBehaviour
    {
        [HideInInspector]
        public ToiletView[] ToiletViews;

        private void Awake()
        {
            ToiletViews = GetComponentsInChildren<ToiletView>();
        }
    }
}

