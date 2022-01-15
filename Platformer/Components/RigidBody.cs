using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Microsoft.Xna.Framework;

namespace Platformer.Components
{
    class RigidBody : Component
    {
        public bool IsColliding { get; set; }
        public bool IsGrounded { get; set; }
        private Transform _entityTransform;
        public Rectangle Rect { get; set; }

        public RigidBody(Transform entityTransform)
        {
            _entityTransform = entityTransform;
            _entityTransform.PropertyChanged += OnTransformMove;
            ComponentRegistry.Register<RigidBody>(this);
            IsColliding = false;
        }

        private void OnTransformMove(object sender, PropertyChangedEventArgs evtArgs)
        {
            if (evtArgs.PropertyName != nameof(_entityTransform.Position))
                return;

            Rect = new Rectangle((int)_entityTransform.Position.X, (int)_entityTransform.Position.Y, Rect.Width, Rect.Height);
        }
    }
}
