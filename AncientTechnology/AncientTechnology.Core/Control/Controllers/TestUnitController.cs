using AncientTechnology.Core.Entities;
using AncientTechnology.Core.Entities.Material;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace AncientTechnology.Core.Control.Controllers
{
    public class TestUnitController : AbstractController<Unit>
    {
        protected override void Start(Unit obj)
        {
            var state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Left))
            {
                obj.States.Add(State.Moving);
                obj.Move(Orientation.Left);
            }

            if (state.IsKeyDown(Keys.Right))
            {
                obj.States.Add(State.Moving);
                obj.Move(Orientation.Right);
            }

            if (state.IsKeyDown(Keys.Space))
            {
                obj.Jump();
            }

            if (state.IsKeyUp(Keys.Left))
            {
                obj.States.Remove(State.Moving);
            }

            if (state.IsKeyUp(Keys.Right))
            {
                obj.States.Remove(State.Moving);
            }
        }
    }
}
