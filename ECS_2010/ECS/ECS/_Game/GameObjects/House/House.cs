using ECS._Game.GameObjects;
using ECS._Game.GameObjects.House;
using ECS.Core.Components.Cam;
using ECS.Core.Entities;
using ECS.Core.Object;
using Microsoft.Xna.Framework;

namespace ECS._Game
{
    public class House : GameObject
    {
        private readonly Hoof hoof;
        private readonly Box cuboid;
        private readonly float size = 1;
        public House(Game game, ICameraPerspective iCamPerspective, float size = 1) : base(game,iCamPerspective)
        {
            this.size = size;
            cuboid = new Box(game, iCamPerspective);
            hoof = new Hoof(game, iCamPerspective, "madeira", size);

            Transform.IncreaseScale(Vector3.One * size);
            Transform.Translate(new Vector3(7, 0, 2));
            Transform.SetScale(Vector3.One * size);
            hoof.Transform.Translate(Vector3.UnitY);
            cuboid.Transform.IncreaseScale(-new Vector3(0.2f, 0, 0.2f));


            Transform.SetMinYOnFloor();


        }


        public override void Initialize()
        {
            Collider.SetActive(true);
            Collider.SetVisible(true);
            cuboid.Collider.SetActive(false);


            AddChild(cuboid);
            AddChild(hoof);

            Game.Components.Add(hoof);
            Game.Components.Add(cuboid);
            base.Initialize();
        }

    }
}
