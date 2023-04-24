using ECS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Core.Entities
{
    public interface IComposite<T> where T : class
    {
        public List<T> Childs { get; set; }
        //public void AddChild(T obj);
        public void AddChild(params T[] objs);
        public void AddChild(IEnumerable<T> objs);
        public void RemoveChild(int indexOf);

    }
}
