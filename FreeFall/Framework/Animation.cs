using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeFall.Framework
{
    public class Animation
    {

        private Texture2D[] frames;
        private float frameDuration;

        public enum AnimationPlayMode {
            NORMAL,
            REVERSED,
            LOOP,
            LOOP_REVERSED,
            LOOP_PING_PONG
        }

        private AnimationPlayMode PlayMode { get; set; }

        public Animation(float frameDuration, Texture2D[] frames) : this(frameDuration, frames, AnimationPlayMode.LOOP) { }

        public Animation(float frameDuration, Texture2D[] frames, AnimationPlayMode playMode) {
            this.frames = frames;
            this.frameDuration = frameDuration;
            PlayMode = playMode;
        }

        public Texture2D GetCurrentFrame(GameTime gameTime) {
            return GetCurrentFrame(gameTime.ElapsedGameTime.Seconds);
        }

        public Texture2D GetCurrentFrame(float elapsedTime) {
            switch(PlayMode) {
                case AnimationPlayMode.LOOP:
                default: return frames[((int)(elapsedTime/frameDuration))%frames.Length];
            }

        }

    }
    
}