using AncientTechnology.Core.Camera;
using Microsoft.Xna.Framework.Input;

namespace AncientTechnology.Core.Control.Controllers
{
    public class CameraController : AbstractController<Camera2D>
    {
        protected int previousScrollState = 0;

        protected override void Start(Camera2D obj)
        {
            var keyboardState = Keyboard.GetState();
            var mouseState = Mouse.GetState();

            if (mouseState.ScrollWheelValue > previousScrollState)
            {
                obj.Scale += 0.1f;
            }
            if (mouseState.ScrollWheelValue < previousScrollState)
            {
                obj.Scale -= 0.1f;
            }

            previousScrollState = mouseState.ScrollWheelValue;
        }
    }
}
