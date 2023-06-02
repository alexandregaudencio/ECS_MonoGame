using System.Collections.Generic;

namespace ECS.Core.Scene
{
    public interface ISceneManager
    {
        public List<Scene> Scenes { get; }
        public void RegisterScene(Scene scene);
        public void UnregisterScene(Scene scene);
        //public Scene GetNextScene(Scene scene);
        
        //public Scene GetSceneByName(string name);




    }
}
