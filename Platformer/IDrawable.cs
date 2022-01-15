using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    interface IDrawable
    {
        public void Draw(SpriteBatch spriteBatch);
    }
}
