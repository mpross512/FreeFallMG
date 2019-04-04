using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

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
