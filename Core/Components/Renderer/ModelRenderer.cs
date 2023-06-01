using ECS.Core.Components.Cam;
using ECS.Core.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace ECS.Core.Components.Renderer
{
    public class ModelRenderer : Entity
    {
        private readonly ICameraPerspective icameraPerspective;
        private Model model;
        private readonly Transform transform;
        private readonly string modelPath = "";
        private static readonly string defaultModelPath = "cube";

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

                    effect.EnableDefaultLighting();
                    effect.World = transform.World /** mesh.ParentBone.Transform*/;
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



        public void SetColor(Color color)
        {

            //if (vertsTexture == null) return;
            //for (int i = 0; i < vertsTexture?.Length; i++)
            //{
            //    vertsTexture[i].Color = Color;
            //}
        }


    }
}
