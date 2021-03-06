﻿using System;
using FreeFall.Shared.Entities;
using FreeFall.Shared.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace FreeFall.Shared.Framework.Screens
{
    public class GameScreen : Screen
    {

        private Texture2D test;

        private bool movingLeft;
        private KeyboardState prevKeyState;
        private GestureSample gesture;
        private bool playerMoved, alternateControlScheme; private int originalTouchX;
        private SpriteFont font;

        private int lastMoved;

        public GameScreen()
        {
            ScreenManager.EntityManager = new EntityManager();
            movingLeft = false;
            playerMoved = false;
            alternateControlScheme = true;
            font = UtilityManager.Font;
            originalTouchX = -1;
            Player.Instance.Lane = Player.PlayerPosition.CENTER;
        }

        public override void Draw(GameTime gameTime)
        {
            UtilityManager.SpriteBatch.Begin();
            //UtilityManager.SpriteBatch.Draw(test, new Rectangle(0, 0, 144, 256), Color.White);
            //UtilityManager.SpriteBatch.Draw(Player.Instance.Texture, new Rectangle(0, 0, UtilityManager.SCREEN_WIDTH, UtilityManager.SCREEN_HEIGHT), Color.BurlyWood);
            ScreenManager.EntityManager.Draw(gameTime);

            UtilityManager.SpriteBatch.DrawString(font, ScreenManager.EntityManager.Score + "", Vector2.Zero, Color.White);

            UtilityManager.SpriteBatch.End();
        }

        public override void Initialize()
        {
            base.Initialize();
            ScreenManager.EntityManager.Initialize();
            TouchPanel.EnabledGestures = GestureType.HorizontalDrag | GestureType.DragComplete;
        }

        public override void LoadContent(ContentManager content)
        {
            ScreenManager.EntityManager.LoadContent(content);
            test = content.Load<Texture2D>("Images/TestTexture");
        }

        public override void Update(GameTime gameTime)
        {
            HandleTouch(gameTime);
            ScreenManager.EntityManager.Update(gameTime);
        }

        public void HandleTouch(GameTime gameTime)
        {

            if (FreeFallGame.Instance.CurrentPlatform == FreeFallGame.Platform.MAC
            || FreeFallGame.Instance.CurrentPlatform == FreeFallGame.Platform.WINDOWS) //If macOS or Windows, use the Keyboard
            {

                if (prevKeyState.IsKeyDown(Keys.Right) && Keyboard.GetState().IsKeyUp(Keys.Right))
                {
                    IncreaseLane();
                }
                if (prevKeyState.IsKeyDown(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Left))
                {
                    DecreaseLane();
                }

            }
            else if (alternateControlScheme) //Read Gestures if Gestures are available
            {
                 foreach(TouchLocation touch in TouchPanel.GetState())
                {
                    if (lastMoved + 200 < gameTime.TotalGameTime.Milliseconds + (gameTime.TotalGameTime.Seconds * 1000))
                    {
                        if (touch.State == TouchLocationState.Pressed && touch.Position.X > UtilityManager.SCREEN_WIDTH / 2)
                        {
                            IncreaseLane();
                            lastMoved = gameTime.TotalGameTime.Milliseconds + (gameTime.TotalGameTime.Seconds * 1000);
                        }
                        else if (touch.State == TouchLocationState.Pressed)
                        {
                            DecreaseLane();
                        lastMoved = gameTime.TotalGameTime.Milliseconds + (gameTime.TotalGameTime.Seconds * 1000);
                        }
                    }
                }
            }
            else if(false)//If gestures are unavailable for some reason, just use the normal control scheme
            {
                if (TouchPanel.GetState().Count > 0)
                {
                    if (movingLeft)
                        Player.Instance.VelocityX = -Player.VELOCITY;
                    else
                        Player.Instance.VelocityX = Player.VELOCITY;
                }
                else //If nothing is happening, set the player velocity to 0
                {
                    Player.Instance.VelocityX = 0;
                }
            }
            else
            {
                foreach (TouchLocation touch in TouchPanel.GetState()) {
                    if (touch.State == TouchLocationState.Pressed)
                        originalTouchX = (int)TouchPanel.GetState()[0].Position.X;
                    if (!playerMoved && touch.State == TouchLocationState.Moved && originalTouchX != -1)
                    {
                        if (originalTouchX + 5 < touch.Position.X)
                        {
                            IncreaseLane();
                            playerMoved = true;
                        }
                        else if (originalTouchX - 5 > touch.Position.X)
                        {
                            DecreaseLane();
                            playerMoved = true;
                        }
                        //Console.WriteLine("Original Location: {0} Position: {1}", originalTouchX, touch.Position.X);
                    }
                    if (touch.State == TouchLocationState.Released)
                        playerMoved = false;
                }
            }

            prevKeyState = Keyboard.GetState();

        }


        private void IncreaseLane()
        {
            switch (Player.Instance.Lane)
            {
                case Player.PlayerPosition.LEFT:
                    Player.Instance.Lane = Player.PlayerPosition.CENTER;
                    break;
                case Player.PlayerPosition.CENTER:
                    Player.Instance.Lane = Player.PlayerPosition.RIGHT;
                    break;
            }
        }

        private void DecreaseLane()
        {
            switch (Player.Instance.Lane)
            {
                case Player.PlayerPosition.RIGHT:
                    Player.Instance.Lane = Player.PlayerPosition.CENTER;
                    break;
                case Player.PlayerPosition.CENTER:
                    Player.Instance.Lane = Player.PlayerPosition.LEFT;
                    break;
            }
        }


    }
}
