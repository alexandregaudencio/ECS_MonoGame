using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

namespace ECS.Core.Components
{

    public class Transform : DrawableGameComponent/*, INotifyPropertyChanged*/
    {
        public Transform parent { get; set; }
        public Matrix Matrix { get; private set; } = Matrix.Identity;
        public Vector3 Scale { get; private set; } = Vector3.One;

        public Vector3 Translation { get; private set; } = Vector3.Zero;
        public Vector3 Rotation { get; private set; } = Vector3.Zero;

        //public event PropertyChangedEventHandler PropertyChanged;

        //used to notify childs transform: position, rotation, scale;
        //public event Action<Vector3, Vector3> TransformChanged;

        //TODO: for 2D (sprites and text GUI)
        //public float AngleRadians => (float)Math.Atan2(Rotation.Y, Rotation.X);
        //public float AngleDegrees => (float)(AngleRadians * 180.0 / Math.PI);

        public void SetParent(Transform transform)
        {
            parent = transform;
        }




        public Transform(Game game) : base(game)
        {

            //TransformChanged += Transformate;
            //Transformate(Translation, Rotation);
        }

        public Transform(Game game, Vector3 Position) : base(game)
        {
            SetTranslation(Position);
            Transformate();


        }


        public Transform(Game game, Vector3 position, Vector3 rotation, Vector3 scale) : base(game)
        {
            SetTranslation(position);
            SetRotation(rotation);
            SetScale(scale);
            Transformate();

        }


        public override void Update(GameTime gameTime)
        {
            Transformate();

            base.Update(gameTime);
        }


        private void Transformate()
        {
            Matrix = (parent != null) ? parent.Matrix : Matrix.Identity;

            Matrix *= Matrix.CreateTranslation(Translation);

            Matrix *= Matrix.CreateRotationX(Rotation.X);
            Matrix *= Matrix.CreateRotationY(Rotation.Y);
            Matrix *= Matrix.CreateRotationZ(Rotation.Z);
            Matrix = Matrix.Invert(Matrix);
            //Debug.WriteLine(Matrix.Translation);

        }

        public void SetTranslation(Vector3 position)
        {

            Translation = position;
            //TransformChanged?.Invoke(Translation, Rotation);


        }

        public void Translate(Vector3 position)
        {
            Translation += position;
            //TransformChanged?.Invoke(Translation, Rotation);

        }

        public void SetRotation(Vector3 rotation)
        {
            Rotation = rotation;
            //TransformChanged?.Invoke(Translation, Rotation);
        }

        public void Rotate(Vector3 rotation)
        {
            Rotation += rotation;
            //TransformChanged?.Invoke(Translation, Rotation);
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
            // Scale *= scale;
        }





        //public Vector2 Vect2Position()
        //{
        //    return new Vector2(GetPosition.X, GetPosition.Y);
        //}

        //public Vector2 Vect2Rotation()
        //{
        //    return new Vector2(GetRotation.X, GetRotation.Y);
        //}

        //public Vector2 Vect2Scale()
        //{
        //    return new Vector2(Scale.X, Scale.Y);
        //}


        //public void SendTransformChanges(Transform transform)
        //{
        //    TransformChanged?.Invoke(transform);
        //}

    }



}

