namespace AncientTechnology.Core.Entities
{
    public interface IMovableObject
    {
        float Speed { get; set; }

        void Move(Orientation direction);
    }
}
