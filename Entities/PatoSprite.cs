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
        public PatoSprite(Game game, string texturePath, Vector2 position, float rotation, float scale) : base(game, texturePath, position, rotation, scale)
        {

        }


    }
}
