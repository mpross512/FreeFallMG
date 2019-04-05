using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using FreeFall.Shared.Utilities;

namespace FreeFall.Shared.Framework.Screens
{
    public class GameOverScreen : Screen
    {


        public GameOverScreen()
        {
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            UtilityManager.SpriteBatch.DrawString(UtilityManager.Font, ScreenManager.EntityManager.Score + "", Vector2.Zero, Color.White);

            ScreenManager.EntityManager.Draw(gameTime);

            spriteBatch.End();
        }

        public override void LoadContent(ContentManager content)
        {

        }

        public override void Update(GameTime gameTime)
        {
            HandleTouch();
        }

        public void HandleTouch()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                ScreenManager.Instance.CurrentScreen = new GameScreen();
            foreach(TouchLocation touch in TouchPanel.GetState())
                if(touch.State == TouchLocationState.Pressed)
                    ScreenManager.Instance.CurrentScreen = new GameScreen();
        }


    }
}
