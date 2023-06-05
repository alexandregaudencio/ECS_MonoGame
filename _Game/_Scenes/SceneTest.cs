using ECS._Game.GameObjects;
using ECS._Game.GameObjects.House;
using ECS._Game.GameObjects.WindMill;
using ECS.Core.Components.Cam;
using ECS.Core.Scene;
using Microsoft.Xna.Framework;

namespace ECS._Game._Scenes
{
    public class SceneTest : Scene
    {

        #region camera and cameraconfig on Scene
        private readonly Camera camera;
        private readonly CameraController cameraController;
        #endregion

        #region Objects - just for test
        private readonly Floor floor;

        private WindMill windMill;
        private readonly Box box;
        private readonly Box box2;

        private readonly House house;
        #endregion


        public SceneTest(Game game, string name) : base(game, name)
        {
            camera = new Camera(game, new Vector3(10, 3, 2)*2);
            cameraController = new CameraController(game, camera);

            floor = new Floor(game,camera);
            box = new Box(game, camera);
            box2 = new Box(game, camera);
            windMill = new WindMill(game, camera, Vector3.One );
            windMill.Transform.Translate(new Vector3(3, 0, 3));
           
            floor.Transform.SetScale(new Vector3(1,0,1) * 10);
            box2.SetObjectOnFloorY();
            box.SetObjectOnFloorY();
            box2.Transform.Translate(Vector3.UnitX * 4);
            box2.MovementControl.Active = true;


            house = new House(game, camera);

            //sphere = new Sphere(game, camera);
            //sphere.SetObjectOnFloorY();
            //sphere.Transform.Translate(Vector3.UnitZ * 3);


        }

        public override void Initialize()
        {

            #region Add Instances of test
            Game.Components.Add(camera);
            Game.Components.Add(cameraController);
            Game.Components.Add(floor);
            Game.Components.Add(box);
            Game.Components.Add(box2);
            //Game.Components.Add(sphere);
            Game.Components.Add(windMill);
            Game.Components.Add(house);
            #endregion

            base.Initialize();
        }




    }
}
