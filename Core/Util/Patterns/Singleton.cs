//using Microsoft.Xna.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ECS.Core.Util.Patterns
//{
//    public class Singleton<T> : GameComponent where T : class
//    {
//        private static Singleton<T> instance;
//        private static readonly object lockObject = new object();


//        public Singleton(Game game) : base(game)
//        {
//            this.game = game;
//        }


//        public  Singleton<T> Instance
//        {
//            get
//            {
//                if (instance == null)
//                {
//                    lock (lockObject)
//                    {
//                        if (instance == null)
//                        {
//                            instance = new Singleton<T>(Game);
//                        }
//                    }
//                }
//                return instance;
//            }
//        }
//    }

//    // Other methods and properties of the singleton class


//}
