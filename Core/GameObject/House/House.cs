using ECS.Core.Components.Cam;
using ECS.Core.Entities;
using ECS.Core.Primitives;
using ECS.Core.Util;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Core.BaseObject.House
{
    public class House : Entity
    {
        private Hoof hoof;
        private Cuboid cuboid;
        private float size = 1;
        public House(Game game, ICameraPerspective iCamPerspective, float size = 10) : base(game)
        {
            this.size = size;
            cuboid = new Cuboid(game, iCamPerspective, new Color().Random());
            cuboid.Transform.IncreaseScale(Vector3.One * (size));
            cuboid.Transform.IncreaseScale(-new Vector3(1, 0, 1) * (size * 0.2f));
            hoof = new Hoof(game, iCamPerspective, "madeira", size);
            hoof.Transform.Translate(Vector3.UnitY*size);

            AddChild(cuboid);
            AddChild(hoof);
        }


        public override void Initialize()
        {
            Transform.Translate(Vector3.UnitY * size);

            Game.Components.Add(hoof);
            Game.Components.Add(cuboid);
            base.Initialize();
        }

    }
}
