using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace FreeFall.Shared.Framework.Screens
{
    public class ScreenManager
    {

        public static ScreenManager Instance { get; private set; }

        public ScreenManager()
        {
            Instance = this;
        }

        public Screen CurrentScreen { get; set; }

        public void Initialize()
        {
            CurrentScreen = new TitleScreen();
            CurrentScreen.Initialize();
        }

        public void LoadContent(ContentManager content)
        {
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
