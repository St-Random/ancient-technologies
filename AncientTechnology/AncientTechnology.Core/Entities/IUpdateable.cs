using Microsoft.Xna.Framework;

namespace AncientTechnology.Core.Entities
{
    public interface IUpdateable
    {
        void Initialize();

        void Update(GameTime gameTime);
    }
}
