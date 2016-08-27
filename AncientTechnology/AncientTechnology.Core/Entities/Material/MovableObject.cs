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
        protected float _fallSpeed = 2f;

        public MovableObject(MainManager manager)
        {
            _manager = manager;
        }

        public float Speed { get; set; }

        public override void Initialize()
        {
            _positionToSet = _position;
            _previousPosition = _position;
        }

        public void Move(Orientation direction)
        {
            Orientation = direction;

            _positionToSet.X = _position.X + (int)Orientation * Speed;
        }
        public void Jump()
        {
            _positionToSet.Y = _position.Y - 10;
        }
        public void FastFall()
        {
            _positionToSet.Y = _position.Y + 10;
        }
        protected void Fall()
        {
            _positionToSet.Y = _position.Y + _fallSpeed;
        }

        public override void Update(GameTime gameTime)
        {
            _previousPosition = new Vector2(_position.X, _position.Y);

            var closeMaterialObjects = _manager.GetObjectsInSquare(Position, 8000)
                .Where(x => x is MaterialObject)
                .Where(x => x != this);

            _position.X = _positionToSet.X;
            foreach (var obj in closeMaterialObjects)
            {
                if (CheckXAxisCollisions(obj))
                {
                    Debug.WriteLine("X");
                    break;
                }
            }

            _position.Y = _positionToSet.Y;
            foreach (var obj in closeMaterialObjects)
            {
                if (CheckYAxisCollisions(obj))
                {
                    Debug.WriteLine("Y");
                    break;
                }
            }
            
            Fall();

            base.Update(gameTime);
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
            if (Bounds.Intersects(obj.Bounds))
            {
                _position.Y = _previousPosition.Y;
                return true;
            }
            return false;
        }
    }
}
