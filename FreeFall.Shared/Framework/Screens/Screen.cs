using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace FreeFall.Shared.Framework.Screens {

    public abstract class Screen {

        protected SpriteBatch spriteBatch;

        public virtual void Initialize()
        {
            spriteBatch = Utilities.UtilityManager.SpriteBatch;
        }

        public abstract void LoadContent(ContentManager content);

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime);

        public abstract void HandleTouch(Vector2 position);

        public abstract void HandleTouch(Vector2 position, TouchLocationState touchState);

    }

}