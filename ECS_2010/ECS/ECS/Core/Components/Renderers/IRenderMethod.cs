
namespace ECS.Core.Components.Renderers
{
    /// <summary>
    /// Providing a interface for objects render methods.
    /// </summary>
    public interface IRenderMethod
    {
        void SetRenderer(Renderer renderer);
        void Load();
        void Initialize();
        void Draw();
    }
}
