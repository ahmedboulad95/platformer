using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Platformer.Scripts
{
    class PlayerController : Components.Script
    {
        private Components.Transform playerTransform;
        private Components.RigidBody playerRigidBody;
        private Components.Animator2D playerAnimator;

        private float moveSpeed = 5000.0f;
        private float MaxJumpTime = 0.35f;
        private float JumpControlPower = 0.14f;
        private float jumpForce = -8000f;
        private float jumpTime = 0.0f;

        public PlayerController() : base() { }

        public override void Start()
        {
            base.Start();

            playerTransform = entity.GetComponent<Components.Transform>();
            playerRigidBody = entity.GetComponent<Components.RigidBody>();
            playerAnimator = entity.GetComponent<Components.Animator2D>();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            KeyboardState kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
            {
                Console.WriteLine($"Jump time :: {jumpTime}");

                float velocityY = playerTransform.Position.Y;
                if(playerRigidBody.IsGrounded || jumpTime > 0.0f)
                {
                    jumpTime += elapsed;
                    playerAnimator.PlayAnimation("jump");
                }

                if (0.0f < jumpTime && jumpTime <= MaxJumpTime)
                {
                    // Fully override the vertical velocity with a power curve that gives players more control over the top of the jump
                    velocityY = jumpForce * (1.0f - (float)Math.Pow(jumpTime / MaxJumpTime, JumpControlPower));
                }
                else
                {
                    // Reached the apex of the jump
                    jumpTime = 0.0f;
                }

                playerTransform.Move(new Vector2(0, velocityY), gameTime);
                //playerTransform.Move(new Vector2(0, -1 * jumpForce));
            }
            else
            {
                jumpTime = 0.0f;
            }

            if(playerRigidBody.IsGrounded)
            {
                playerAnimator.PlayAnimation("idle");
            }

            if (kstate.IsKeyDown(Keys.Left))
                playerTransform.Move(new Vector2(-1 * moveSpeed * elapsed, 0), gameTime);
                //playerTransform.Position -= new Vector2(moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);

            if (kstate.IsKeyDown(Keys.Right))
                playerTransform.Move(new Vector2(moveSpeed * elapsed, 0), gameTime);
                //playerTransform.Position += new Vector2(moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);

            if(playerTransform.MoveBy.X != 0.0f)
            {
                playerAnimator.PlayAnimation("run");
            }

            Components.Collider collider = entity.GetComponent<Components.Collider>();
            //Console.WriteLine("Player collider dimensions :: " + collider.Rect.Width + ", " + collider.Rect.Height);
        }

    }
}
