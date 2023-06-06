using Microsoft.Xna.Framework;

namespace ECS.Core.Util.Patterns
{
    public interface IStrategyGameComponent<T>
    {
        void Load();
        void Initialize();
        void Draw(GameTime gameTime);
        void Update(GameTime gameTime);
    }
}
