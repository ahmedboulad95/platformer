using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.Systems
{
    class ComponentFollowSystem : BaseSystem
    {
        private List<Components.RigidBody> _rigidbodies;
        private List<Components.Collider> _colliders;

        public override void Start()
        {
            base.Start();

            _rigidbodies = ComponentRegistry.GetAll<Components.RigidBody>();
            _colliders = ComponentRegistry.GetAll<Components.Collider>();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            foreach(Components.RigidBody rigidbody in _rigidbodies)
            {
                Components.Transform followTransform = rigidbody.entity.GetComponent<Components.Transform>();
                rigidbody.Rect = new Rectangle((int)followTransform.Position.X, (int)followTransform.Position.Y, rigidbody.Rect.Width, rigidbody.Rect.Height);
            }

            foreach(Components.Collider collider in _colliders)
            {
                Components.Transform followTransform = collider.entity.GetComponent<Components.Transform>();
                collider.Rect = new Rectangle((int)followTransform.Position.X, (int)followTransform.Position.Y, collider.Rect.Width, collider.Rect.Height);
            }
        }
    }
}
