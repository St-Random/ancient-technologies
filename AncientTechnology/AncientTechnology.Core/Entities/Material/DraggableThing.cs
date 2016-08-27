using AncientTechnology.Core.Control.Managers;

namespace AncientTechnology.Core.Entities.Material
{
    public class DraggableThing : MovableObject, IThing
    {
        public DraggableThing(MainManager manager)
            : base(manager)
        {
        }
    }
}
