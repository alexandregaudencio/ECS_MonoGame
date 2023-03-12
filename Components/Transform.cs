using Microsoft.Xna.Framework;
using System;
using System.ComponentModel;

namespace ECS.Components
{

    //TODO: Criar transform default que renderiza por padrão no centro da tela
    public class Transform: Component
    {
        private Vector3 position;
        private Vector3 rotation;
        private Vector3 scale;

        public Vector3 Scale { get => scale; set => scale = value; }
        public Vector3 Position { get => position; set => position = value; }
        public Vector3 Rotation { get => rotation; set => rotation = value; }

        public float AngleRadians => (float)Math.Atan2(Rotation.Y, Rotation.X);
        public float AngleDegrees => (float)(AngleRadians *180.0/Math.PI);


        public Transform(Vector3 position , Vector3 rotation, Vector3 scale)
        {
            Position = position;
            Rotation = rotation;
            Scale = scale; 
        }

        public Vector2 Vect2Position()
        {
            return new Vector2(position.X, position.Y);
        }

        public Vector2 Vect2Rotation()
        {
            return new Vector2(rotation.X, rotation.Y);
        }

        public Vector2 Vect2Scale()
        {
            return new Vector2(scale.X, scale.Y);
        }


    }
}
