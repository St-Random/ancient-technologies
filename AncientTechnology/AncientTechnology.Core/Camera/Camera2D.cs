using AncientTechnology.Core.Control.Controllers;
using AncientTechnology.Core.Entities;
using Microsoft.Xna.Framework;

namespace AncientTechnology.Core.Camera
{
    public class Camera2D : BaseUpdateableObject, ICamera2D
    {
        private Vector2 _position;
        private float _viewportWidth;
        private float _viewportHeight;

        public Camera2D(int viewportWidth, int viewportHeight)
        {
            _viewportWidth = viewportWidth;
            _viewportHeight = viewportHeight;

            ScreenCenter = new Vector2(_viewportWidth / 2, _viewportHeight / 2);
            Scale = 1;
            MoveSpeed = 2.25f;

            _controller = new CameraController();
        }

        #region Properties

        public Vector2 Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }
        public float Rotation { get; set; }
        public Vector2 Origin { get; set; }
        public float Scale { get; set; }
        public Vector2 ScreenCenter { get; protected set; }
        public Matrix Transform { get; set; }
        public IVisualObject Focus { get; set; }
        public float MoveSpeed { get; set; }

        #endregion

        public override void Update(GameTime gameTime)
        {
            // Create the Transform used by any
            // spritebatch process
            Transform = Matrix.Identity *
                        Matrix.CreateTranslation(-Position.X, -Position.Y, 0) *
                        Matrix.CreateRotationZ(Rotation) *
                        Matrix.CreateTranslation(Origin.X, Origin.Y, 0) *
                        Matrix.CreateScale(new Vector3(Scale, Scale, Scale));

            Origin = ScreenCenter / Scale;

            // Move the Camera to the position that it needs to go
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            _position.X += (Focus.Position.X - Position.X) * MoveSpeed * delta;
            _position.Y += (Focus.Position.Y - Position.Y) * MoveSpeed * delta;

            base.Update(gameTime);
        }
    }
}
