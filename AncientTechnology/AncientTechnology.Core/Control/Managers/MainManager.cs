using AncientTechnology.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AncientTechnology.Core.Control.Managers {
    public class MainManager : IUpdateable {
        private IList<IUpdateable> _boiler = new List<IUpdateable>();

        public IEnumerable<IVisualObject> VisualObjects {
            get {
                return _boiler.Where(x => x is IVisualObject)
                        as IEnumerable<IVisualObject>;
            }
        }

        public IEnumerable<IVisualObject> GetObjectsInRectangle(Microsoft.Xna.Framework.Rectangle rectangle) {
            return VisualObjects.Where(o => o.Bounds.Intersects(rectangle));
        }

        public void Add(IUpdateable updateable) {
            _boiler.Add(updateable);
        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime) {
            foreach (var updateable in _boiler) {
                updateable.Update(gameTime);
            }
        }

    }
}
