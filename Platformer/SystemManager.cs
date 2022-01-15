using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    class SystemManager
    {
        private static SystemManager _instance;

        public Systems.AnimationSystem _AnimationSystem { get; set; }
        public Systems.ScriptSystem _ScriptSystem { get; set; }
        public Systems.StaticSpriteSystem _StaticSpriteSystem { get; set; }
        public Systems.CollisionSystem _CollisionSystem { get; set; }
        public Systems.ColliderSystem _ColliderSystem { get; set; }
        public Systems.MovementSystem _MovementSystem { get; set; }
        public Systems.ComponentFollowSystem _ComponentFollowSystem { get; set; }
        public Systems.DrawGizmosSystem _DrawGizmosSystem { get; set; }
        public Systems.GravitySystem _GravitySystem { get; set; }

        private GraphicsDevice _graphicsDevice;

        private SystemManager() { }

        public static SystemManager GetInstance()
        {
            if(_instance == null)
            {
                _instance = new SystemManager();
            }

            return _instance;
        }

        public void SetGraphicsDevice(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }

        public void InitializeCoreSystems()
        {
            _AnimationSystem = new Systems.AnimationSystem();
            _AnimationSystem.Start();

            _ScriptSystem = new Systems.ScriptSystem();
            _ScriptSystem.Start();

            _StaticSpriteSystem = new Systems.StaticSpriteSystem();
            _StaticSpriteSystem.Start();

            _CollisionSystem = new Systems.CollisionSystem();
            _CollisionSystem.Start();

            _ColliderSystem = new Systems.ColliderSystem();
            _ColliderSystem.Start();

            _MovementSystem = new Systems.MovementSystem();
            _MovementSystem.Start();

            _ComponentFollowSystem = new Systems.ComponentFollowSystem();
            _ComponentFollowSystem.Start();

            _GravitySystem = new Systems.GravitySystem();
            _GravitySystem.Start();

            _DrawGizmosSystem = new Systems.DrawGizmosSystem(_graphicsDevice);
            _DrawGizmosSystem.Start();
        }

        public void UpdateSystems(GameTime gameTime)
        {
            _AnimationSystem.Update(gameTime);
            _StaticSpriteSystem.Update(gameTime);
            _GravitySystem.Update(gameTime);
            _ScriptSystem.Update(gameTime);
            _ComponentFollowSystem.Update(gameTime);
            _MovementSystem.Update(gameTime);
            _CollisionSystem.Update(gameTime);
            _ColliderSystem.Update(gameTime);
            _DrawGizmosSystem.Update(gameTime);
        }

        public void Render(SpriteBatch spriteBatch, GameTime gameTime)
        {
            _DrawGizmosSystem.Draw(spriteBatch, gameTime);
            _AnimationSystem.Draw(spriteBatch, gameTime);
            _StaticSpriteSystem.Draw(spriteBatch, gameTime);
            
        }
    }
}
