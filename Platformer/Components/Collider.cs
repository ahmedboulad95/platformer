using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Microsoft.Xna.Framework;

namespace Platformer.Components
{
    class Collider : Component
    {
        public Rectangle Rect { get; set; }
        private Transform _entityTransform;

        public Collider(Transform entityTransform)
        {
            _entityTransform = entityTransform;
            _entityTransform.PropertyChanged += OnTransformMove;
            ComponentRegistry.Register<Collider>(this);
        }

        private void OnTransformMove(object sender, PropertyChangedEventArgs evtArgs)
        {
            if (evtArgs.PropertyName != nameof(_entityTransform.Position))
                return;

            Rect = new Rectangle((int)_entityTransform.Position.X, (int)_entityTransform.Position.Y, Rect.Width, Rect.Height);
        }
    }
}
