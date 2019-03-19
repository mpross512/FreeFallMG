using System;
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
        private Vector2 position;


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
        public int Width { get; set; }
        public int Height { get; set; }

        public static Player Instance { get; private set; }

        public Player()
        {
            Instance = this;
            texture = new Texture2D(FreeFallGame.Instance.GraphicsDevice, 1, 1);
        }

        public override void Initialize()
        {
            texture.SetData(new Color[] { Color.White });
            Width = PLAYER_WIDTH;
            Height = PLAYER_HEIGHT;
            position.X = Utilities.UtilityManager.SCREEN_WIDTH / 2 - (Width / 2);
            position.Y = Utilities.UtilityManager.SCREEN_HEIGHT / 3 - (Height / 2);
        }

        public override void LoadContent(ContentManager content)
        {

        }

        public override void Update(GameTime gameTime)
        {
            position.X += (int) (VelocityX * gameTime.ElapsedGameTime.TotalSeconds);
        }

        public override void Draw(GameTime gameTime)
        {
            Utilities.UtilityManager.SpriteBatch.Draw(texture, new Rectangle((int)(position.X), (int)position.Y, Width, Height), Color.IndianRed);
        }


    }
}
