using AncientTechnology.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientTechnology.Core.Control.Managers
{
    public class MainManager : IUpdateable
    {
        private IList<IUpdateable> _boiler = new List<IUpdateable>();

        public IList<IVisualObject> ObjectsToDraw
        {
            get
            {
                return _boiler.Where(x => x is IVisualObject)
                    .Cast<IVisualObject>()
                    .ToList();
            }
        }

        public void Add(IUpdateable updateable)
        {
            _boiler.Add(updateable);
        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            foreach (var updateable in _boiler)
            {
                updateable.Update(gameTime);
            }
        }
    }
}
