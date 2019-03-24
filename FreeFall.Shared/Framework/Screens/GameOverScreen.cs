using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

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
        }


    }
}
