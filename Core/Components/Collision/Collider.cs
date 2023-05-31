using ECS.Core.Components.Cam;
using ECS.Core.Entities;
using ECS.Core.Object;
using ECS.Core.Primitives;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace ECS.Core.Components.Collision
{
    public class Collider : Entity, ICollider
    {
        private readonly Cuboid wireframe;
        public BoundingBox BoundingBox { get; set; }
        
        private bool isColliding;
        public bool IsColliding => isColliding;

        private readonly GameObject gameObject;
        public GameObject GameObject => gameObject;

        public Collider(Game game, ICameraPerspective iCameraPerspective, GameObject gameObject, bool isVisible = true) : base(game)
        {
            this.gameObject = gameObject;
            this.wireframe = new Cuboid(game, iCameraPerspective, Color.Green);
            
            wireframe = new Cuboid(game, iCameraPerspective, Color.Green);
            SetVisible(isVisible);
            UpdateBoundingBox();
        }


        public override void Initialize()
        {

            AddChild(wireframe);
            Game.Components.Add(wireframe);
            
            wireframe.SetPrimitiveType(PrimitiveType.LineList);
            CollisionManager.Instance.AddColliders(this);

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {

            //wireCollider.SetTransform(gameObject.Transform);
            
            UpdateBoundingBox();
            //Debug.WriteLine(guid.ToString() + Transform.Translation + Transform.Scale);
            //Debug.WriteLine(guid.ToString() + BoundingBox.Min);
            //Debug.WriteLine(guid.ToString() + BoundingBox.Max);

            base.Update(gameTime);
        }

        private void UpdateBoundingBox()
        {
            BoundingBox = new BoundingBox(
                GameObject.Transform.Translation - GameObject.Transform.Scale,
                GameObject.Transform.Translation + GameObject.Transform.Scale);
        }


        public bool Intersects(BoundingBox box) => BoundingBox.Intersects(box);

        public void SetVisible(bool value)
        {
            wireframe.Visible  = value;
        }

        public void SetColor(Color color)
        {
            wireframe.SetColor(color);
        }


        public  void OnCollisionEnter(ICollider other)
        {
            isColliding = true;

            Debug.WriteLine(guid+ " On collision Enter");
            wireframe.SetColor(Color.Red);
        }

        public  void OnCollisionExit(ICollider other)
        {

            isColliding = false;
            wireframe.SetColor(Color.Green);

            Debug.WriteLine(" On collision exit");

        }

        public  void OnCollisionStay(ICollider other)
        {
            //Debug.WriteLine(other.GameObject.GetTypeInfo());

            Debug.WriteLine(" On collision STAY");

        }
    }
}
