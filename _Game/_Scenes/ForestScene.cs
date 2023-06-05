//using ECS.Core.Components.Cam;
//using ECS.Core.Object;
//using ECS.Core.Scene;
//using Microsoft.Xna.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ECS._Game._Scenes
//{
//    public class ForestScene : Scene
//    {
//        private readonly Box box1;
//        private readonly Box box2;
//        private readonly Camera camera;

//        public ForestScene(Game game, string name) : base(game, name)
//        {
//            camera = new Camera(game, Vector3.UnitY * 10);

//            box1 = new Box(game, camera);
//            box2 = new Box(game, camera);

//        }

//        public override void Initialize()
//        {
//            Game.Components.Add(box1);
//            Game.Components.Add(box2);

//            base.Initialize();
//        }


//    }
//}
