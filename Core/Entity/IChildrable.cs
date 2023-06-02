//using ECS.Core.Components;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ECS.Core.Entity
//{
//    internal interface IChildrable<T, Core.Entities.Entity> where T : class 
//    {
//        public T parent { get; set; }
//        public void PassToChilds(IEnumerable<Entity> values)
//        {
//            if (values.Count() == 0) return;
//            foreach (ECS.Core.Entities.Entity Entity value in values)
//            {
//                value.Transform.SetParent(parent);
//            }
//        }




//    }
//}//using ECS.Core.Components;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ECS.Core.Entities
//{
//    internal interface IChildrable<T, Core.Entities.Entity> where T : class 
//    {
//        public T parent { get; set; }
//        public void PassToChilds(IEnumerable<Entity> values)
//        {
//            if (values.Count() == 0) return;
//            foreach (ECS.Core.Entities.Entity Entity value in values)
//            {
//                value.Transform.SetParent(parent);
//            }
//        }




//    }
//}
