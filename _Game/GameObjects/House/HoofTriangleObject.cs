﻿using ECS.Core.Components.Cam;
using ECS.Core.Components.Renderers;
using ECS.Core.Object;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS._Game.GameObjects.House
{
    internal class HoofTriangleObject : GameObject
    {
        public HoofTriangleObject(Game game, ICameraPerspective cameraPerspective) : base(game, cameraPerspective)
        {
            Renderer = new Renderer(game, cameraPerspective, new HoofTriangle(Color.White, "madeira"));
        }


    }
}
