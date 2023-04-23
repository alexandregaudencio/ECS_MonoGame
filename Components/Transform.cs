using Microsoft.Xna.Framework;
using System;
using System.ComponentModel;

namespace ECS.Components
{

    //TODO: Criar transform default que renderiza por padrão no centro da tela
    public class Transform : Component
    {
        private Matrix matrix = Matrix.Identity;
        public Vector3 Scale { get; set; } = Vector3.One;
        public Vector3 Position { get; set; } = Vector3.Zero;
        public Vector3 Rotation { get; set; } = Vector3.Zero;

        public Matrix Matrix => matrix;



        public float AngleRadians => (float)Math.Atan2(Rotation.Y, Rotation.X);
        public float AngleDegrees => (float)(AngleRadians *180.0/Math.PI);

        public Transform()
        {
        }
        public Transform(Vector3 Position)
        {
            SetPosition(Position);
        }

        public Transform(Vector3 position , Vector3 rotation, Vector3 scale)
        {
            SetPosition(position);
            SetRotation(rotation);
            Scale = scale; 
        }


        public void SetPosition(Vector3 position)
        {
            Position = position;
            matrix = Matrix.Identity;
            matrix *= Matrix.CreateTranslation(position);
        }

        public void Translate(Vector3 position)
        {
            Position += position;
            matrix *= Matrix.CreateTranslation(position);
        }

        public void Rotate(Vector3 rotation)
        {
            Rotation += rotation;
            matrix = Matrix.Identity;
            matrix *= Matrix.CreateRotationX(Rotation.X);
            matrix *= Matrix.CreateRotationY(Rotation.Y);
            matrix *= Matrix.CreateRotationZ(Rotation.Z);
            matrix *= Matrix.CreateTranslation(Position);
        }
        public void SetRotation(Vector3 rotation)
        {
            Rotation = rotation;
            matrix = Matrix.Identity;
            matrix *= Matrix.CreateRotationX(Rotation.X);
            matrix *= Matrix.CreateRotationY(Rotation.Y);
            matrix *= Matrix.CreateRotationZ(Rotation.Z);
            matrix *= Matrix.CreateTranslation(Position);
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

    }
}
