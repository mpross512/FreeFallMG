using System;
using FreeFall.Shared.Framework.Screens;
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
            touchScreen = (FreeFallGame.Instance.CurrentPlatform == FreeFallGame.Platform.ANDROID
                            || FreeFallGame.Instance.CurrentPlatform == FreeFallGame.Platform.IOS);
        }

        public void Update(GameTime gameTime)
        {

            if(touchScreen)
            {
                foreach(TouchLocation touch in TouchPanel.GetState())
                {
                    Console.WriteLine("X: {0} + Y: {1}", touch.Position.X, touch.Position.Y);
                    ScreenManager.Instance.CurrentScreen.HandleTouch(touch.Position, touch.State);
                }
            }
            else
            {

            }


        }


    }
}
