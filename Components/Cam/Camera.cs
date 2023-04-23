using ECS.BaseObject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Threading.Tasks.Dataflow;

namespace ECS.Components.Cam
{
    public class Camera : EntityBase, ICamPerspective, ICameraProjectionProperties, ICameraViewProperties
    {
        
        //PROJECTION PROPERTIES
        public float FieldOfView { get; set; }
        public float AspectRatio { 
            get => Game.Window.ClientBounds.Width / (float)Game.Window.ClientBounds.Height; 
            set => AspectRatio = value; 
        }
        public float NearPlaneDistance { get; set; }
        public float FarPlaneDistance { get; set; }


        //View properties
        public Vector3 CameraTarget { get; set; }
        public Vector3 CameraUpVector { get; set; }

        //CAMERA PROPERTIES
        public Matrix View => Matrix.CreateLookAt(transform.Matrix.Translation, CameraTarget, CameraUpVector);
        public Matrix Projection => Matrix.CreatePerspectiveFieldOfView(FieldOfView, AspectRatio, NearPlaneDistance, FarPlaneDistance);


        public Camera(Game game, Transform transform) : base(game)
        {
            base.transform = transform;
            CameraTarget = Vector3.Zero;
            CameraUpVector = Vector3.Up;

            NearPlaneDistance = 1;
            FarPlaneDistance = 100;
            FieldOfView = MathHelper.PiOver4;

            transform.SetPosition(new Vector3(10, 15, 15));

        }




    }
}
