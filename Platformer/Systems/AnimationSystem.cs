using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer.Systems
{
    class AnimationSystem : BaseSystem
    {
        private List<Components.Animator2D> _animators;

        public override void Start()
        {
            base.Start();

            _animators = ComponentRegistry.GetAll<Components.Animator2D>();
            Console.WriteLine("Number animators :: " + _animators.Count);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            foreach(Components.Animator2D animator in _animators)
            {
                animator.TickAnimation(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            base.Draw(spriteBatch, gameTime);

            spriteBatch.Begin();
            foreach (Components.Animator2D animator in _animators)
            {
                int row = animator.GetCurrentFrame() / animator.Columns;
                int column = animator.GetCurrentFrame() % animator.Columns;

                Components.Transform entityTransform = animator.entity.GetComponent<Components.Transform>();

                if (entityTransform == null)
                {
                    return;
                }

                Rectangle sourceRectangle = new Rectangle(animator.FrameWidth * column, animator.FrameHeight * row, animator.FrameWidth, animator.FrameHeight);
                Rectangle destinationRectangle = new Rectangle((int)entityTransform.Position.X, (int)entityTransform.Position.Y, animator.FrameWidth, animator.FrameHeight);

                
                spriteBatch.Draw(animator.Texture, destinationRectangle, sourceRectangle, Color.White);
            }
            spriteBatch.End();
        }
    }
}
