namespace AncientTechnology.Core.Entities
{
    public interface IMovableObject : IUpdateable
    {
        float Speed { get; set; }

        void Move(Orientation direction);
    }
}
