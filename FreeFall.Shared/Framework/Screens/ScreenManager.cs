using System;
using FreeFall.Shared.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace FreeFall.Shared.Framework.Screens
{
    public class ScreenManager
    {

        public static ScreenManager Instance { get; private set; }
        private Screen currentScreen;
        public static EntityManager EntityManager { get; set; }


        public ScreenManager()
        {
            Instance = this;
        }

        public Screen CurrentScreen
        {
            get
            {
                return currentScreen;
            }
            set
            {
                currentScreen = value;
                currentScreen.LoadContent(FreeFallGame.Instance.Content);
                currentScreen.Initialize();
            }
        }

        public void Initialize()
        {
            EntityManager = new EntityManager();
            CurrentScreen = new TitleScreen();
        }

        public void LoadContent(ContentManager content)
        {
            Console.WriteLine("Loading Screen Manager Content");
            CurrentScreen.LoadContent(content);
        }

        public void Update(GameTime gameTime)
        {
            CurrentScreen.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            CurrentScreen.Draw(gameTime);
        }


    }
}
