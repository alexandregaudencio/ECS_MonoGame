using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECS.Core.Object;
using Microsoft.Xna.Framework;
using ECS.Core.Components.Cam;
using ECS.Core.Components.Renderers;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;


namespace ECS._Game.GameObjects
{
    class Tree : GameObject
    {
        private readonly Camera camera;
        public Tree(Game game, Camera camera) : base(game, camera)
        {
            this.camera = camera;
            Renderer = new Renderer(game, camera, new Quad(Color.White, "Tree"));


            Transform.SetScale(Vector3.One *2);
            //Transform.RotateX(MathHelper.PiOver2);
            Transform.Translate(new Vector3(4,0,4));

             Transform.SetMinYOnFloor();


        }


        public override void Initialize()
        {
            Renderer.Game.GraphicsDevice.BlendState = BlendState.AlphaBlend;

            base.Initialize();
        }


        public override void Update(GameTime gameTime)
        {
            Transform.LookAt(camera.Transform);
            //Debug.WriteLine(Transform.Rotation.Y);
            base.Update(gameTime);
        }







    }
}
