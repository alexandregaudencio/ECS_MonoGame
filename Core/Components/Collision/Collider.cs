using ECS.Core.Components.Cam;
using ECS.Core.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace ECS.Core.Components.Collision
{
    public class Collider : Entity
    {
        //private Transform Transform;
        LineBox lineBox;
        public BoundingBox BoundingBox { get; private set; }
        public bool Intersects(BoundingBox box) => BoundingBox.Intersects(box);
        public bool isColliding = false;
        public bool movivel = true;
        public Collider(Game game, ICameraPerspective iCameraPerspective, bool movivel) : base(game)
        {
            //this.iCameraPerspective = iCameraPerspective;
            //this.transform = transform;
            this.lineBox = new LineBox(game, iCameraPerspective, Transform);

            UpdateBoundingBox();
            this.movivel = movivel;
        }

        public override void Initialize()
        {
            Game.Components.Add(lineBox);
            base.Initialize();
        }

        private void UpdateBoundingBox()
        {
            BoundingBox = new BoundingBox(
                Transform.Translation - Transform.Scale,
                Transform.Translation + Transform.Scale);
        }


        public override void Update(GameTime gameTime)
        {
            lineBox.SetTransform(Transform);
            UpdateBoundingBox();
            ProcessInputCommands();

            //Debug.WriteLine(string.Concat(BoundingBox.Min.Z,BoundingBox.Max.Z));

            base.Update(gameTime);

        }


        public void SetVisible(bool value)
        {
            lineBox.Visible  = value;
        }


        private void ProcessInputCommands()
        {
            if (!movivel) return;

            float speed = 0.05f;
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                Transform.RotateY(-0.01f);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                Transform.RotateY(0.01f);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Transform.Translate(-Vector3.UnitX*speed);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                this.Transform.Translate(Vector3.UnitX * speed);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                this.Transform.Translate(Vector3.UnitZ * speed);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                this.Transform.Translate(-Vector3.UnitZ * speed);
            }


        }




    }
}
