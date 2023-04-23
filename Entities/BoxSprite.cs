//using ECS.BaseObject;
//using ECS.Components;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Schema;

//namespace ECS.Entities
//{
//    public class BoxSprite : SpriteBase
//    {

//        private readonly Dictionary<string, Animation> nameAnimationPairs = new();
//        public Animator2D animator2D;

//        public BoxSprite(Game game, string texturePath, Vector3 position, Vector3 rotation, Vector3 scale) : base(game, texturePath, position, rotation, scale)
//        {
//            nameAnimationPairs.Add("box", new Animation(game, "Images/Boxes/box", 3, true, 01f));

//            animator2D = new Animator2D(game, Renderer, nameAnimationPairs);
//            animator2D.Play("box");

//        }

//        public override void Initialize()
//        {
//            Game.Components.Add(animator2D);
//            base.Initialize();
//        }


//    }




//}
