using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientTechnology.Core.Animations
{
    public interface IAnimationDictionary
    {
        Texture2D CurrentSprite { get; }

        void SetState(string state);

        void AddAnimation(IAnimation animation);
    }
}
