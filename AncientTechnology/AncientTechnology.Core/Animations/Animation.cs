using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AncientTechnology.Core.Entities;

namespace AncientTechnology.Core.Animations
{
    public class Animation : BaseUpdateableObject, IAnimation
    {
        private IList<Texture2D> _frames = new List<Texture2D>();
        private TimeSpan _elapsedTime = TimeSpan.Zero;
        private int _frameIndex = 0;

        public Texture2D CurrentFrame
        {
            get
            {
                return _frames[_frameIndex];
            }
        }

        private int FrameCount
        {
            get
            {
                return _frames.Count;
            }
        }

        public TimeSpan FrameRate { get; set; }

        public override void Update(GameTime gameTime)
        {
            _elapsedTime += gameTime.ElapsedGameTime;
            if (_elapsedTime >= FrameRate)
            {
                _elapsedTime = TimeSpan.Zero;
                _frameIndex++;

                if (_frameIndex == FrameCount)
                {
                    _frameIndex = 0;
                }
            }
        }

        public void Reset()
        {
            _elapsedTime = TimeSpan.Zero;
            _frameIndex = 0;
        }

        public void SetFrames(params Texture2D[] frames)
        {
            _frames = frames;
        }
    }
}
