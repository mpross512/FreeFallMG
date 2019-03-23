using System;
using FreeFall.Shared.Framework.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FreeFall.Shared.Entities
{
    public class Player : Entity
    {


        public const int VELOCITY = 150;
        public const int PLAYER_WIDTH = 30;
        public const int PLAYER_HEIGHT = 50;

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

        public static Player Instance { get; private set; }

        public Player()
        {
            Instance = this;
            texture = new Texture2D(FreeFallGame.Instance.GraphicsDevice, 1, 1);
            EntityType = EntityTypes.PLAYER;
            boundingRectangle = new Rectangle();
        }

        public override void Initialize()
        {
            texture.SetData(new Color[] { Color.White });
            Width = PLAYER_WIDTH;
            Height = PLAYER_HEIGHT;
            boundingRectangle.Width = Width;
            boundingRectangle.Height = Height;
            position.X = Utilities.UtilityManager.SCREEN_WIDTH / 2 - (Width / 2);
            position.Y = Utilities.UtilityManager.SCREEN_HEIGHT / 3 - (Height / 2);
            boundingRectangle.Y = (int)position.Y;
        }

        public override void LoadContent(ContentManager content)
        {

        }

        public override void Update(GameTime gameTime)
        {
            position.X = MathHelper.Clamp(
                (int) (position.X + (int)(VelocityX * gameTime.ElapsedGameTime.TotalSeconds)), 
                0, 
                Utilities.UtilityManager.SCREEN_WIDTH - Width);
            boundingRectangle.X = (int) position.X;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(texture, boundingRectangle, Color.IndianRed);
        }

        public void HandleCollision(Entity entity)
        {
            Console.WriteLine("Collision!");
            if (entity.EntityType == EntityTypes.DRONE)
            {
                if(!Shield)
                {
                    ScreenManager.Instance.CurrentScreen = new GameOverScreen();
                }
            }
        }


    }
}
