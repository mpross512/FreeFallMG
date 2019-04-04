using System;
using FreeFall.Shared.Utilities;
using FreeFall.Shared.Framework.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FreeFall.Shared.Entities
{
    public class Player : Entity
    {


        public const int VELOCITY = 300;
        public const int PLAYER_WIDTH = 16;
        public const int PLAYER_HEIGHT = 22;
        public const string PLAYER_PATH = "Images/MalePlayer";
        public const string ANIMATION_PATH = "Animations/MalePlayerFalling";

        public PlayerPosition Lane { get; set; }

        public bool Alive { get; private set; }

        public enum PlayerPosition
        {
            LEFT,
            CENTER,
            RIGHT
        }

        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public int VelocityX { get; set; }
        public bool Shield { get; set; }
        public Texture2D Texture {
            get
            {
                return texture;
            }
        }

        public static Player Instance { get; set; }

        public Player()
        {
            Instance = this;
            Lane = PlayerPosition.CENTER;
            //texture = new Texture2D(FreeFallGame.Instance.GraphicsDevice, 1, 1);
            EntityType = EntityTypes.PLAYER;
            boundingRectangle = new Rectangle();
            Alive = true;
        }

        public override void Initialize()
        {
            //texture.SetData(new Color[] { Color.White });
            Width = PLAYER_WIDTH;
            Height = PLAYER_HEIGHT;
            boundingRectangle.Width = Width;
            boundingRectangle.Height = Height;
            position.X = UtilityManager.SCREEN_WIDTH / 2 - (Width / 2);
            position.Y = UtilityManager.SCREEN_HEIGHT / 3 - (Height / 2);
            boundingRectangle.Y = (int)position.Y;
        }

        public override void LoadContent(ContentManager content)
        {
            //texture = content.Load<Texture2D>(PLAYER_PATH);
            animationTexture = content.Load<Texture2D>(ANIMATION_PATH);
            animation = new Animation(animationTexture, 18, 18);
        }

        public override void Update(GameTime gameTime)
        {
            switch(Lane)
            {
                case PlayerPosition.CENTER:
                    if (position.X + (Width / 2) > UtilityManager.SCREEN_WIDTH / 2)
                        position.X -= (int)(VELOCITY * gameTime.ElapsedGameTime.TotalSeconds);
                    if (position.X + (Width / 2) < UtilityManager.SCREEN_WIDTH / 2)
                        position.X += (int)(VELOCITY * gameTime.ElapsedGameTime.TotalSeconds);
                    break;
                case PlayerPosition.LEFT:
                    if (position.X + (Width / 2) > UtilityManager.SCREEN_WIDTH / 4)
                        position.X -= (int)(VELOCITY * gameTime.ElapsedGameTime.TotalSeconds);
                    break;
                case PlayerPosition.RIGHT:
                    if (position.X + (Width / 2) < UtilityManager.SCREEN_WIDTH * 3 / 4)
                        position.X += (int)(VELOCITY * gameTime.ElapsedGameTime.TotalSeconds);
                    break;
            }

            //position.X = MathHelper.Clamp(
            //    (int) (position.X + (int)(VelocityX * gameTime.ElapsedGameTime.TotalSeconds)), //Actual Value
            //    0, //Minimum Value
            //    UtilityManager.SCREEN_WIDTH - Width); //Maximum Value
            boundingRectangle.X = (int) position.X;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(animationTexture, boundingRectangle, animation.GetKeyFrame(gameTime), Color.White);
        }

        public void HandleCollision(Entity entity)
        {
            if (entity.EntityType == EntityTypes.DRONE)
            {
                if(!Shield)
                {
                    Alive = false;
                    ScreenManager.Instance.CurrentScreen = new GameOverScreen();
                }
            }
        }


    }
}
