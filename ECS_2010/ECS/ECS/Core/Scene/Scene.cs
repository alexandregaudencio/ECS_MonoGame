using Microsoft.Xna.Framework;

namespace ECS.Core.Scene
{
    public abstract class Scene : DrawableGameComponent, IScene
    {
        public string Name { get; private set; }

        public Scene(Game game, string name) : base(game) 
        { 
            Name = name;

            //TODO: we really need auto register Scenes or register manually to control the order?
            SceneManager.Instance.RegisterScene(this);

        }






    }
}
