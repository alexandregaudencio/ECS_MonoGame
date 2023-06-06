using Microsoft.Xna.Framework;
using ECS.Core.Util.Extensions;
using System;
using System.Diagnostics;

namespace ECS.Core.Components
{

    public class Transform : DrawableGameComponent /*, INotifyPropertyChanged*/
    {
        public Transform Parent { get; set; }
        public Matrix World { get; private set; }
        public Vector3 Scale { get; private set; }
        public Vector3 Translation { get; private set; } 
        public Vector3 Rotation { get; private set; } 


        //used to notify childs transform: position, rotation, scale;
        //public event Action<Vector3, Vector3> TransformChanged;

        //TODO: for 2D (sprites and text GUI)
        //public float AngleRadians => (float)Math.Atan2(Rotation.Y, Rotation.X);
        //public float AngleDegrees => (float)(AngleRadians * 180.0 / Math.PI);

        private void InitilizeProperties() 
        {
            World = Matrix.Identity;
            Scale = Vector3.One;
            Translation = Vector3.Zero;
            Rotation = Vector3.Zero;
        }

        public void SetParent(Transform transform)
        {
            Parent = transform;
        }




        public Transform(Game game) : base(game)
        {
            InitilizeProperties();
            UpdateTransform();
        }

        public Transform(Game game, Vector3 Position) : base(game)
        {
            InitilizeProperties();
            SetTranslation(Position);
            UpdateTransform();
        }


        public Transform(Game game, Vector3 position, Vector3 rotation, Vector3 scale) : base(game)
        {
            InitilizeProperties();
            SetTranslation(position);
            SetRotation(rotation);
            SetScale(scale);
            UpdateTransform();

        }


        public override void Update(GameTime gameTime)
        {
            UpdateTransform();
            base.Update(gameTime);
        }


        private void UpdateTransform()
        {
            World = Matrix.Invert(World);

            World = Matrix.Identity;
            World *= Matrix.CreateScale(Scale);
            World *= Matrix.CreateRotationX(Rotation.X);
            World *= Matrix.CreateRotationY(Rotation.Y);
            World *= Matrix.CreateRotationZ(Rotation.Z);
            World *= Matrix.CreateTranslation(Translation);

            World *= (Parent != null) ? Parent.World : Matrix.Identity;

        }


        public void SetTranslation(Vector3 position)
        {

            Translation = position;
        }

        public void Translate(Vector3 position)
        {
            Translation += position;
        }

        public void SetRotation(Vector3 rotation)
        {
            Rotation = rotation;
        }

        public void Rotate(Vector3 rotation)
        {
            Rotation += rotation;
        }

        public void RotateX(float value)
        {
            Rotate(new Vector3(value, 0, 0));
        }
        public void RotateY(float value)
        {
            Rotate(new Vector3(0, value, 0));
        }
        public void RotateZ(float value)
        {
            Rotate(new Vector3(0, 0, value));
        }


        public void SetScale(Vector3 scale)
        {
            Scale = scale;
        }

        public void IncreaseScale(Vector3 scale)
        {
            Scale += scale;
        }

        public void SetMinYOnFloor()
        {
            Translate(Vector3.UnitY * Scale.Y);

        }


        public void LookAt(Transform target)
        {
            Vector3 direction = (target.Translation - Translation);
            float angle = (float)Math.Atan2(direction.X, direction.Z);
            
            SetRotation(new Vector3(0, 0, 0));
            RotateX(MathHelper.PiOver2);
            RotateY(angle);


        }

    }



}

