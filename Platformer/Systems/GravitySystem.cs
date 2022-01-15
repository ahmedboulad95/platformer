using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.Systems
{
    class GravitySystem : BaseSystem
    {
        private List<Components.RigidBody> _rigidbodies;
        private float _gravity = 18000.0f;
        private SystemManager _systemManager;

        public override void Start()
        {
            base.Start();

            _rigidbodies = ComponentRegistry.GetAll<Components.RigidBody>();
            _systemManager = SystemManager.GetInstance();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach(Components.RigidBody rigidbody in _rigidbodies)
            {
                Components.Transform transform = rigidbody.entity.GetComponent<Components.Transform>();
                //Components.Collider collider = rigidbody.entity.GetComponent<Components.Collider>();
                //Console.WriteLine($"Rigidbody position ({collider.Rect.X}, {collider.Rect.Y})");

                /*Vector2 rayStart = new Vector2(collider.Rect.X, collider.Rect.Y + collider.Rect.Height);
                Vector2 ray2Start = new Vector2(collider.Rect.X + collider.Rect.Width, collider.Rect.Y + collider.Rect.Height);
                Vector2 rayStartCenter = new Vector2(collider.Rect.X + (collider.Rect.Width / 2), collider.Rect.Y + collider.Rect.Height);*/

                /*Ray2D ray = new Ray2D(rayStart, Direction.Down);
                Ray2D ray2 = new Ray2D(ray2Start, Direction.Down);
                Ray2D rayCenter = new Ray2D(rayStartCenter, Direction.Down);

                List<Components.Collider> objectsUnderTransform = ray.Cast(5f);
                List<Components.Collider> objectsUnderTransform2 = ray2.Cast(5f);
                List<Components.Collider> objectsUnderTransform3 = rayCenter.Cast(5f);*/

                //_systemManager._DrawGizmosSystem.AddRay(ray);
                //_systemManager._DrawGizmosSystem.AddRay(ray2);
                //_systemManager._DrawGizmosSystem.AddRay(rayCenter);

                //Console.WriteLine($"Raycast 1 hit {objectsUnderTransform.Count} colliders");
                //Console.WriteLine($"Raycast 2 hit {objectsUnderTransform2.Count} colliders");

                //if (objectsUnderTransform.Count == 1 && objectsUnderTransform2.Count == 1 && objectsUnderTransform3.Count == 1)
                //{
                    //rigidbody.IsGrounded = false;
                    transform.OverrideVerticalMovement(transform.Position.Y + (_gravity * elapsed), gameTime);
                //}
                //else
                //{
                    //Console.WriteLine("Grounded");
                    //rigidbody.IsGrounded = true;
                //}
            }
        }
    }
}
