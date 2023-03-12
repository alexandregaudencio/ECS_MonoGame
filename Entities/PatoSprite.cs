using ECS.Components;
using Microsoft.Xna.Framework;
using ECS.BaseObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Entities
{
    public class PatoSprite : SpriteBase
    {
        public PatoSprite(Game game, string texturePath, Vector3 position, Vector3 rotation, Vector3 scale) : base(game, texturePath, position, rotation, scale)
        {

        }


    }
}
