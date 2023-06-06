using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Core
{
    public interface IActivable
    {
        bool Active { get; }
        void SetActive(bool active);
    }
}
