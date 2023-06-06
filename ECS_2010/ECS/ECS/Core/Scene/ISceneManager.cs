using System.Collections.Generic;

namespace ECS.Core.Scene
{
    public interface ISceneManager
    {
        List<Scene> Scenes { get; }
        Scene CurrentScene { get; }
        void RegisterScene(Scene scene);
        void UnregisterScene(Scene scene);

    }
}
