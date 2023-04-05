﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Primitives
{
    internal class WireCuboid : Cuboid
    {
        
        public WireCuboid(Game game, Vector3 position, float scale, Color color) : base(game, position, scale, color)
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
