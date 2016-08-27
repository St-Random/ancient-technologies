using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using AncientTechnology.Core.Control.Controllers;

namespace AncientTechnology.Core.Entities
{
    public abstract class BaseUpdateableObject : IUpdateable
    {
        private IController _controller = null;

        public virtual void Update(GameTime gameTime)
        {
            if (_controller != null)
            {
                _controller.Start(this);
            }
        }
    }
}
