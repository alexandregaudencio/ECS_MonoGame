using ECS.Components;
using Microsoft.Xna.Framework;
using ECS.Components.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.BaseObject
{
    public class TextBase : EntityBase
    {
        private string text = "hello";
        private string spriteFontPath = "File";
        private TextRenderer TextRenderer { set; get; }
        private Transform<Vector2> Transform { get; set; }
        public string Text { get => text; set => text = value; }

        public TextBase(Game game, string text, Vector2 position, float rotation, float scale) : base(game)
        {
            Text = text;
            Transform = new Transform<Vector2>(position, rotation, scale);
            TextRenderer = new TextRenderer(game, text, spriteFontPath, Transform, "");

        }

        public override void Update(GameTime gameTime)
        {
            #region so para brincar
            Transform.Rotation -= 0.001f * gameTime.ElapsedGameTime.Milliseconds;
            base.Update(gameTime);
            #endregion
        }

        public override void Initialize()
        {
            Game.Components.Add(TextRenderer);
            Transform.Position = new Vector2(Game.Window.ClientBounds.Width/2, Game.Window.ClientBounds.Height/2);
            base.Initialize();
        }

        public void SetText(string text)
        {
            this.text = text;
            TextRenderer.SetText(text);
        }



    }
}
