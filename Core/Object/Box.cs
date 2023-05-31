using ECS.Core.Components.Cam;
using ECS.Core.Components.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Core.Object
{
    internal class Box : GameObject
    {
        public bool movivel = true;
        public Box(Game game, ICameraPerspective cameraPerspective, string modelPath = "") : base(game, cameraPerspective, modelPath)
        {
            //Transform.SetScale(Vector3.One * 0.05f);
            //Transform.Translate(Vector3.UnitZ );
        }


        public override void Initialize()
        {
            //AddChild(Collider);
            //AddChild(ModelRenderer);
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (!movivel) return;
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                Transform.Translate(-Vector3.UnitX * 0.02f);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Transform.Translate(Vector3.UnitX * 0.02f);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                Transform.Rotate(-Vector3.UnitY * 0.02f);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                Transform.Rotate(Vector3.UnitY * 0.02f);
            }
            base.Update(gameTime);
        }



    }
}
