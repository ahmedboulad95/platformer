using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Platformer.Components
{
    class Component
    {
        public static readonly Guid TypeId = new Guid();

        public Entity entity;

        public virtual void Initialize() { }

        public virtual void Start() { }

        public virtual void Update(GameTime gameTime) { }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 location) { }
    }
}
