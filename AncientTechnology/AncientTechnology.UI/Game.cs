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
        ILifetimeScope _scope;
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        MainManager _manager;
        Camera2D _camera;

        public Game(ILifetimeScope scope, MainManager manager)
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _scope = scope;
            _manager = manager;
        }

        protected override void Initialize()
        {
            var viewportWidth = GraphicsDevice.Viewport.Width;
            var viewportHeight = GraphicsDevice.Viewport.Height;
            _camera = new Camera2D(viewportWidth, viewportHeight);

            TestAnimation();    

            var block = _scope.Resolve<Block>();
            var texture = new Texture2D(GraphicsDevice, 200, 50);
            var colorData = Enumerable.Repeat(Color.Green, 100 * 100).ToArray();
            texture.SetData(colorData);
            block.SetBaseSprite(texture);
            block.Position = new Vector2(280, 400);
            _manager.Add(block);

            var block1 = _scope.Resolve<Block>();
            texture = new Texture2D(GraphicsDevice, 200, 50);
            colorData = Enumerable.Repeat(Color.Green, 100 * 100).ToArray();
            texture.SetData(colorData);
            block1.SetBaseSprite(texture);
            block1.Position = new Vector2(200, 600);
            _manager.Add(block1);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            _manager.Update(gameTime);
            _camera.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(
                SpriteSortMode.FrontToBack,
                BlendState.AlphaBlend,
                transformMatrix: _camera.Transform);

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

        protected void TestAnimation()
        {
            #region 1

            var sprite1 = new Texture2D(GraphicsDevice, 100, 100);
            var colorData = Enumerable.Repeat(Color.Red, 100 * 100).ToArray();
            sprite1.SetData(colorData);

            var sprite2 = new Texture2D(GraphicsDevice, 100, 100);
            colorData = Enumerable.Repeat(Color.Green, 100 * 100).ToArray();
            sprite2.SetData(colorData);

            var sprite3 = new Texture2D(GraphicsDevice, 100, 100);
            colorData = Enumerable.Repeat(Color.Blue, 100 * 100).ToArray();
            sprite3.SetData(colorData);

            var animation1 = new Animation();
            animation1.SetFrames(new Texture2D[] { sprite1, sprite2, sprite3 });
            animation1.FrameRate = TimeSpan.FromSeconds(0.5);

            #endregion

            #region 2

            sprite1 = new Texture2D(GraphicsDevice, 100, 100);
            colorData = Enumerable.Repeat(Color.DarkOrange, 100 * 100).ToArray();
            sprite1.SetData(colorData);

            sprite2 = new Texture2D(GraphicsDevice, 100, 100);
            colorData = Enumerable.Repeat(Color.Black, 100 * 100).ToArray();
            sprite2.SetData(colorData);

            sprite3 = new Texture2D(GraphicsDevice, 100, 100);
            colorData = Enumerable.Repeat(Color.Gold, 100 * 100).ToArray();
            sprite3.SetData(colorData);

            var animation2 = new Animation();
            animation2.SetFrames(new Texture2D[] { sprite1, sprite2, sprite3 });
            animation2.FrameRate = TimeSpan.FromSeconds(0.5);

            #endregion

            var unit = _scope.Resolve<Unit>();
            var texture = new Texture2D(GraphicsDevice, 100, 100);
            colorData = Enumerable.Repeat(Color.Red, 100 * 100).ToArray();
            texture.SetData(colorData);
            unit.SetBaseSprite(texture);
            unit.Position = new Vector2(100, 200);
            unit.Speed = 5;
            _camera.Focus = unit;
            unit.Animations.AddAnimation(State.Moving, animation1);
            unit.Animations.AddAnimation(State.Falling, animation2);
            unit.Initialize();
            _manager.Add(unit);
        }
    }
}
