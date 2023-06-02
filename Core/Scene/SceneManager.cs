using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace ECS.Core.Scene
{
    public class SceneManager : GameComponent, ISceneManager
    {
        private List<Scene> scenes = new List<Scene>();
        public List<Scene> Scenes => scenes;
        public void RegisterScene(Scene scene)
        {
            scenes.Add(scene);
            Game.Components.Add(scene);
        }
        public void UnregisterScene(Scene scene)
        {
            scenes.Remove(scene);
            Game.Components.Remove(scene);
        }

        private static SceneManager instance;
        public static SceneManager Instance => instance;

        public SceneManager(Game game) : base(game)
        {
            instance = this;
        }






    }
}
