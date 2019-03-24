using System;
using FreeFall.Shared.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FreeFall.Shared.Entities
{
    public abstract class Entity
    {

        public enum EntityTypes
        {
            PLAYER,
            DRONE,
            ROCKET
        }

        public EntityTypes EntityType { get; protected set; }

        protected Texture2D texture, animationTexture;
        protected SpriteBatch spriteBatch = UtilityManager.SpriteBatch;
        protected Vector2 position = Vector2.Zero;
        protected Animation animation;

        public Rectangle BoundingRectangle
        {
            get
            {
                return boundingRectangle;
            }
        }
        protected Rectangle boundingRectangle;

        protected int Width { get; set; }
        protected int Height { get; set; }

        public abstract void Initialize();

        public abstract void LoadContent(ContentManager content);

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime);
    }
}
