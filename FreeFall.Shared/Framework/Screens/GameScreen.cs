using System;
using FreeFall.Shared.Entities;
using FreeFall.Shared.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace FreeFall.Shared.Framework.Screens
{
    public class GameScreen : Screen
    {
    
        private bool alternateControlScheme, movingLeft;
        private Texture2D test;

        public GameScreen()
        {
            //EntityManager = new EntityManager();
            alternateControlScheme = true;
            movingLeft = false;
        }

        public override void Draw(GameTime gameTime)
        {
            UtilityManager.SpriteBatch.Begin();
            //UtilityManager.SpriteBatch.Draw(test, new Rectangle(0, 0, 144, 256), Color.White);

            ScreenManager.EntityManager.Draw(gameTime);

            UtilityManager.SpriteBatch.End();
        }

        public override void Initialize()
        {
            base.Initialize();
            ScreenManager.EntityManager.Initialize();
        }

        public override void LoadContent(ContentManager content)
        {
            ScreenManager.EntityManager.LoadContent(content);
            test = content.Load<Texture2D>("Images/TestTexture");
        }

        public override void Update(GameTime gameTime)
        {
            HandleTouch();
            ScreenManager.EntityManager.Update(gameTime);
        }

        public void HandleTouch()
        {

            if (alternateControlScheme)
            {
                foreach (TouchLocation touch in TouchPanel.GetState())
                {
                    if (touch.State == TouchLocationState.Released)
                        movingLeft = !movingLeft;
                }
            }


            if (TouchPanel.GetState().Count > 0)
            {
                if (alternateControlScheme)
                {
                    if (movingLeft)
                        Player.Instance.VelocityX = -Player.VELOCITY;
                    else
                        Player.Instance.VelocityX = Player.VELOCITY;
                }
                else
                {
                    if (TouchPanel.GetState()[TouchPanel.GetState().Count - 1].Position.X <= UtilityManager.SCREEN_WIDTH / 2)
                        Player.Instance.VelocityX = -Player.VELOCITY;
                    else
                        Player.Instance.VelocityX = Player.VELOCITY;
                }
            }
            else
            {
                Player.Instance.VelocityX = 0;
            }


        }

    }
}
