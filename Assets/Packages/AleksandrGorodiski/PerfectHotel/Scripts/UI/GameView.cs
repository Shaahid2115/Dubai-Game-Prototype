using System.Collections.Generic;
using Game.UI.Hud;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public sealed class GameView : MonoBehaviour
    {
        [SerializeField] public GameObject Player;
        [SerializeField] public BaseHud[] Huds;
        [SerializeField] public Joystick Joystick;
        [SerializeField] public CameraController CameraController;
        [SerializeField] private RectTransform HudBG;

        public IEnumerable<IHud> AllHuds()
        {
            foreach (var hud in Huds)
            {
                yield return hud;
            }
        }

        private void Awake()
        {
            SetHudBG();
        }

        private void SetHudBG()
        {
            bool isDeveloperIPad = GameConstants.IsDeveloperIPad();
            if (isDeveloperIPad)
            {
                var aspect = HudBG.GetComponent<AspectRatioFitter>();

                if (Screen.height < Screen.width)
                {
                    aspect.aspectMode = AspectRatioFitter.AspectMode.WidthControlsHeight;
                    aspect.aspectRatio = 1.77777f;
                }
                else
                {
                    aspect.aspectMode = AspectRatioFitter.AspectMode.HeightControlsWidth;
                    aspect.aspectRatio = 0.5625f;
                }
            }
            else
            {
                Screen.orientation = ScreenOrientation.Portrait;
            }
        }
    }
}