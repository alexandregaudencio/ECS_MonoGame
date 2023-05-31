using ECS.Core.Components.Cam;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Core.GameObject
{
    internal class Box : GameObject
    {
        public Box(Game game, ICameraPerspective cameraPerspective, string modelPath = "") : base(game, cameraPerspective, modelPath)
        {
            //Transform.SetScale(Vector3.One * 0.1f);
            Transform.Translate(Vector3.UnitZ );
        }


        public override void Initialize()
        {
            base.Initialize();
        }

    }
}
