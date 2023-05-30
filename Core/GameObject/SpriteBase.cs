//using ECS.Components;
//using Microsoft.Xna.Framework;
//using ECS.BaseObject;
//using System;

//namespace ECS.BaseObject
//{
//    public  class SpriteBase : EntityBase
//    {
//        private Game game { get; set; }
//        protected Transform Transform { get; set; }  
//        //protected Animator2D Animator { get; set; }
//        //public Renderer2D Renderer { get; set; }

//        protected string TexturePath { get; set; }

//        public SpriteBase(Game game, string texturePath, Vector3 position, Vector3 rotation, Vector3 scale ) : base(game)
//        {
//            this.game = game;
//            TexturePath = texturePath;
//            Transform = new Transform( position, rotation, scale);
//            //TODO: corrigir Layering
//            //Renderer = new Renderer2D(game, TexturePath, Transform, "");

//        }

//        public override void Initialize()
//        {
//            game.Components.Add(Renderer);
//            base.Initialize();
//        }



//    }
//}
