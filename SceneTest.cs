using ECS.Core.Components.Cam;
using ECS.Core.Object;
using ECS.Core.Scene;
using Microsoft.Xna.Framework;

namespace ECS
{
    public class SceneTest : Scene
    {

        #region camera and cameraconfig on Scene
        private readonly Camera camera;
        private readonly CameraController cameraController;
        #endregion


        #region Objects - just for test
        private readonly ECS.Core.Primitives.Plane floor;
        //private WindMill windMill;
        //private WindMill windMill2;
        //private House house;
        private readonly Box box;
        private readonly Box box2;
        private Sphere sphere;
        #endregion


        public SceneTest(Game game, string name) : base(game, name)
        {
            camera = new Camera(game, new Vector3(0, 10, 2));
            cameraController = new CameraController(game, camera);

            floor = new Core.Primitives.Plane(game, camera, Microsoft.Xna.Framework.Color.DarkBlue);
            floor.Transform.SetScale(Vector3.One * 1000);
            box = new Box(game, camera);
            box2 = new Box(game, camera);
            box2.SetObjectOnFloorY();
            box.SetObjectOnFloorY();
            box2.Transform.Translate(Vector3.UnitX * 4);
            box2.MovementControl.Active = true;

            sphere = new Sphere(game, camera);
            sphere.SetObjectOnFloorY();
            sphere.Transform.Translate(Vector3.UnitZ * 3);

            //box.Transform.IncreaseScale(Vector3.One * 2);
            //house = new House(this, camera);
            //windMill = new WindMill(this, camera, new Vector3(0,0,30 ));

        }



        public override void Initialize()
        {

            #region Add Instances of test
            Game.Components.Add(camera);
            Game.Components.Add(cameraController);
            Game.Components.Add(floor);
            Game.Components.Add(box);
            Game.Components.Add(box2);
            Game.Components.Add(sphere);
            #endregion

            base.Initialize();
        }

    }
}
