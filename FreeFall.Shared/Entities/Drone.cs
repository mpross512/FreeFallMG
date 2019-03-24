using System;
using FreeFall.Shared.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FreeFall.Shared.Entities
{
    public class Drone : Entity
    {

        private static Random random = new Random();

        public const int DRONE_WIDTH = 26;
        public const int DRONE_HEIGHT = 12;
        public const int DRONE_VELOCITY = 100;
        public const string DRONE_PATH = "Images/Drone";

        private static int offset = 0;
        private int thisOffset;
        private static Drone bottomDrone;


        public Drone()
        {
            thisOffset = offset++;
            bottomDrone = this;
            EntityType = EntityTypes.DRONE;
            boundingRectangle = new Rectangle();
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(texture, boundingRectangle, Color.White);
            //spriteBatch.Draw(Player.Instance.Texture, new Rectangle(0, (int)position.Y + (DRONE_HEIGHT), UtilityManager.SCREEN_WIDTH, DRONE_HEIGHT * 7), Color.BlanchedAlmond);
        }

        public override void Initialize() 
        {
            Width = DRONE_WIDTH;
            Height = DRONE_HEIGHT;
            boundingRectangle.Width = Width;
            boundingRectangle.Height = Height;
            position.Y = UtilityManager.SCREEN_HEIGHT + (thisOffset * DRONE_HEIGHT * 8);
            position.X = random.Next(UtilityManager.SCREEN_WIDTH - DRONE_WIDTH);
        }

        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(DRONE_PATH);
        }

        public override void Update(GameTime gameTime)
        {
            position.Y -= (int) (DRONE_VELOCITY * gameTime.ElapsedGameTime.TotalSeconds);

            if (position.Y + Height <= 0) {
                position.Y = bottomDrone.position.Y + (DRONE_HEIGHT * 8);
                position.X = random.Next(UtilityManager.SCREEN_WIDTH - Width);
                bottomDrone = this;
            }
            boundingRectangle.X = (int) position.X;
            boundingRectangle.Y = (int) position.Y;

        }
    }
}
