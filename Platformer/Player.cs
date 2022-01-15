using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Platformer
{
    class Player : Entity
    {
        public Player() : base()
        {
            Name = "Player";

            Components.Transform transform = new Components.Transform();
            transform.Position = new Vector2(200, 0);
            transform.Scale = new Vector2(1, 2);
            transform.Rotation = 0f;
            AddComponent(transform);

            Components.Collider collider = new Components.Collider(transform);
            collider.Rect = new Rectangle((int)transform.Position.X, (int)transform.Position.Y, 97, 97);
            AddComponent(collider);
            Console.WriteLine("Player collider dimensions :: " + collider.Rect.Width + ", " + collider.Rect.Height);

            Components.RigidBody rigidBody = new Components.RigidBody(transform);
            rigidBody.Rect = collider.Rect;
            AddComponent(rigidBody);

            Scripts.PlayerController playerController = new Scripts.PlayerController();
            AddComponent(playerController);
        }

        public override void LoadContent(ContentManager contentManager)
        {
            Console.WriteLine("Loading player content");
            base.LoadContent(contentManager);

            Texture2D playerTexture = contentManager.Load<Texture2D>("platformerPack_character");

            Dictionary<string, AnimationFrames> animationFrames = new Dictionary<string, AnimationFrames>();
            animationFrames.Add("run", new AnimationFrames(new List<int> { 2, 3 }));
            animationFrames.Add("jump", new AnimationFrames(new List<int> { 0, 1 }));
            animationFrames.Add("idle", new AnimationFrames(new List<int> { 3 }));

            Components.Animator2D animator = new Components.Animator2D(playerTexture, 2, 4, animationFrames);
            animator.PlayAnimation("run");
            AddComponent(animator);
        }
    }
}
