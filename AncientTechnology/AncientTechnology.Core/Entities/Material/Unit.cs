using AncientTechnology.Core.Control.Managers;

namespace AncientTechnology.Core.Entities.Material
{
    public class Unit : MovableObject, IUnit
    {
        public Unit(MainManager manager)
            : base(manager)
        {
        }
    }
}
