using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AncientTechnology.Core.Entities {
    public interface IVisualObject : IUpdateable {
        /// <summary>
        /// Position of the center of the object
        /// </summary>
        Vector2 Position { get; set; }
        /// <summary>
        /// Center of the object (calulated)
        /// </summary>
        Vector2 Origin { get; }
        /// <summary>
        /// Bounds of current object (calculated)
        /// </summary>
        Rectangle Bounds { get; }
        /// <summary>
        /// A current spirte of the object
        /// </summary>
        Texture2D Sprite { get; }
        /// <summary>
        /// Object rotation in radians
        /// </summary>
        float Rotation { get; set; }
    }
}
