using System;
using Microsoft.Xna.Framework.Graphics;

namespace FreeFall.Framework
{
    public class GameComponents
    {

        public GameComponents()
        {
        }

        public static GameComponents Instance
        {
            get
            {
                if (Instance == null)
                    Instance = new GameComponents();
                return Instance;
            }
            set
            {
                Instance = value;
            }
        }

        public SpriteBatch SpriteBatch { get; set; }
    }
}
