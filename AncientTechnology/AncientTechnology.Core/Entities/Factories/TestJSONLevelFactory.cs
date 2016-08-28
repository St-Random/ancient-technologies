using AncientTechnology.Core.Animations;
using AncientTechnology.Core.Camera;
using AncientTechnology.Core.Entities.Material;
using Autofac;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientTechnology.Core.Entities.Factories {
    class TestJSONLevelFactory : ILevelFactory {

        #region Helper Classes

        class Position {
            public int X { get; set; }
            public int Y { get; set; }
        }

        class ColorMetadata {
            public int Red { get; set; }
            public int Green { get; set; }
            public int Blue { get; set; }
        }

        class BlockMetadata {
            public int X { get; set; }
            public int Y { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public ColorMetadata Color { get; set; }
        }

        class LevelMetadata {
            public string Name { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public Position EntryPoint { get; set; }
            public IEnumerable<BlockMetadata> Blocks { get; set; }
        }

        #endregion

        ILifetimeScope _scope;
        GraphicsDevice _graphicsDevice;

        public TestJSONLevelFactory(ILifetimeScope scope) {
            _scope = scope;
            _graphicsDevice = _scope.Resolve<GraphicsDevice>();
        }

        public GameLevel LoadLevel(int levelId, GameLevel currentLevel = null) {
            return LoadLevelFromFile(levelId, currentLevel);
        }

        private IUnit CreatePlayer(ICamera2D camera) {
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

        private GameLevel LoadLevelFromFile(int levelId, GameLevel currentLevel = null) {
            // 4 test only
            var json = File.ReadAllText($"levels/level-{levelId}.json");
            var metadata = JsonConvert.DeserializeObject<LevelMetadata>(json);

            var camera = currentLevel?.Camera ?? CreateCamera();
            var player = currentLevel?.Player ?? CreatePlayer(camera);
            player.Position = new Vector2(metadata.EntryPoint.X, metadata.EntryPoint.Y);
            var objects = metadata.Blocks
                                  .Select(x => CreateBlockFromMetadata(x))
                                  .ToList();
            objects.Add(player);

            return new GameLevel {
                Id = levelId,
                Name = metadata.Name,
                EntryPoint = new Vector2(metadata.EntryPoint.X, metadata.EntryPoint.Y),
                Width = metadata.Width,
                Height = metadata.Height,
                Camera = camera,
                Player = player,
                GameObjects = objects
            };
        }

        private IUpdateable CreateBlockFromMetadata(BlockMetadata metadata) {
            var block = _scope.Resolve<Block>();
            var color = new Color(metadata.Color.Red, metadata.Color.Green, metadata.Color.Blue);
            var texture = new Texture2D(_graphicsDevice, metadata.Width, metadata.Height);
            var colorData = Enumerable.Repeat(color, metadata.Width * metadata.Height).ToArray();
            texture.SetData(colorData);
            block.SetBaseSprite(texture);
            block.Position = new Vector2(metadata.X, metadata.Y);

            return block;
        }
    }
}
