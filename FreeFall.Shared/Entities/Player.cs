using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FreeFall.Shared.Entities
{
    public class Player : Entity
    {


        private const int VELOCITY = 20;
        
        public Player()
        {
            texture = new Texture2D(FreeFallGame.Instance.GraphicsDevice, 1, 1);
        }

        public override void Draw(GameTime gameTime)
        {
        }

        public override void Initialize()
        {
        }

        public override void LoadContent(ContentManager content)
        {
        }

        public override void Update(GameTime gameTime)
        {
        }


    }
}
