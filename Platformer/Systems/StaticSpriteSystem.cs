using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer.Systems
{
    class StaticSpriteSystem : BaseSystem
    {
        private List<Components.StaticSprite> _sprites;

        public TextureAtlas WorldAtlas { get; set; }

        public override void Start()
        {
            base.Start();

            _sprites = ComponentRegistry.GetAll<Components.StaticSprite>();
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin();
            foreach (Components.StaticSprite component in _sprites)
            {
                Components.Transform entityTransform = component.entity.GetComponent<Components.Transform>();
                Vector2 tileCoordinates = WorldAtlas.GetTileCoordinates(component.GetTileName());

                Rectangle sourceRectangle = new Rectangle(64 * (int)tileCoordinates.Y, 64 * (int)tileCoordinates.X, 64, 64);
                Rectangle destinationRectangle = new Rectangle((int)entityTransform.Position.X, (int)entityTransform.Position.Y, 64, 64);

                
                spriteBatch.Draw(WorldAtlas.WorldTilesheet, destinationRectangle, sourceRectangle, Color.White);
            }
            spriteBatch.End();
        }
    }
}
