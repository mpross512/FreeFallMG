using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FreeFall.Shared.Utilities
{
    public class UtilityManager
    {

        private FreeFallGame gameInstance;

        public static UtilityManager Instance { get; private set; }

        public static SpriteBatch SpriteBatch { get; private set; }

        public const int SCREEN_WIDTH = 144;
        public const int SCREEN_HEIGHT = 256;

        public UtilityManager(FreeFallGame gameInstance)
        {
            Instance = this;
            this.gameInstance = gameInstance;
        }

        public void Initialize()
        {
            SpriteBatch = new SpriteBatch(gameInstance.GraphicsDevice);
        }

        public void LoadContent(ContentManager content)
        {

        }


    }
}
