using System;
using FreeFall.Shared.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FreeFall.Shared.Entities
{
    public class Drone : Entity
    {

        public const int DRONE_WIDTH = 26;
        public const int DRONE_HEIGHT = 12;
        public const string DRONE_PATH = "Images/Drone";


        public Drone()
        {
            EntityType = EntityTypes.DRONE;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(texture, new Rectangle((int) position.X, (int) position.Y, Width, Height), Color.White);
        }

        public override void Initialize() 
        {
            Width = DRONE_WIDTH;
            Height = DRONE_HEIGHT;
        }

        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(DRONE_PATH);
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
