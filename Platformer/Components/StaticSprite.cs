using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.Components
{
    class StaticSprite : Components.Component
    {
        private string _tileName;

        public StaticSprite(string tilename) : base()
        {
            _tileName = tilename;
            ComponentRegistry.Register<StaticSprite>(this);
            //Systems.StaticSpriteSystem.Register(this);
        }

        public string GetTileName()
        {
            return _tileName;
        }
    }
}
