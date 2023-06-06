using System;

namespace ECS.Core.Components.Renderers
{
    public interface IPrimitiveBuffer
    {
        void SetVertexTextureData();
        void SetVertexBuffer();
        void SetIndexData();
        void SetIndexBuffer();



    }
}
