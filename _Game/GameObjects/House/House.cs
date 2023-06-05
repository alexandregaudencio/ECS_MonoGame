using ECS._Game.GameObjects;
using ECS.Core.Components.Cam;
using ECS.Core.Entities;
using Microsoft.Xna.Framework;

namespace ECS._Game.GameObjects.House
{
    public class House : Entity
    {
        private readonly Hoof hoof;
        private readonly Box cuboid;
        private readonly float size = 1;
        public House(Game game, ICameraPerspective iCamPerspective, float size = 10) : base(game)
        {
            this.size = size;
            cuboid = new Box(game, iCamPerspective);
            cuboid.Transform.IncreaseScale(Vector3.One * size);
            cuboid.Transform.IncreaseScale(-new Vector3(1, 0, 1) * (size * 0.2f));
            hoof = new Hoof(game, iCamPerspective, "madeira", size);
            hoof.Transform.Translate(Vector3.UnitY * size);

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
