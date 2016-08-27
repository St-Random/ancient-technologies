using AncientTechnology.Core.Control.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientTechnology.Core.Entities.Material {
    public abstract class MovableObject : MaterialObject, IMovableObject {
        private MainManager _manager;

        public MovableObject(MainManager manager) {
            _manager = manager;
        }
    }
}
