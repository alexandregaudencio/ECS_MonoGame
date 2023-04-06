using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace ECS.Components.Cam
{
    public class Camera : GameComponent, ICameraProperties, ICameraProjectionProperties, ICameraViewProperties
    {
        private Matrix world;
        private Matrix view;
        private Matrix projection;

        //POV
        private float fieldOfView = MathHelper.PiOver4;
        public float aspectRatio => Game.Window.ClientBounds.Width / (float)Game.Window.ClientBounds.Height;
        private float nearPlaneDistance = 1;
        private float farPlaneDistance = 100;


        public Matrix World => world;
        public Matrix View => view;
        public Matrix Projection => projection;

        //Projection properties
        public float FieldOfView => fieldOfView;
        public float AspectRatio => aspectRatio;
        public float NearPlaneDistance => nearPlaneDistance;
        public float FarPlaneDistance => farPlaneDistance;

        //View properties
        public Vector3 CameraPosition { get; set; }
        public Vector3 CameraTarget { get; set; }
        public Vector3 CameraUpVector { get; set; }

        public Camera(Game game) : base(game)
        {
            fieldOfView = MathHelper.PiOver4;
            CameraPosition = new Vector3(5, 5, 5);
            CameraTarget = Vector3.Zero;
            CameraUpVector = Vector3.Up;
        }


        public override void Initialize()
        {
            world = Matrix.Identity;
            view = Matrix.CreateLookAt(CameraPosition, CameraTarget, CameraUpVector);
            projection = Matrix.CreatePerspectiveFieldOfView(FieldOfView, AspectRatio, NearPlaneDistance, FarPlaneDistance);

            //Game.Components.Add(this);
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.A)) {
                CameraPosition += Vector3.Left*gameTime.ElapsedGameTime.Milliseconds/100;
                view = Matrix.CreateLookAt(CameraPosition, CameraTarget, CameraUpVector);

            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                CameraPosition += Vector3.Right * gameTime.ElapsedGameTime.Milliseconds/100;
                view = Matrix.CreateLookAt(CameraPosition, CameraTarget, CameraUpVector);

            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                CameraPosition += Vector3.Up * gameTime.ElapsedGameTime.Milliseconds / 100;
                view = Matrix.CreateLookAt(CameraPosition, CameraTarget, CameraUpVector);

            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                CameraPosition += Vector3.Down * gameTime.ElapsedGameTime.Milliseconds / 100;
                view = Matrix.CreateLookAt(CameraPosition, CameraTarget, CameraUpVector);

            }
            base.Update(gameTime);
        }





    }
}
