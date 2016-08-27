using AncientTechnology.Core.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientTechnology.Core.Control.Managers {
    public static class MainManagerExtensions {
        public static IEnumerable<IVisualObject> GetObjectsInSquare(this MainManager manager, Vector2 position, float distance) {
            return GetObjectsInRectangle(manager, (int)(position.X - distance / 2), (int)(position.Y - distance / 2), (int)distance, (int)distance);
        }

        public static IEnumerable<IVisualObject> GetObjectsInRectangle(this MainManager manager, int x, int y, int width, int height) {
            return manager.GetObjectsInRectangle(new Rectangle(x, y, width, height));
        }
    }
}
