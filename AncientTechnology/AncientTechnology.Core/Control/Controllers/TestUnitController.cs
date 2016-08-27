using AncientTechnology.Core.Entities;
using AncientTechnology.Core.Entities.Material;
using Microsoft.Xna.Framework.Input;

namespace AncientTechnology.Core.Control.Controllers
{
    public class TestUnitController : AbstractController<Unit>
    {
        protected override void Start(Unit obj)
        {
            var state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Left))
            {
                obj.Move(Orientation.Left);
            }

            if (state.IsKeyDown(Keys.Right))
            {
                obj.Move(Orientation.Right);
            }

            if (state.IsKeyDown(Keys.Space))
            {
                obj.Jump();
            }

            if (state.IsKeyDown(Keys.Down))
            {
                obj.FastFall();
            }
        }
    }
}
