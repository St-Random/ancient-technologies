using AncientTechnology.Core.Control.Controllers;
using AncientTechnology.Core.Control.Managers;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace AncientTechnology.Core.Entities.Material
{
    public class Unit : MovableObject, IUnit
    {
        public Unit(MainManager manager, TestUnitController controller)
            : base(manager)
        {
            _controller = controller;
        }

        public override void Update(GameTime gameTime)
        {
            Debug.WriteLine(_position.X.ToString() + " " + _position.Y.ToString());

            base.Update(gameTime);
        }
    }
}
