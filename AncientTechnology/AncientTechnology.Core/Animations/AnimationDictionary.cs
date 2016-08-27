using AncientTechnology.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace AncientTechnology.Core.Animations
{
    public class AnimationDictionary : BaseUpdateableObject, IAnimationDictionary
    {
        private IDictionary<State, IAnimation> _animations = new Dictionary<State, IAnimation>();
        private State _state = State.General;

        public Texture2D CurrentSprite
        {
            get
            {

                if (_animations.Keys.Contains(_state) == false)
                {
                    return null;
                }

                if (_animations.Count == 0)
                {
                    return null;
                }
                else
                {
                    try
                    {
                        var currentAnimation = _animations[_state];
                        return currentAnimation.CurrentFrame;
                    }
                    catch
                    {
                        Debug.WriteLine("CurrentSprite: Missing animation for state " + _state);
                        return null;
                    }
                }
            }
        }

        public void AddAnimation(State state, IAnimation animation)
        {
            _animations.Add(state, animation);
        }

        public void SetState(State state)
        {
            if (_state == state)
            {
                return;
            }
            else
            {
                _state = state;

                foreach (var animation in _animations)
                {
                    animation.Value.Reset();
                }
            }
        }

        public override void Initialize()
        {
        }

        public override void Update(GameTime gameTime)
        {
            if (_animations.Keys.Contains(_state) == false)
            {
                return;
            }

            if (_animations.Count == 0)
            {
                return;
            }
            else
            {
                try
                {
                    _animations[_state].Update(gameTime);
                }
                catch
                {
                    Debug.WriteLine("Update: Missing animation for state " + _state);
                }
            }
        }
    }
}
