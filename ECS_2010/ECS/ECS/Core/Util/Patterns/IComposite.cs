using System.Collections.Generic;

namespace ECS.Core.Util.Patterns
{

    //Generic composite Pattern
    public interface IComposite<T> where T : class
    {
        List<T> Childs { get; set; }
        void AddChild(params T[] objs);
        void AddChild(IEnumerable<T> objs);
        void RemoveChild(int indexOf);

    }
}
