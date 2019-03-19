using System;
using FreeFall.Shared.Framework.Screens;
using FreeFall.Shared.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

namespace FreeFall.Shared.Framework.Input
{
    public class InputHandler
    {

        private bool touchScreen;

        private static InputHandler instance;

        public static InputHandler Instance
        {
            get
            {
                if (instance == null)
                    instance = new InputHandler();
                return instance;
            }
        }

        public InputHandler()
        {
            TouchPanel.DisplayWidth = UtilityManager.SCREEN_WIDTH;
            TouchPanel.DisplayHeight = UtilityManager.SCREEN_HEIGHT;
            touchScreen = (FreeFallGame.Instance.CurrentPlatform == FreeFallGame.Platform.ANDROID
                            || FreeFallGame.Instance.CurrentPlatform == FreeFallGame.Platform.IOS);
            TouchPanel.EnableMouseTouchPoint = true;
        }

        public void Update(GameTime gameTime)
        {

        }


    }
}
