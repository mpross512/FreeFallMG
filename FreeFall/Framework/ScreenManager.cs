using System;
using FreeFall.Framework.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FreeFall.Framework
{

    public class ScreenManager
    {

        private Screen currentScreen;

        public ScreenManager()
        {
            currentScreen = new TitleScreen();
        }

        public static ScreenManager Instance {
            get {
                if (Instance == null)
                    Instance = new ScreenManager();
                return Instance;
            }
            set {
                Instance = value;
            }
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
