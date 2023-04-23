//using ECS.Components;
//using Microsoft.Xna.Framework;
//using ECS.Components.GUI;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ECS.BaseObject
//{
//    public class TextBase : EntityBase
//    {

//        private string spriteFontPath = "File";
//        private TextRenderer TextRenderer { set; get; }
//        //private Transform Transform { get; set; }
//        Vector3 position;
//        float rotation;
//        float scale;
//        public string Text => TextRenderer.Text;

//        public TextBase(Game game, string text, Vector3 position, Vector3 rotation, Vector3 scale) : base(game)
//        {
//            //Transform = new Transform(position, rotation, scale);
//            TextRenderer = new TextRenderer(game, text, spriteFontPath, "");

//        }

//        public override void Update(GameTime gameTime)
//        {
//            float speed = 0.001f;
//            #region so para brincar
//            Transform.Rotation += new Vector3(speed * gameTime.ElapsedGameTime.Milliseconds,speed*gameTime.ElapsedGameTime.Milliseconds, 0); ;
//            base.Update(gameTime);
//            #endregion
//        }

//        public override void Initialize()
//        {
//            Game.Components.Add(TextRenderer);
//            Transform.Position = new Vector3(Game.Window.ClientBounds.Width/2, Game.Window.ClientBounds.Height/2, 0);
//            base.Initialize();
//        }

//        public void SetText(string text)
//        {
//            TextRenderer.SetText(text);
//        }



//    }
//}
