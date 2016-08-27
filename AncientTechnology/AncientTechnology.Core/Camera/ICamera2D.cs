using AncientTechnology.Core.Entities;
using Microsoft.Xna.Framework;

namespace AncientTechnology.Core.Camera
{
    public interface ICamera2D : Entities.IUpdateable
    {
        Vector2 Position { get; set; }

        float MoveSpeed { get; set; }

        float Rotation { get; set; }

        Vector2 Origin { get; }

        float Scale { get; set; }

        Vector2 ScreenCenter { get; }

        Matrix Transform { get; }

        IVisualObject Focus { get; set; }
    }
}
