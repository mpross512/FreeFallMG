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
        public const int DRONE_HEIGHT = 17;
        public const int DRONE_VELOCITY = 150;
        public const string DRONE_PATH = "Images/Drone";
        public const string ANIMATION_PATH = "Animations/Drone";
        
        private static int offset;
        private int thisOffset;
        private static Drone bottomDrone;


        public Drone()
        {
            thisOffset = offset++;
            if (bottomDrone != null)
                position.Y = bottomDrone.position.Y + (DRONE_HEIGHT * 5);
            else
                position.Y = UtilityManager.SCREEN_HEIGHT;
            bottomDrone = this;
            EntityType = EntityTypes.DRONE;
            boundingRectangle = new Rectangle();
            ScoreCounted = false;
        }

        public override void Draw(GameTime gameTime)
        {
            //spriteBatch.Draw(texture, boundingRectangle, Color.White);
            spriteBatch.Draw(animationTexture, boundingRectangle, animation.GetKeyFrame(gameTime), Color.White);
            //spriteBatch.Draw(Player.Instance.Texture, new Rectangle(0, (int)position.Y + (DRONE_HEIGHT), UtilityManager.SCREEN_WIDTH, DRONE_HEIGHT * 7), Color.BlanchedAlmond);
        }

        public override void Initialize() 
        {
            Width = DRONE_WIDTH;
            Height = DRONE_HEIGHT;
            boundingRectangle.Width = Width;
            boundingRectangle.Height = Height;
            position.X = random.Next(UtilityManager.SCREEN_WIDTH - DRONE_WIDTH);
            boundingRectangle.X = (int)position.X;
            boundingRectangle.Y = (int)position.Y;
        }

        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(DRONE_PATH);
            animationTexture = content.Load<Texture2D>(ANIMATION_PATH);
            animation = new Animation(animationTexture, 36, 36);
        }

        public override void Update(GameTime gameTime)
        {
            position.Y -= (int) (DRONE_VELOCITY * gameTime.ElapsedGameTime.TotalSeconds);

            if (position.Y + Height <= 0) {
                position.Y = bottomDrone.position.Y + (DRONE_HEIGHT * 5);
                position.X = random.Next(UtilityManager.SCREEN_WIDTH - Width);
                bottomDrone = this;
                ScoreCounted = false;
            }
            boundingRectangle.X = (int) position.X;
            boundingRectangle.Y = (int) position.Y;

        }
    }
}
