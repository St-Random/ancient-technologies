using AncientTechnology.Core.Camera;
using AncientTechnology.Core.Control.Managers;
using AncientTechnology.Core.Entities.Material;
using Autofac;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        Camera _camera;

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
            _camera = new Camera(viewportWidth, viewportHeight);

            var unit = _scope.Resolve<Unit>();
            var texture = new Texture2D(GraphicsDevice, 100, 100);
            var colorData = Enumerable.Repeat(Color.Red, 100 * 100).ToArray();
            texture.SetData(colorData);
            unit.Sprite = texture;
            unit.Position = new Vector2(100, 200);
            _camera.Focus = unit;
            _manager.Add(unit);

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
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //_spriteBatch.Begin(
            //    SpriteSortMode.FrontToBack,
            //    BlendState.AlphaBlend,
            //    transformMatrix: _camera.Transform);

            _spriteBatch.Begin();

            foreach (var visualObject in _manager.ObjectsToDraw)
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
