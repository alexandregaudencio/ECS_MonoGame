using System.Collections.Generic;

namespace ECS.Core.Entities
{

    //Generic composite Pattern
    public interface IComposite<T> where T : class
    {
        public List<T> Childs { get; set; }
        //public void AddChild(T obj);
        public void AddChild(params T[] objs);
        public void AddChild(IEnumerable<T> objs);
        public void RemoveChild(int indexOf);

    }
}
