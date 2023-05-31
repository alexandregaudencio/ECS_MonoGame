using ECS.Core.Components;
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

namespace ECS.Core.Components.Renderer
{
    internal class ModelRenderer : DrawableGameComponent
    {
        private ICameraPerspective icameraPerspective;
        Model model;
        private Transform transform;
        private string modelPath = "";
        private static string defaultModelPath = "cube";

        public ModelRenderer(Game game, ICameraPerspective icameraPerspective, Transform transform, string modelPath = "") : base(game)
        {
            this.modelPath = modelPath;
            this.icameraPerspective = icameraPerspective;
            this.transform = transform;
        }

        protected override void LoadContent()
        {
            if (string.IsNullOrEmpty(modelPath)) {
                //throw new NullReferenceException("modelPath is null."); 
                model = Game.Content.Load<Model>(defaultModelPath);
                return;
            }
            model = Game.Content.Load<Model>(modelPath);
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects.Cast<BasicEffect>())
                {

                    //effect.EnableDefaultLighting();
                    effect.World = transform.Matrix * mesh.ParentBone.Transform;
                    effect.View = icameraPerspective.View;
                    effect.Projection = icameraPerspective.Projection;
                }
                mesh.Draw();
            }

            base.Draw(gameTime);
        }



        //public void SetFillMode(FillMode fillMode)
        //{
        //    Model model; // Seu modelo 3D
        //    bool wireframeMode = true; // Define se o modo de fio está ativado

        //    foreach (ModelMesh mesh in model.Meshes)
        //    {
        //        foreach (ModelMeshPart meshPart in mesh.MeshParts)
        //        {
        //            BasicEffect effect = (BasicEffect)meshPart.Effect;

        //            // Defina o FillMode como Wireframe, se o modo de fio estiver ativado
        //            if (wireframeMode)
        //            {
        //                effect.FillMode = FillMode.WireFrame;
        //            }
        //            else
        //            {
        //                effect.FillMode = FillMode.Solid; // Preenchimento sólido
        //            }
        //        }
        //    }

        //}



    }
}
