using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Platformer.Components
{
    class Animator2D : Component
    {
        public Texture2D Texture { get; set; }
        public Dictionary<string, AnimationFrames> Animations;
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int FrameWidth { get; }
        public int FrameHeight { get; }

        private string _currentAnimation;
        private float _timer;
        private int _threshold;

        public Animator2D(Texture2D texture, int rows, int columns, Dictionary<string, AnimationFrames> animations) : base()
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            Animations = animations;

            FrameWidth = Texture.Width / Columns;
            FrameHeight = Texture.Height / Rows;

            _timer = 0;
            _threshold = 250;

            ComponentRegistry.Register<Animator2D>(this);
            //Systems.AnimationSystem.Register(this);
        }

        public void PlayAnimation(string animationName)
        {
            _currentAnimation = animationName;
        }

        public int GetCurrentFrame()
        {
            return Animations[_currentAnimation].GetCurrentFrame();
        }

        public void TickAnimation(GameTime gameTime)
        {
            if (_timer > _threshold)
            {
                Animations[_currentAnimation].Update();
                _timer = 0;
            }
            else
            {
                _timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }
    }
}
