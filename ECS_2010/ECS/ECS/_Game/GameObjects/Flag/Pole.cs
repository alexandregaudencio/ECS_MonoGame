using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECS.Core.Entities;
using ECS.Core.Components.Renderers;
using ECS.Core.Components.Cam;
using Microsoft.Xna.Framework;

namespace ECS._Game.GameObjects
{
    class Pole : Entity
    {
        Renderer renderer;
        public Pole(Game game, ICameraPerspective camPerspective)
            : base(game)
        {
            renderer = new Renderer(game, camPerspective, new Cuboid(Color.Brown, ""));
        }

        public override void Initialize()
        {
            AddChild(renderer);
            Game.Components.Add(renderer);
            base.Initialize();
        }


    }

}
