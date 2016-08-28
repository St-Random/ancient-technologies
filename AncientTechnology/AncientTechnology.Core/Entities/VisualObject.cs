using System;
using AncientTechnology.Core.Control.Controllers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using AncientTechnology.Core.Animations;
using System.Diagnostics;
using AncientTechnology.Core.Control.Managers;

namespace AncientTechnology.Core.Entities {

    public abstract class VisualObject : BaseUpdateableObject, IVisualObject
    {
        protected Vector2 _position;
        protected Texture2D _baseSprite;
        protected StateManager _states = new StateManager();

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

        public Texture2D Sprite
        {
            get
            {
                return (Animations.CurrentSprite != null) ? Animations.CurrentSprite : _baseSprite;
            }
        }
        public AnimationDictionary Animations { get; set; } = new AnimationDictionary();
        public float Rotation { get; set; }
        public Orientation Orientation { get; set; } = Orientation.Right;

        public StateManager States
        {
            get
            {
                return _states;
            }
        }
        protected State CurrentState
        {
            get
            {
                return _states.CurrentState;
            }
        }

        public override void Initialize()
        {
            _states.Add(State.General);
            Animations.Initialize();

            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            Debug.WriteLine(CurrentState.ToString());
            Animations.SetState(CurrentState);
            Animations.Update(gameTime);

            base.Update(gameTime);
        }

        public void SetBaseSprite(Texture2D sprite)
        {
            _baseSprite = sprite;
        }
    }
}
