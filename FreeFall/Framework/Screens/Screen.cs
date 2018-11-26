using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace FreeFall.Framework.Screens
{

    public abstract class Screen
    {
        public abstract void Initialize();

        public abstract void LoadContent();

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime);
    }

}
