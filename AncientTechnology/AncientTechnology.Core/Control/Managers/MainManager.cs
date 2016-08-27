using AncientTechnology.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace AncientTechnology.Core.Control.Managers
{
    public class MainManager : Entities.IUpdateable
    {
        private IList<Entities.IUpdateable> _boiler = new List<Entities.IUpdateable>();

        public IList<IVisualObject> ObjectsToDraw
        {
            get
            {
                return _boiler.Where(x => x is IVisualObject)
                    .Cast<IVisualObject>()
                    .ToList();
            }
        }

        public void Add(Entities.IUpdateable updateable)
        {
            _boiler.Add(updateable);
        }

        public void Update(GameTime gameTime)
        {
            foreach (var updateable in _boiler)
            {
                updateable.Update(gameTime);
            }
        }
    }
}
