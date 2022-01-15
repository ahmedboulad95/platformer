using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Platformer
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SystemManager _systemManager;

        private Player _player;
        private List<Platform> _platforms;
        private Platform _wall;
        private TextureAtlas _textureAtlas;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _systemManager = SystemManager.GetInstance();
            _player = new Player();
            _platforms = new List<Platform>();

            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine($"I :: {i}");
                float previousPositionX = (i > 0) ? _platforms[i-1].GetComponent<Components.Transform>().Position.X : 0f;
                Platform platform = new Platform();
                platform.GetComponent<Components.Transform>().Position = new Vector2(previousPositionX + 64, 400);
                _platforms.Add(platform);
            }

            //_wall = new Platform();
            //_wall.GetComponent<Components.Transform>().Position = new Vector2(200, 330);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();

            _systemManager.SetGraphicsDevice(_graphics.GraphicsDevice);

            // TODO: Add your initialization logic here
            _systemManager.InitializeCoreSystems();
            _systemManager._StaticSpriteSystem.WorldAtlas = _textureAtlas;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _player.LoadContent(Content);

            Texture2D worldTextures = Content.Load<Texture2D>("platformPack_tilesheet");
            Dictionary<string, Vector2> tileCoordinates = new Dictionary<string, Vector2>();
            tileCoordinates.Add("regular_platform", new Vector2(0, 0));
            _textureAtlas = new TextureAtlas(worldTextures, tileCoordinates);

            //Systems.StaticSpriteSystem.WorldAtlas = _textureAtlas;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _systemManager.UpdateSystems(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _systemManager.Render(_spriteBatch, gameTime);

            base.Draw(gameTime);
        }
    }
}
