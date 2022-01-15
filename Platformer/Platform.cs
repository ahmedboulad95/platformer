using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Platformer
{
    class Platform : Entity
    {
        public Platform() : base()
        {
            Name = "Platform";
            Layer = "Ground";

            Components.Transform transform = new Components.Transform();
            transform.Position = new Vector2(200, 400);
            transform.Scale = new Vector2(1, 2);
            transform.Rotation = 0f;
            AddComponent(transform);

            Components.StaticSprite sprite = new Components.StaticSprite("regular_platform");
            AddComponent(sprite);

            Components.Collider collider = new Components.Collider(transform);
            collider.Rect = new Rectangle((int)transform.Position.X, (int)transform.Position.Y, 64, 64);
            AddComponent(collider);
        }
    }
}
