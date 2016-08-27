using AncientTechnology.Core.Animations;
using AncientTechnology.Core.Camera;
using AncientTechnology.Core.Control.Managers;
using AncientTechnology.Core.Entities;
using AncientTechnology.Core.Entities.Material;
using Autofac;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AncientTechnology.UI
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        public static IContainer Container { get; private set; }
        private ILifetimeScope _scope;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private MainManager _manager;

        public Game()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<Configuration.IoCConfig>();
            builder.RegisterInstance(GraphicsDevice)
                   .AsSelf()
                   .ExternallyOwned();
            Container = builder.Build();
            _scope = Container.BeginLifetimeScope();

            _manager = _scope.Resolve<MainManager>();
            _manager.LoadLevel(1);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
            _scope.Dispose();
            Container.Dispose();
        }

        protected override void Update(GameTime gameTime)
        {
            _manager.Update(gameTime);
            _manager.CurrentLevel.Camera.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(
                SpriteSortMode.FrontToBack,
                BlendState.AlphaBlend,
                transformMatrix: _manager.CurrentLevel.Camera.Transform);

            foreach (var visualObject in _manager.VisualObjects)
            {
                _spriteBatch.Draw(
                    visualObject.Sprite,
                    visualObject.Position,
                    origin: visualObject.Origin);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
