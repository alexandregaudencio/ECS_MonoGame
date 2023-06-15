using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECS.Core.Object;
using ECS.Core.Components.Renderers;
using Microsoft.Xna.Framework;
using ECS.Core.Components.Cam;
using ECS.Core.Components.Collision;

namespace ECS._Game
{
    class Boat : GameObject
    {
        BoatStateMachineController stateController;

        public Boat(Game game, ICameraPerspective camera)
            : base(game, camera)
        {
            Renderer = new Renderer(game, camera, new Cuboid(Color.Red, "metal2"));

            MovementControl.SetActive(true);

            Transform.Translate(Vector3.UnitY * 4);
            Transform.SetScale(Vector3.One * 3);
            stateController = new BoatStateMachineController(game, this);

            Renderer.SetActive(true);
            Collider.SetActive(true);
            Collider.SetVisible(true);

        }


        public override void OnCollisionEnter(ICollider other)
        {
            stateController.OnCollisionEnter(other);
            base.OnCollisionEnter(other);
        }

        public override void OnCollisionStay(ICollider other)
        {
            stateController.OnCollisionStay(other);
            base.OnCollisionEnter(other);
        }

        public override void OnCollisionExit(ICollider other)
        {
            stateController.OnCollisionExit(other);
            base.OnCollisionEnter(other);
        }


    }
}
