using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;


namespace ECS.Core.Components.Renderers
{
    public class ModelRenderMethod : RenderMethod
    {
        public Model model { get; set; }
        public readonly string modelPath = "";
        public readonly string defaultModelPath = "cube";

        public ModelRenderMethod(string modelPath = "")
        {
            this.modelPath = modelPath;

        }

        public override void Load()
        {
            if (string.IsNullOrEmpty(modelPath))
            {
                model = Renderer.Game.Content.Load<Model>(defaultModelPath);
                return;
            }
            model = Renderer.Game.Content.Load<Model>(modelPath);

        }

        public override void Initialize()
        {
        }

        public override void Draw()
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects.Cast<BasicEffect>())
                {

                    //effect.EnableDefaultLighting();
                    effect.World = Renderer.Transform.World /*  * mesh.ParentBone.Transform*/;
                    effect.View = Renderer.icameraPerspective.View;
                    effect.Projection = Renderer.icameraPerspective.Projection;
                }
                mesh.Draw();
            }
        }


    }
}
