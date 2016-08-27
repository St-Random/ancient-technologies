using AncientTechnology.Core.Camera;
using AncientTechnology.Core.Entities.Material;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientTechnology.Core.Entities {
    public class GameLevel {
        public int Id { get; set; }
        public string Name { get; set; }
        public Vector2 EntryPoint { get; set; }
        public IEnumerable<IUpdateable> GameObjects { get; set; }
        public IUnit Player { get; set; }
        public ICamera2D Camera { get; set; }
    }
}
