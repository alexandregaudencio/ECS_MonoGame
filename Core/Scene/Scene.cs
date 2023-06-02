using Microsoft.Xna.Framework;

namespace ECS.Core.Scene
{
    public abstract class Scene : DrawableGameComponent, IScene
    {
        public string Name { get; private set; }

        public Scene(Game game, string name) : base(game) 
        { 
            Name = name;

            SceneManager.Instance.RegisterScene(this);

        }

        public override void Initialize()
        {
            base.Initialize();
        }






    }
}
