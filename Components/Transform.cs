using Microsoft.Xna.Framework;
using System.ComponentModel;

namespace ECS.Components
{

    //TODO: Criar transform default que renderiza por padrão no centro da tela
    public class Transform<T>: Component where T : struct
    {
        private T position;
        private float rotation;
        private float scale;

        public float Scale { get => scale; set => scale = value; }
        public T Position { get => position; set => position = value; }
        public float Rotation { get => rotation; set => rotation = value; }


        public Transform(T position , float rotation, float scale)
        {
            Position = position;
            Rotation = rotation;
            Scale = scale; 
        }


    }
}
