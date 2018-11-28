using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace FreeFall.Entity
{
    public abstract class Entity
    {

        public int X { get; set; }
        public int Y { get; set; }

        public int VelocityX { get; set; }
        public int VelocityY { get; set; }

        public abstract void Initialize();

        public abstract void LoadContent(ContentManager content);

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime);


    }
}
