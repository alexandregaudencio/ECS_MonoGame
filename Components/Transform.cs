using Microsoft.Xna.Framework;
using System;
using System.ComponentModel;

namespace ECS.Components
{

    //TODO: Criar transform default que renderiza por padrão no centro da tela
    public class Transform : Component
    {
        private Matrix matrix = Matrix.Identity;
        public Vector3 Scale { get; set; }
        public Vector3 GetPosition => matrix.Translation;
        public Vector3 Rotation => matrix.Forward;

        public Matrix Matrix => matrix;



        public float AngleRadians => (float)Math.Atan2(Rotation.Y, Rotation.X);
        public float AngleDegrees => (float)(AngleRadians *180.0/Math.PI);

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
            matrix = Matrix.Identity;
            matrix *= Matrix.CreateTranslation(position);
        }

        public void IncreasePosition(Vector3 position)
        {
            matrix *= Matrix.CreateTranslation(position);
        }


        public Vector2 Vect2Position()
        {
            return new Vector2(GetPosition.X, GetPosition.Y);
        }

        public Vector2 Vect2Rotation()
        {
            return new Vector2(Rotation.X, Rotation.Y);
        }

        public Vector2 Vect2Scale()
        {
            return new Vector2(Scale.X, Scale.Y);
        }

        public void SetRotationX(float value)
        {
            matrix *= Matrix.CreateRotationX(value);
        }
        public void SetRotationY(float value)
        {
            matrix *= Matrix.CreateRotationY(value);
        }
        public void SetRotationZ(float value)
        {
            matrix *= Matrix.CreateRotationZ(value);
        }

        internal void SetRotation(Vector3 rotation)
        {
            SetRotationX(rotation.X);
            SetRotationY(rotation.Y);
            SetRotationZ(rotation.Z);
            
        }
    }
}
