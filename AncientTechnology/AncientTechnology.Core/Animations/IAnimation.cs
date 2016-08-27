using AncientTechnology.Core.Entities;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace AncientTechnology.Core.Animations
{
    public interface IAnimation : IUpdateable
    {
        Texture2D CurrentFrame { get; }

        TimeSpan FrameRate { get; set; }

        void Reset();

        void SetFrames(params Texture2D[] frames);
    }
}