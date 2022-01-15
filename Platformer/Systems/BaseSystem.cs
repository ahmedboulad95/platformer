using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Platformer.Systems
{
    class BaseSystem
    {
        protected static List<Components.Component> _components = new List<Components.Component>();

        /*public static void Register(T component)
        {
            _components.Add(component);
        }*/

        /*public static void Initialize()
        {
            foreach(T component in _components)
            {
                component.Start();
            }
        }*/

        public virtual void Start() { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime) { }

        /*public static void Update(GameTime gameTime)
        {
            foreach(T component in _components)
            {
                component.Update(gameTime);
            }
        }*/

        public List<Components.Component> GetComponents()
        {
            return _components;
        }
    }
}
