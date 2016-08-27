using AncientTechnology.Core.Camera;
using AncientTechnology.Core.Entities;
using Microsoft.Xna.Framework.Input;

namespace AncientTechnology.Core.Control.Controllers
{
    public class CameraController : AbstractController<Camera2D>
    {
        protected int previousScrollState = 0;

        protected override void Start(Camera2D obj)
        {
            return;

            var keyboardState = Keyboard.GetState();
            var mouseState = Mouse.GetState();

            if (mouseState.ScrollWheelValue > previousScrollState)
            {
                obj.Scale += 0.5f;
            }
            if (mouseState.ScrollWheelValue < previousScrollState)
            {
                obj.Scale -= 0.5f;
            }

            previousScrollState = mouseState.ScrollWheelValue;
        }
    }
}
