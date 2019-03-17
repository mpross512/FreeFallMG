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

        public override void HandleTouch(Vector2 position)
        {
            
        }

        public override void HandleTouch(Vector2 position, TouchLocationState touchState)
        {
            if (position.Y < 1200 && touchState == TouchLocationState.Released)
                ScreenManager.Instance.CurrentScreen = new GameScreen();
        }

        public override void Initialize()
        {
            base.Initialize();
            rectangle.SetData(new Color[] { Color.White });
        }

        public override void LoadContent(ContentManager content)
        {
        }

        public override void Update(GameTime gameTime)
        {
        }


    }
}
