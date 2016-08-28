using AncientTechnology.Core.Control.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace AncientTechnology.Core.Entities.Material
{
    public abstract class MovableObject : MaterialObject, IMovableObject
    {
        protected MainManager _manager;
        protected Vector2 _positionToSet = new Vector2();
        protected Vector2 _previousPosition = new Vector2();
        protected float _fallSpeed = 0.1f;
        protected float _jumpAcceleration = -7f;
        protected float _verticalSpeed = 0f;

        protected bool _isStanding = false;

        public MovableObject(MainManager manager)
        {
            _manager = manager;
        }

        public float Speed { get; set; }

        public override void Initialize()
        {
            _positionToSet = _position;
            _previousPosition = _position;

            base.Initialize();
        }

        public void Move(Orientation direction)
        {
            Orientation = direction;

            _positionToSet.X = _position.X + (int)Orientation * Speed;
        }
        public void Jump()
        {
            if (_isStanding)
            {
                _verticalSpeed += _jumpAcceleration;
            }
        }
        protected void Fall()
        {
            if (_isStanding == false)
            {
                _states.Add(State.Falling);
                _verticalSpeed += _fallSpeed;
            }
            else
            {
                _states.Remove(State.Falling);
            }
        }
        protected void FinalizeVerticalMoving()
        {
            _positionToSet.Y = _position.Y + _verticalSpeed;
        }

        public override void Update(GameTime gameTime)
        {
            Fall();
            FinalizeVerticalMoving();
            CheckCollisions();

            base.Update(gameTime);
        }

        #region Collisions

        protected void CheckCollisions()
        {
            _previousPosition = new Vector2(_position.X, _position.Y);

            var closeMaterialObjects = _manager.GetObjectsInSquare(Position, 1000)
                .Where(x => x is MaterialObject)
                .Where(x => x != this);

            _position.X = _positionToSet.X;
            foreach (var obj in closeMaterialObjects)
            {
                if (CheckXAxisCollisions(obj))
                {
                    break;
                }
            }

            _position.Y = _positionToSet.Y;
            foreach (var obj in closeMaterialObjects)
            {
                if (CheckYAxisCollisions(obj))
                {
                    break;
                }
            }
        }
        protected bool CheckXAxisCollisions(IVisualObject obj)
        {
            if (Bounds.Intersects(obj.Bounds))
            {
                _position.X = _previousPosition.X;
                return true;
            }
            return false;
        }
        protected bool CheckYAxisCollisions(IVisualObject obj)
        {
            _isStanding = false;
            if (Bounds.Intersects(obj.Bounds))
            {
                _position.Y = _previousPosition.Y;

                if (Math.Abs(obj.Bounds.Top - Bounds.Bottom) < 10)
                {
                    _position.Y = obj.Bounds.Top - Bounds.Height / 2;

                    _verticalSpeed = 0;
                    _isStanding = true;
                }
                if (Math.Abs(Bounds.Top - obj.Bounds.Bottom) < 10)
                {
                    _position.Y = obj.Bounds.Bottom + Bounds.Height / 2;

                    _verticalSpeed = 0;
                }

                return true;
            }
            return false;
        }

        #endregion
    }
}
