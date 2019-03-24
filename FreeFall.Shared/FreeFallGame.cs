﻿#region Using Statements
using System;
using FreeFall.Shared.Framework.Input;
using FreeFall.Shared.Framework.Screens;
using FreeFall.Shared.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

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
        private UtilityManager utilityManager;
        private RenderTarget2D scene;
        private float resolutionProportion;

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
            utilityManager = new UtilityManager(this);

            CurrentPlatform = platform;
            switch(CurrentPlatform)
            {
                case Platform.MAC:
                    graphics.PreferredBackBufferHeight = 1920;
                    graphics.PreferredBackBufferWidth = 1080 / 2;
                    graphics.IsFullScreen = false;
                    break;
                case Platform.IOS:
                    graphics.IsFullScreen = true;
                    break;
            }
            graphics.ApplyChanges();

            resolutionProportion = (float) Window.ClientBounds.Width / UtilityManager.SCREEN_WIDTH;
            //Console.WriteLine("Window Size: {0} Screen Width: {1} Proportion: {2}", Window.ClientBounds.Width, UtilityManager.SCREEN_WIDTH, resolutionProportion);
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
            scene = new RenderTarget2D(graphics.GraphicsDevice, UtilityManager.SCREEN_WIDTH, UtilityManager.SCREEN_HEIGHT);

            utilityManager.Initialize();
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

            resolutionProportion = (float)Window.ClientBounds.Width / UtilityManager.SCREEN_WIDTH;


            //InputHandler.Instance.Update(gameTime);
            ScreenManager.Instance.CurrentScreen.Update(gameTime);

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(scene);
            GraphicsDevice.Clear(Color.Aquamarine);

            screenManager.CurrentScreen.Draw(gameTime);

            GraphicsDevice.SetRenderTarget(null);

            UtilityManager.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque, SamplerState.PointClamp);
            UtilityManager.SpriteBatch.Draw(
                scene, 
                new Rectangle(0, 0, 
                    (int) (resolutionProportion * (float) UtilityManager.SCREEN_WIDTH), 
                    (int) (resolutionProportion * (float) UtilityManager.SCREEN_HEIGHT)), 
                Color.White);
            UtilityManager.SpriteBatch.End();

            //Console.WriteLine("Actual Resolution: {0} Height: {1} Proportion: {2}", Window.ClientBounds.Width, Window.ClientBounds.Height, (float) Window.ClientBounds.Height / Window.ClientBounds.Width);
        
        }


    }
}
