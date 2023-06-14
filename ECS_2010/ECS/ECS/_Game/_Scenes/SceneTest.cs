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
        private readonly SnowController snowController;

        private readonly Floor floor;

        private WindMill windMill; 
        private WindMill windMill2;
        private readonly Box box;
        private readonly Box box2;

        private readonly House house;
        private readonly Player player;

        private readonly Forest forest;




        public SceneTest(Game game, string name) : base(game, name)
        {
            camera = new Camera(game, new Vector3(5, 3, 10)*4);
            cameraController = new CameraController(game, camera);
            snowController = new SnowController(game);

            floor = new Floor(game,camera);
            box = new Box(game, camera);
            box2 = new Box(game, camera);
            windMill = new WindMill(game, camera );
            windMill.Transform.Translate(new Vector3(-13, 3, 13));
            windMill.Transform.RotateY(MathHelper.PiOver4);

            windMill2 = new WindMill(game, camera);
            windMill2.Transform.Translate(new Vector3(-13, 3, 3));


            floor.Transform.SetScale(new Vector3(1, 0, 1) * 50);
            floor.Transform.Translate(-new Vector3(0, 0, 1) * 30);
            box.Transform.Translate(new Vector3(-5, 0, 5));
            box.Transform.SetMinYOnFloor();


            box2.Transform.SetMinYOnFloor();
            box2.Transform.Translate(Vector3.UnitX * 4);

            player = new Player(game, camera);
            player.Transform.SetMinYOnFloor();
            house = new House(game, camera);

            forest = new Forest(game, camera, 10);


        }

        public override void Initialize()
        {

            Game.Components.Add(camera);
            Game.Components.Add(cameraController);
            Game.Components.Add(snowController);
            Game.Components.Add(floor);
            Game.Components.Add(box);
            Game.Components.Add(box2);
            Game.Components.Add(windMill); 
            Game.Components.Add(windMill2);
            Game.Components.Add(house);
            Game.Components.Add(player);
            Game.Components.Add(forest);



            base.Initialize();
        }




    }
}
