using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.Systems
{
    class MovementSystem : BaseSystem
    {
        private List<Components.RigidBody> _rigidbodies;

        public override void Start()
        {
            base.Start();

            _rigidbodies = ComponentRegistry.GetAll<Components.RigidBody>();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            foreach(Components.RigidBody rigidbody in _rigidbodies)
            {
                Components.Transform transform = rigidbody.entity.GetComponent<Components.Transform>();
                transform.CommitMovement(gameTime);
                /*if (!rigidbody.IsColliding)
                {
                    Console.WriteLine("Moving player");
                    //transform.CommitMovement(gameTime);
                    /*transform.Position = transform.LastValidPosition;

                    Components.Collider collider = rigidbody.entity.GetComponent<Components.Collider>();
                    collider.Rect = new Rectangle((int)transform.Position.X, (int)transform.Position.Y, collider.Rect.Width, collider.Rect.Height);*/
                //}
                /*else
                {
                    Console.WriteLine("Invalid movement");
                    transform.ClearMovement();
                }*/
            }
        }
    }
}
