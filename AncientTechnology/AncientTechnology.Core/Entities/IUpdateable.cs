using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientTechnology.Core.Entities
{
    public interface IUpdateable
    {
        void Update(GameTime gameTime);
    }
}
