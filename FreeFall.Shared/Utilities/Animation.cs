using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeFall.Shared.Utilities
{
    public class Animation
    {

        private Texture2D sourceImage;
        private int frameCount, frameWidth, frameHeight;
        private Rectangle sourceRectangle;

        private int framesPerSecond;
        private float millisecondsPerFrame;

        public Animation(Texture2D sourceImage, int frameCount) : this(sourceImage, frameCount, 60) { }

        public Animation(Texture2D sourceImage, int frameCount, int framesPerSecond)
        {
            this.sourceImage = sourceImage;
            this.frameCount = frameCount;
            Console.WriteLine("Source Image Width: " + sourceImage.Width);
            frameWidth = sourceImage.Width / frameCount;
            frameHeight = sourceImage.Height;
            this.framesPerSecond = framesPerSecond;
            millisecondsPerFrame = 1000 / (float) framesPerSecond;

            sourceRectangle = new Rectangle(0, 0, frameWidth, frameHeight);
        }

        public Animation(Texture2D sourceImage, int frameCount, int frameWidth, int frameHeight)
            : this(sourceImage, frameCount, frameWidth, frameHeight, 60) { }

        public Animation(Texture2D sourceImage, int frameCount, int frameWidth, int frameHeight, int framesPerSecond)
        {
            this.sourceImage = sourceImage;
            this.frameCount = frameCount;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.framesPerSecond = framesPerSecond;
            millisecondsPerFrame = 1000 / (float) framesPerSecond;

            sourceRectangle = new Rectangle(0, 0, frameWidth, frameHeight);
        }

        public Rectangle GetKeyFrame(GameTime gameTime)
        {
            sourceRectangle.X = (int)  (gameTime.TotalGameTime.Milliseconds / millisecondsPerFrame) * frameWidth;
            sourceRectangle.Y = 0;

            if(sourceRectangle.X >= sourceImage.Width)
            {
                sourceRectangle.X = sourceRectangle.X % sourceImage.Width;
                sourceRectangle.Y = sourceRectangle.X / sourceImage.Width;
            }

            Console.WriteLine("Frame Width: " + frameWidth);
            Console.WriteLine("\nMilliseconds Per Frame: {2} Game Time: {3}\nCalculated Value: {4}\nX: {0} Y: {1}", sourceRectangle.X, sourceRectangle.Y, millisecondsPerFrame, gameTime.TotalGameTime.Milliseconds, (int)(gameTime.TotalGameTime.Milliseconds / millisecondsPerFrame));
            return sourceRectangle;
        }
    }
}
