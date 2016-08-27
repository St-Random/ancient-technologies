using AncientTechnology.Core.Animations;
using AncientTechnology.Core.Camera;
using AncientTechnology.Core.Entities.Material;
using Autofac;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientTechnology.Core.Entities.Factories {
    class TestLevelFactory : ILevelFactory {
        ILifetimeScope _scope;
        GraphicsDevice _graphicsDevice;

        public TestLevelFactory(ILifetimeScope scope) {
            _scope = scope;
            _graphicsDevice = _scope.Resolve<GraphicsDevice>();
        }

        public GameLevel LoadLevel(int levelId, GameLevel level = null) {
            var gameLevel = new GameLevel {
                Id = -1,
                Name = "Test level",
                EntryPoint = new Vector2(100, 200),
            };
            var camera = level?.Camera ?? CreateCamera();
            var player = level?.Player ?? CreatePlayer(camera);
            player.Position = gameLevel.EntryPoint;

            var objects = CreateGameObjects();
            objects.Add(player);

            gameLevel.Camera = camera;
            gameLevel.Player = player;
            gameLevel.GameObjects = objects;

            return gameLevel;
        }

        private IUnit CreatePlayer(ICamera2D camera)
        {
            #region 1

            var sprite1 = new Texture2D(_graphicsDevice, 100, 100);
            var colorData = Enumerable.Repeat(Color.Red, 100 * 100).ToArray();
            sprite1.SetData(colorData);

            var sprite2 = new Texture2D(_graphicsDevice, 100, 100);
            colorData = Enumerable.Repeat(Color.Green, 100 * 100).ToArray();
            sprite2.SetData(colorData);

            var sprite3 = new Texture2D(_graphicsDevice, 100, 100);
            colorData = Enumerable.Repeat(Color.Blue, 100 * 100).ToArray();
            sprite3.SetData(colorData);

            var animation1 = new Animation();
            animation1.SetFrames(new Texture2D[] { sprite1, sprite2, sprite3 });
            animation1.FrameRate = TimeSpan.FromSeconds(0.5);

            #endregion

            #region 2

            sprite1 = new Texture2D(_graphicsDevice, 100, 100);
            colorData = Enumerable.Repeat(Color.DarkOrange, 100 * 100).ToArray();
            sprite1.SetData(colorData);

            sprite2 = new Texture2D(_graphicsDevice, 100, 100);
            colorData = Enumerable.Repeat(Color.Black, 100 * 100).ToArray();
            sprite2.SetData(colorData);

            sprite3 = new Texture2D(_graphicsDevice, 100, 100);
            colorData = Enumerable.Repeat(Color.Gold, 100 * 100).ToArray();
            sprite3.SetData(colorData);

            var animation2 = new Animation();
            animation2.SetFrames(new Texture2D[] { sprite1, sprite2, sprite3 });
            animation2.FrameRate = TimeSpan.FromSeconds(0.5);

            #endregion

            var unit = _scope.Resolve<Unit>();
            var texture = new Texture2D(_graphicsDevice, 100, 100);
            colorData = Enumerable.Repeat(Color.Red, 100 * 100).ToArray();
            texture.SetData(colorData);
            unit.SetBaseSprite(texture);
            unit.Position = new Vector2(100, 100);
            unit.Speed = 5;
            camera.Focus = unit;
            unit.Animations.AddAnimation(State.Moving, animation1);
            unit.Animations.AddAnimation(State.Falling, animation2);
            unit.Initialize();

            return unit;
        }

        private ICamera2D CreateCamera() {
            var viewportWidth = _graphicsDevice.Viewport.Width;
            var viewportHeight = _graphicsDevice.Viewport.Height;
            return new Camera2D(viewportWidth, viewportHeight);
        }

        private IList<IUpdateable> CreateGameObjects() {
            var objects = new List<IUpdateable>();
            
            objects.Add(CreateBlock(Color.Yellow, 0, 500, 1000, 100));
            objects.Add(CreateBlock(Color.Yellow, 600, 270, 800, 100));

            return objects;
        }

        private IUpdateable CreateBlock(Color color, int x, int y, int width, int height) {
            var block = _scope.Resolve<Block>();
            var texture = new Texture2D(_graphicsDevice, width, height);
            var colorData = Enumerable.Repeat(color, width * height).ToArray();
            texture.SetData(colorData);
            block.SetBaseSprite(texture);
            block.Position = new Vector2(x, y);

            return block;
        }
    }
}
