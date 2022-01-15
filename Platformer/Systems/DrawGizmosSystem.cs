using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.Systems
{
    class DrawGizmosSystem : BaseSystem
    {
        private GraphicsDevice _graphicsDevice;
        private List<Components.Collider> _colliders;
        private List<Ray2D> _rays;

        public DrawGizmosSystem(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }

        public override void Start()
        {
            base.Start();

            _rays = new List<Ray2D>();
            _colliders = ComponentRegistry.GetAll<Components.Collider>();
            foreach(Components.Collider collider in _colliders)
            {
                Console.WriteLine($"Collider dimensions :: {collider.Rect.Width}, {collider.Rect.Height}");
            }
        }

        public void AddRay(Ray2D ray)
        {
            _rays.Add(ray);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            base.Draw(spriteBatch, gameTime);

            spriteBatch.Begin();
            foreach(Components.Collider collider in _colliders)
            {
                Texture2D rect = new Texture2D(_graphicsDevice, collider.Rect.Width, collider.Rect.Height);
                //Console.WriteLine($"{collider.entity.Name} Collider size :: {collider.Rect.Width}, {collider.Rect.Height}");
                Color[] data = new Color[collider.Rect.Width * collider.Rect.Height];
                for (int i = 0; i < data.Length; ++i) data[i] = Color.Green;
                rect.SetData(data);

                Vector2 coor = new Vector2(collider.Rect.X, collider.Rect.Y);
                spriteBatch.Draw(rect, coor, Color.White);
            }

            foreach(Ray2D ray in _rays)
            {
                DrawLine(spriteBatch, ray.position, ray.endpoint, Color.Red);
            }
            spriteBatch.End();
        }

        private Texture2D GetTexture(SpriteBatch spriteBatch)
        {
            Texture2D _texture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            _texture.SetData(new[] { Color.White });

            return _texture;
        }

        public void DrawLine(SpriteBatch spriteBatch, Vector2 point1, Vector2 point2, Color color, float thickness = 1f)
        {
            var distance = Vector2.Distance(point1, point2);
            var angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
            DrawLine(spriteBatch, point1, distance, angle, color, thickness);
        }

        public void DrawLine(SpriteBatch spriteBatch, Vector2 point, float length, float angle, Color color, float thickness = 1f)
        {
            var origin = new Vector2(0f, 0.5f);
            var scale = new Vector2(length, thickness);
            spriteBatch.Draw(GetTexture(spriteBatch), point, null, color, angle, origin, scale, SpriteEffects.None, 0);
        }
    }
}
