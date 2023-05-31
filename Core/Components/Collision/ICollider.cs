using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Core.Components.Collision
{
    public interface ICollider
    {

        bool IsColliding { get; }
        public BoundingBox BoundingBox { get; set; }

        virtual void  OnCollisionEnter(ICollider other) { }
        virtual void OnCollisionExit(ICollider other) { }
        virtual void OnCollisionStay(ICollider other) { }

    }
}
