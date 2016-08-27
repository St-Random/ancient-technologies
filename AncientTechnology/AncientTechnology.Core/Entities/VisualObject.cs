using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AncientTechnology.Core.Entities {

    public abstract class VisualObject : BaseUpdateableObject, IVisualObject {
        protected Vector2 _position;

        public Vector2 Position {
            get {
                return _position;
            }
            set {
                _position = value;
            }
        }

        public Vector2 Origin {
            get {
                return new Vector2(Sprite.Width / 2, Sprite.Height / 2);
            }
        }

        public Rectangle Bounds {
            get {
                return new Rectangle((int)_position.X - Sprite.Width / 2,
                                     (int)_position.Y - Sprite.Height / 2,
                                     Sprite.Width, 
                                     Sprite.Height);
            }
        }

        public Texture2D Sprite { get; set; }
        public float Rotation { get; set; }

    }
}
