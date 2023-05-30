using ECS.Core.Components.Cam;
using ECS.Core.Entities;
using ECS.Core.Primitives;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Core.BaseObject.House
{
    public class Hoof : Entity
    {
        HoofTriangle[] triangles = new HoofTriangle[4];

        public Hoof(Game game, ICameraPerspective iCamPerspective, string texturePath, float size) : base(game)
        {
            Transform.IncreaseScale(Vector3.One * size);


            for (int i = 0; i < triangles.Length; i++)
            {
                
                triangles[i] = new HoofTriangle(game, iCamPerspective, Color.White, texturePath);
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
