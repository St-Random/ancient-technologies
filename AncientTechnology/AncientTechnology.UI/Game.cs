using AncientTechnology.Core.Camera;
using AncientTechnology.Core.Control.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AncientTechnology.UI
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        MainManager _manager;
        Camera _camera;

        public Game(MainManager manager)
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _manager = manager;
        }

        protected override void Initialize()
        {
            var viewportWidth = GraphicsDevice.Viewport.Width;
            var viewportHeight = GraphicsDevice.Viewport.Height;
            _camera = new Camera(viewportWidth, viewportHeight);

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
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(
                SpriteSortMode.FrontToBack,
                BlendState.AlphaBlend,
                transformMatrix: _camera.Transform);

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
