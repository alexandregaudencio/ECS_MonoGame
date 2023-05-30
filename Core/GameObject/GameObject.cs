using ECS.Core.Components.Cam;
using ECS.Core.Components.Renderer;
using ECS.Core.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Core.GameObject
{
    public abstract class GameObject : Entity
    {
        private ModelRenderer modelRenderer;
        
        public GameObject(Game game, ICameraPerspective cameraPerspective, string modelPath = "" ) : base(game)
        {
            modelRenderer = new ModelRenderer(game, cameraPerspective, Transform, modelPath);

        }


        public override void Initialize()
        {
            Game.Components.Add(modelRenderer);
            base.Initialize();
        }



    }
}
