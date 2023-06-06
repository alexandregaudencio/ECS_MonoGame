using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ECS.Core.Scene
{
    public class SceneManager : GameComponent, ISceneManager
    {
        private List<Scene> scenes = new List<Scene>();
        public List<Scene> Scenes {get{ return scenes;}}
        public Scene CurrentScene { get; private set; }

        private static SceneManager instance;
        public static SceneManager Instance { get { return instance; } }

        public SceneManager(Game game) : base(game)
        {
            scenes = new List<Scene>();

            instance = this;
        }

        public void RegisterScene(Scene scene)
        {
            scenes.Add(scene);
            //Game.Components.Add(scene);
        }
        public void UnregisterScene(Scene scene)
        {
            scenes.Remove(scene);
            //Game.Components.Remove(scene);
        }

        public void GoToNextScene()
        {
            Game.Components.Remove(CurrentScene);
            int currentIndex = scenes.IndexOf(CurrentScene);
            Debug.WriteLine("index: "+currentIndex);
            if (currentIndex+1 >= scenes.Count) return;

            CurrentScene = scenes[currentIndex + 1];
            Game.Components.Add(CurrentScene);
        }


        public override void Initialize()
        {
            if(scenes.Count > 0) { 
                CurrentScene = scenes[0]; 
            }

            Game.Components.Add(CurrentScene);

            base.Initialize();
        }











    }
}
