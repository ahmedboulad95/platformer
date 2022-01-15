using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Platformer.Systems
{
    class CollisionSystem : BaseSystem
    {
        public static event EventHandler<Collision> CollisionEnter;

        private List<Components.Collider> _colliders;
        private List<Components.RigidBody> _rigidbodies;

        private float previousBottom;

        public override void Start()
        {
            Console.WriteLine("Starting collision system");
            _colliders = ComponentRegistry.GetAll<Components.Collider>();
            _rigidbodies = ComponentRegistry.GetAll<Components.RigidBody>();
        }

        /*public override void Update(GameTime gameTime)
        {
            foreach(Components.RigidBody moveable in _rigidbodies)
            {
                moveable.IsColliding = false;
                Components.Collider moveableCollider = moveable.entity.GetComponent<Components.Collider>();
                Vector2 nextEntityPosition = moveable.entity.GetComponent<Components.Transform>().CalculateNextPosition(gameTime);
                Rectangle nextColliderRect = new Rectangle((int)nextEntityPosition.X, (int)nextEntityPosition.Y, moveableCollider.Rect.Width, moveableCollider.Rect.Height);
                foreach (Components.Collider collider in _colliders)
                {
                    if(collider.entity == moveable.entity)
                    {
                        continue;
                    }

                    if (nextColliderRect.Intersects(collider.Rect))
                    {
                        moveable.IsColliding = true;
                    }
                }
            }
        }*/

        public override void Update(GameTime gameTime)
        {
            foreach (Components.RigidBody moveable in _rigidbodies)
            {
                moveable.IsColliding = false;
                Components.Collider moveableCollider = moveable.entity.GetComponent<Components.Collider>();
                Components.Transform moveableTransform = moveable.entity.GetComponent<Components.Transform>();

                foreach (Components.Collider collider in _colliders)
                {
                    if (collider.entity == moveable.entity)
                        continue;

                    Vector2 collisionDepth = GetCollisionDepth(moveableCollider.Rect, collider.Rect);
                    if (collisionDepth != Vector2.Zero)
                    {
                        float absDepthX = Math.Abs(collisionDepth.X);
                        float absDepthY = Math.Abs(collisionDepth.Y);

                        // Resolve the collision along the shallow axis.
                        if (absDepthY < absDepthX)// || collision == TileCollision.Platform)
                        {
                            // If we crossed the top of a tile, we are on the ground.
                            if (previousBottom <= collider.Rect.Top)
                                moveable.IsGrounded = true;

                            // Ignore platforms, unless we are on the ground.
                            if (moveable.IsGrounded)
                            {
                                // Resolve the collision along the Y axis.
                                moveableTransform.Position = new Vector2(moveableTransform.Position.X, moveableTransform.Position.Y + collisionDepth.Y);

                                // Perform further collisions with the new bounds.
                                //bounds = BoundingRectangle;
                            }
                        }
                        else //if (collision == TileCollision.Impassable) // Ignore platforms.
                        {
                            // Resolve the collision along the X axis.
                            moveableTransform.Position = new Vector2(moveableTransform.Position.X + collisionDepth.X, moveableTransform.Position.Y);

                            // Perform further collisions with the new bounds.
                            //bounds = BoundingRectangle;
                        }
                    }
                }
            }
        }

        private Vector2 GetCollisionDepth(Rectangle rectA, Rectangle rectB)
        {
            float halfWidthA = rectA.Width / 2.0f;
            float halfHeightA = rectA.Height / 2.0f;
            float halfWidthB = rectB.Width / 2.0f;
            float halfHeightB = rectB.Height / 2.0f;

            // Calculate centers.
            Vector2 centerA = new Vector2(rectA.Left + halfWidthA, rectA.Top + halfHeightA);
            Vector2 centerB = new Vector2(rectB.Left + halfWidthB, rectB.Top + halfHeightB);

            // Calculate current and minimum-non-intersecting distances between centers.
            float distanceX = centerA.X - centerB.X;
            float distanceY = centerA.Y - centerB.Y;
            float minDistanceX = halfWidthA + halfWidthB;
            float minDistanceY = halfHeightA + halfHeightB;

            // If we are not intersecting at all, return (0, 0).
            if (Math.Abs(distanceX) >= minDistanceX || Math.Abs(distanceY) >= minDistanceY)
                return Vector2.Zero;

            // Calculate and return intersection depths.
            float depthX = distanceX > 0 ? minDistanceX - distanceX : -minDistanceX - distanceX;
            float depthY = distanceY > 0 ? minDistanceY - distanceY : -minDistanceY - distanceY;
            return new Vector2(depthX, depthY);
        }
    }
}
