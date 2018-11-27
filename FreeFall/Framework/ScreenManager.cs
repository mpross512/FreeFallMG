using System;
using FreeFall.Framework.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace FreeFall.Framework
{

    public class ScreenManager
    {

        private static ScreenManager screenManager;

        private Screen currentScreen;

        public ScreenManager()
        {
            currentScreen = new TitleScreen();
        }

        public static ScreenManager GetInstance() {
            if (screenManager == null)
                screenManager = new ScreenManager();
            return screenManager;
        }

        public void Initialize() {
            currentScreen.Initialize();
        }

        public void LoadContent(ContentManager content) {
            currentScreen.LoadContent();
        }

        public void Update(GameTime gameTime) {
            currentScreen.Update(gameTime);
        }

        public void Draw(GameTime gameTime) {
            currentScreen.Draw(gameTime);
        }

        public void SwitchScreen(Screen newScreen) {
            currentScreen = newScreen;
        }

    }

}
