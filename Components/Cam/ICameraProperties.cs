using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Components.Cam
{
    public interface ICameraProperties
    {
        Matrix World { get; }
        Matrix View { get;  }
        Matrix Projection { get; }

    }
}
