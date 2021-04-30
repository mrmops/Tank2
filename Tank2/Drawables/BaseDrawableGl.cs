using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Tank2
{
    public abstract class BaseDrawableGl : IDrawableGl
    {
        private Matrix4 _localTransform = Matrix4.Identity;
        private Vector3 _color;

        protected BaseDrawableGl(Vector3 color)
        {
            _color = color;
        }


        public void DrawPolygons()
        {
            GL.Color3(_color);
            foreach (var polygonIndexes in PolygonsIndexes)
            {
                GL.Begin(PrimitiveType.Polygon);
                foreach (var indexInfo in polygonIndexes)
                {
                    if (indexInfo.NormalIndex < 1 || indexInfo.NormalIndex > Normals.Count)
                        throw new Exception();
                    GL.Normal3(Normals[indexInfo.NormalIndex - 1]);
                    GL.Vertex3(Vertexes[indexInfo.VertexIndex - 1] * 0.5f);
                }
            
                GL.End();
            }
        }

        protected abstract List<Vector3> Vertexes { get; set; }
        protected abstract List<Vector3> Normals { get; set; }
        protected abstract List<List<VertexInfo>> PolygonsIndexes { get; set; }
    }
}