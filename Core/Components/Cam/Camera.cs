using ECS.Core.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;

namespace ECS.Core.Components.Cam
{
    public class Camera : Entity, ICamPerspective, ICameraProjectionProperties, ICameraViewProperties
    {

        //PROJECTION PROPERTIES
        public float FieldOfView { get; set; }
        public float AspectRatio
        {
            get => Game.Window.ClientBounds.Width / (float)Game.Window.ClientBounds.Height;
            set => AspectRatio = value;
        }
        public float NearPlaneDistance { get; set; }
        public float FarPlaneDistance { get; set; }


        //View properties
        public Vector3 CameraTarget { get; set; }
        public Vector3 CameraUpVector { get; set; }

        //CAMERA PROPERTIES
        public Matrix View => Matrix.CreateLookAt(Transform.Matrix.Translation, CameraTarget, CameraUpVector);
        public Matrix Projection => Matrix.CreatePerspectiveFieldOfView(FieldOfView, AspectRatio, NearPlaneDistance, FarPlaneDistance);


        public Camera(Game game, Transform transform) : base(game)
        {
            Transform = transform;
            CameraTarget = Vector3.Zero;
            CameraUpVector = Vector3.Up;

            NearPlaneDistance = 1;
            FarPlaneDistance = 600;
            FieldOfView = MathHelper.PiOver4;


        }




    }
}
