#region Using Statements
using System;
using FreeFall.Shared.Framework.Input;
using FreeFall.Shared.Framework.Screens;
using FreeFall.Shared.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

#endregion

namespace FreeFall.Shared
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class FreeFallGame : Game
    {
        GraphicsDeviceManager graphics;
        private ScreenManager screenManager;
        private UtilityManager utilities;

        public enum Platform
        {
            MAC,
            WINDOWS,
            ANDROID,
            IOS
        }

        public Platform CurrentPlatform { get; private set; }

        public static FreeFallGame Instance { get; private set; }

        public FreeFallGame() : this(Platform.WINDOWS) { }

        public FreeFallGame(Platform platform)
        {
            Instance = this;

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";


            screenManager = new ScreenManager();
            utilities = new UtilityManager(this);


            CurrentPlatform = platform;
            switch(CurrentPlatform)
            {
                case Platform.MAC:
                    graphics.PreferredBackBufferHeight = 1920;
                    graphics.PreferredBackBufferWidth = 1080 / 2;
                    graphics.IsFullScreen = false;
                    Console.WriteLine("This is a Mac");
                    break;
                case Platform.IOS:
                    Console.WriteLine("This is an iPhone");
                    graphics.IsFullScreen = true;
                    break;
            }
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();

            utilities.Initialize();
            screenManager.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //TODO: use this.Content to load your game content here 
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // For Mobile devices, this logic will close the Game when the Back button is pressed
            // Exit() is obsolete on iOS
        #if !__IOS__ && !__TVOS__
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
        #endif
            
            InputHandler.Instance.Update(gameTime);


        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Aquamarine);

            screenManager.CurrentScreen.Draw(gameTime);
        
        }


    }
}
