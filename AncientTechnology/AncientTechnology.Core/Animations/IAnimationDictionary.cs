using AncientTechnology.Core.Entities;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientTechnology.Core.Animations
{
    public interface IAnimationDictionary : IUpdateable
    {
        Texture2D CurrentSprite { get; }

        void SetState(State state);

        void AddAnimation(State state, IAnimation animation);
    }
}
