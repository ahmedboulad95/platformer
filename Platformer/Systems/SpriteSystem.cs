using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer.Systems
{
    class SpriteSystem : BaseSystem
    {
        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach(Components.Component component in _components)
            {
                if (component is IDrawable)
                {
                    ((IDrawable)component).Draw(spriteBatch);
                }
            }
        }
    }
}
