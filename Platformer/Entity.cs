using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Platformer
{
    class Entity
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Layer { get; set; }
        private List<Components.Component> _components;

        public Entity()
        {
            _components = new List<Components.Component>();
        }

        public virtual void LoadContent(ContentManager contentManager)
        {
        }

        public void AddComponent(Components.Component component)
        {
            _components.Add(component);
            component.entity = this;
        }

        public T GetComponent<T>() where T : Components.Component
        {
            foreach(Components.Component component in _components)
            {
                if (component.GetType().Equals(typeof(T)))
                {
                    return (T)component;
                }
            }

            return default;
        }
    }
}
