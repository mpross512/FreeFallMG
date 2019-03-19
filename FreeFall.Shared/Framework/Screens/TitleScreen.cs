using System;
using FreeFall.Shared.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace FreeFall.Shared.Framework.Screens
{
    public class TitleScreen : Screen
    {

        private Texture2D rectangle;

        public TitleScreen()
        {
            rectangle = new Texture2D(FreeFallGame.Instance.GraphicsDevice, 1, 1);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(rectangle, new Rectangle(0, 0, 60, 60), Color.Chocolate);

            spriteBatch.End();
        }

        public void HandleTouch()
        {
            foreach (TouchLocation touch in TouchPanel.GetState())
            {
                //Console.WriteLine("X: {0} + Y: {1}", touch.Position.X, touch.Position.Y);
                if (touch.State == TouchLocationState.Released)
                    ScreenManager.Instance.CurrentScreen = new GameScreen();
            }
        }

        public override void Initialize()
        {
            base.Initialize();
            rectangle.SetData(new Color[] { Color.White });
            TouchPanel.DisplayWidth = UtilityManager.SCREEN_WIDTH;
            TouchPanel.DisplayHeight = UtilityManager.SCREEN_HEIGHT;
            TouchPanel.EnableMouseTouchPoint = true;

        }

        public override void LoadContent(ContentManager content)
        {
        }

        public override void Update(GameTime gameTime)
        {
            HandleTouch();
        }


    }
}
