using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECS.Core.Entities;
using Microsoft.Xna.Framework;
using ECS.Core.Components.Cam;

namespace ECS._Game.GameObjects
{
    public class Forest : Entity
    {
        List<Tree> trees = new List<Tree>();
        Random random = new Random();
        Camera camera;
        Vector2 noise { get { return new Vector2(random.Next(-gap / 3, gap / 3), random.Next(-gap / 3, gap / 3)); } }
        static int gap = 6;

        public Forest(Game game, Camera camera, int TreeCount)
            : base(game)
        {

            this.camera = camera;

            Transform.Translate(new Vector3(-30, 0, -70));

            GenerateTrees(TreeCount);

        }

        public override void Initialize()
        {

            foreach (Tree tree in trees)
            {
                AddChild(tree);
                Game.Components.Add(tree);
            }

            base.Initialize();
        }

        public void GenerateTrees(int count)
        {
            int lines = (int)Math.Ceiling(Math.Sqrt(count));

            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < lines; j++)
                {

                    //Vector2 noise = new Vector2(random.Next(-gap/2, gap/2), random.Next(-gap/2, gap/2));
                    Tree tree = new Tree(Game, camera);

                    tree.Transform.Translate(new Vector3(i * gap + noise.X, 0, j * gap + noise.Y));
                    trees.Add(tree);

                }

            }
        }








    }

}
