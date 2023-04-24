//using ECS.Components;
//using Microsoft.Xna.Framework;
//using ECS.BaseObject;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;

//namespace ECS
//{
//    public class PatoSprite : SpriteBase
//    {
//        Game game;
//        private float speedx = 3f;

//        public PatoSprite(Game game, string texturePath, Vector3 position, Vector3 rotation, Vector3 scale) : base(game, texturePath, position, rotation, scale)
//        {
//            this.game = game;


//        }

//        public override void Initialize()
//        {
//            Transform.Position += new Vector3(0, game.Window.ClientBounds.Height - Renderer.Rectangle.Size.Y / 5, 0);

//            base.Initialize();
//        }

//        public override void Update(GameTime gameTime)
//        {
//            #region so para brincar
//            if (Keyboard.GetState().IsKeyDown(Keys.Left))
//            {
//                Renderer.SpriteEffects = SpriteEffects.None;
//                speedx = Math.Abs(speedx)*-1;
//            }
//            if (Keyboard.GetState().IsKeyDown(Keys.Right))
//            {
//                Renderer.SpriteEffects = SpriteEffects.FlipHorizontally;
//                speedx = Math.Abs(speedx);
//            }

//            #endregion
//            Transform.Position += new Vector3(speedx, 0, 0);

//            base.Update(gameTime);
//        }


//    }
//}
