using ECS.Core.Components.Cam;
using ECS.Core.Components.Collision;
using ECS.Core.Components.Renderer;
using ECS.Core.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Core.Object
{
    public abstract class GameObject : Entity
    {
        public ModelRenderer ModelRenderer { get;private set; }
        public Collider Collider { get; private set; }
        
        
        public GameObject(Game game, ICameraPerspective cameraPerspective, string modelPath = "" ) : base(game)
        {
            ModelRenderer = new ModelRenderer(game, cameraPerspective, Transform, modelPath);
            Collider = new Collider(game, cameraPerspective, this);

            Collider.CollisionStay += OnCollisionStay;
        }


        public override void Initialize()
        {
            AddChild(Collider);
            AddChild(ModelRenderer);

            Game.Components.Add(ModelRenderer);
            Game.Components.Add(Collider);

            base.Initialize();
        }


        public void SetObjectOnFloorY()
        {
            Transform.Translate(Vector3.UnitY * Transform.Scale.Y);

        }

        public virtual void OnCollisionStay(object sender, ICollider other)
        {
            Debug.WriteLine("on collision do gameobject");
        }


    }
}
