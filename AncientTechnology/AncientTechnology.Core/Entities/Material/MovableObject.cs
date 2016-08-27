using AncientTechnology.Core.Control.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace AncientTechnology.Core.Entities.Material
{
    public abstract class MovableObject : MaterialObject, IMovableObject
    {
        private MainManager _manager;

        public MovableObject(MainManager manager)
        {
            _manager = manager;
        }

        public float Speed { get; set; }

        public void Move(Orientation direction)
        {
            Orientation = direction;

            var finalX = Position.X + (int)Orientation * Speed;



            _position.X = finalX;
        }

        public override void Update(GameTime gameTime)
        {
            _position.Y += 1f;

            base.Update(gameTime);
        }
    }
}
