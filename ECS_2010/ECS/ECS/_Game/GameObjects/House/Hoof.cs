﻿using ECS.Core.Components.Cam;
using ECS.Core.Entities;
using Microsoft.Xna.Framework;

namespace ECS._Game.GameObjects.House
{
    public class Hoof : Entity
    {
        HoofTriangleObject[] triangles = new HoofTriangleObject[4];

        public Hoof(Game game, ICameraPerspective iCamPerspective, string texturePath, float size) : base(game)
        {


            for (int i = 0; i < triangles.Length; i++)
            {

                triangles[i] = new HoofTriangleObject(game, iCamPerspective);
                //triangles[i].Transform.IncreaseScale(Vector3.One);
                triangles[i].Transform.Rotate(Vector3.UnitY * MathHelper.ToRadians(i * 90));
                //triangles[i].Transform.Rotate(Vector3.UnitX* MathHelper.ToRadians(i * 45));
            }

        }

        public override void Initialize()
        {

            foreach (var tri in triangles)
            {
                AddChild(tri);
                Game.Components.Add(tri);
            }
            base.Initialize();
        }




    }
}
