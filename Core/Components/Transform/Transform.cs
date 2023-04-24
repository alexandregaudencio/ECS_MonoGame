using Microsoft.Xna.Framework;
using System;
using System.ComponentModel;

namespace ECS.Core.Components
{

    //TODO: Criar transform default que renderiza por padrão no centro da tela
    public class Transform : Component
    {
        public Matrix Matrix { get; private set; } = Matrix.Identity;
        public Vector3 Scale { get; private set; } = Vector3.One;
        public Vector3 Translation { get; private set; } = Vector3.Zero;
        public Vector3 Rotation { get; private set; } = Vector3.Zero;
        //public Matrix Matrix => matrix;

        //used to notify childs transform
        public event Action<Transform> TransformChanged;

        //TODO: for 2D (sprites and text GUI)
        //public float AngleRadians => (float)Math.Atan2(Rotation.Y, Rotation.X);
        //public float AngleDegrees => (float)(AngleRadians * 180.0 / Math.PI);





        public void Transformate(Transform transform)
        {
            Translate(transform.Translation);

            Rotate(transform.Rotation);
            IncreaseScale(transform.Scale);

            TransformChanged?.Invoke(transform);
        }




        public Transform()
        {
        }

        public Transform(Vector3 Position)
        {
            SetTranslation(Position);
        }


        public Transform(Vector3 position, Vector3 rotation, Vector3 scale)
        {
            SetTranslation(position);
            SetRotation(rotation);
            SetScale(scale);
        }

        public Transform _InstanceTransform(Vector3 position, Vector3 rotation, Vector3 scale)
        {
            return new Transform(position, rotation, scale);
        }


        public void SetTranslation(Vector3 position)
        {
            Translation = position;
            Matrix = Matrix.Identity;
            Matrix *= Matrix.CreateTranslation(position);

            TransformChanged?.Invoke(_InstanceTransform(position, Vector3.Zero, Vector3.One));


        }

        public void Translate(Vector3 position)
        {
            Translation += position;
            Matrix = Matrix.Identity;
            Matrix *= Matrix.CreateTranslation(position);

            TransformChanged?.Invoke(_InstanceTransform(position, Vector3.Zero, Vector3.One));

        }

        public void Rotate(Vector3 rotation)
        {
            Rotation += rotation;
            Matrix = Matrix.Identity;
            Matrix *= Matrix.CreateRotationX(Rotation.X);
            Matrix *= Matrix.CreateRotationY(Rotation.Y);
            Matrix *= Matrix.CreateRotationZ(Rotation.Z);
            Matrix *= Matrix.CreateTranslation(Translation);

            TransformChanged?.Invoke(_InstanceTransform(Vector3.Zero, rotation, Vector3.One));
        }
        public void SetRotation(Vector3 rotation)
        {
            Rotation = rotation;
            Matrix = Matrix.Identity;
            Matrix *= Matrix.CreateRotationX(Rotation.X);
            Matrix *= Matrix.CreateRotationY(Rotation.Y);
            Matrix *= Matrix.CreateRotationZ(Rotation.Z);
            Matrix *= Matrix.CreateTranslation(Translation);

            TransformChanged?.Invoke(_InstanceTransform(Vector3.Zero, rotation, Vector3.One));
        }
        public void RotateX(float value)
        {
            Rotate(Vector3.Right * value);
        }
        public void RotateY(float value)
        {
            Rotate(Vector3.Up * value);
        }
        public void RotateZ(float value)
        {
            Rotate(Vector3.Forward * value);

        }



        public void IncreaseScale(Vector3 scale) {
            Scale += scale;
           // Scale *= scale;


        }
        public void SetScale(Vector3 scale)
        {
            Scale = scale;

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
