﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Components.Cam;

namespace ECS.Primitives
{
    public class WirePlane : Plane
    {
        public WirePlane(Game game, ICameraProperties cameraProperties, Vector3 position, float scale, Color color) : base(game, cameraProperties, position, scale, color)
        {

        }

        public override void Draw(GameTime gameTime)
        {
            RasterizerState rs = new RasterizerState();
            rs.CullMode = CullMode.None;
            rs.FillMode = FillMode.WireFrame;
            GraphicsDevice.RasterizerState = rs;

            base.Draw(gameTime);
        }


    }
}
