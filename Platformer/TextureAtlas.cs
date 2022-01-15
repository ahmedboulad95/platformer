using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    class TextureAtlas
    {
        public Texture2D WorldTilesheet { get; set; }
        private Dictionary<string, Vector2> _tileCoordinatesByName;

        public TextureAtlas(Texture2D tilesheet, Dictionary<string, Vector2> tileCoordinatesByName)
        {
            WorldTilesheet = tilesheet;
            _tileCoordinatesByName = tileCoordinatesByName;
        }

        public Vector2 GetTileCoordinates(string tilename)
        {
            return _tileCoordinatesByName[tilename];
        }
    }
}
