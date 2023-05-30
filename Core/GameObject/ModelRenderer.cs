using ECS.Core.Components.Cam;
using ECS.Core.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Core.GameObject
{
    internal class GameObject : Entity
    {
        private ICameraPerspective icameraPerspective;
        Model model;
        private string modelPath = "";

        public GameObject(Game game, ICameraPerspective icameraPerspective, string modelPath = "") : base(game)
        {
            this.modelPath = modelPath;
            this.icameraPerspective = icameraPerspective;
        }

        protected override void LoadContent()
        {
            if (string.IsNullOrEmpty(modelPath)) throw new NullReferenceException("modelPath is null.");
            model = Game.Content.Load<Model>(modelPath);

            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (ModelMesh mesh in this.model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    
                effect.EnableDefaultLighting();
                    effect.World = Transform.Matrix * mesh.ParentBone.Transform;
                    effect.View = icameraPerspective.View;
                    effect.Projection = icameraPerspective.Projection;
                }
                mesh.Draw();
            }

            base.Draw(gameTime);
        }


    }
}
