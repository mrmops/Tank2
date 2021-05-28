using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Tank2
{
    public abstract class BaseDrawableGl : IDrawableGl
    {
        public Matrix4 _rotate = Matrix4.Identity;
        private Vector3 _color;

        protected BaseDrawableGl(Vector3 color)
        {
            _color = color;
        }


        public void DrawPolygons(Matrix4 worldTransform)
        {
            foreach (var polygonIndexes in PolygonsIndexes)
            {
                GL.Material(MaterialFace.Front, MaterialParameter.Diffuse, new Vector4(_color));
                GL.Color3(_color);
                GL.Begin(PrimitiveType.Polygon);
                foreach (var indexInfo in polygonIndexes)
                {
                    OnVertexSet(indexInfo);
                    if (indexInfo.NormalIndex < 1 || indexInfo.NormalIndex > Normals.Count)
                        throw new Exception();
                    var normal = Normals[indexInfo.NormalIndex - 1];
                    var normalTransform = (TransformNormal(normal) * worldTransform).Xyz;
                    GL.Normal3(normalTransform);
                    var vertex = Vertexes[indexInfo.VertexIndex - 1];
                    var vector3 = (TransformVertex(vertex) * worldTransform).Xyz;
                    GL.Vertex3(vector3);
                }

                GL.End();
                //DrawLines(polygonIndexes, worldTransform);
            }
        }

        protected virtual void OnVertexSet(VertexInfo vertexInfo)
        {
        }

        private void DrawLines(List<VertexInfo> polygonIndexes, Matrix4 worldTransform)
        {
            //GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Diffuse, new Vector4(0, 0, 0, 1));
            GL.Color4(new Vector4(0, 0, 0, 1));
            GL.Disable(EnableCap.Lighting);
            GL.LineWidth(2);
            GL.Begin(PrimitiveType.Lines);
            for (var i = 0; i < polygonIndexes.Count; i++)
            {
                var vertexInfo = polygonIndexes[i];
                var vertex = Vertexes[vertexInfo.VertexIndex - 1];
                var vector3 = (TransformVertex(vertex) * worldTransform).Xyz;
                GL.Vertex3(vector3);

                /*for (int j = i + 1; j < polygonIndexes.Count; j++)
                {
                    var vertexInfo2 = polygonIndexes[j];
                    var vertex2 = Vertexes[vertexInfo2.VertexIndex - 1];
                    var vector32 = (TransformVertex(vertex2) * worldTransform).Xyz;
                    GL.Vertex3(vector32);
                }*/
            }

            var vertexFirst = Vertexes[polygonIndexes[0].VertexIndex - 1];
            var vectorFirst = (TransformVertex(vertexFirst) *
                               worldTransform).Xyz;
            GL.Vertex3(vectorFirst);

            var vertexLast = Vertexes[polygonIndexes[polygonIndexes.Count - 1].VertexIndex - 1];
            var vectorLast = (TransformVertex(vertexLast) *
                              worldTransform).Xyz;
            GL.Vertex3(vectorLast);

            GL.End();
            GL.Enable(EnableCap.Lighting);
        }

        public Vector4 TransformVertex(Vector3 vertex2) => new Vector4(vertex2, 1f) * _scale * localTransform *
                                                           _rotate * _translate;
        
        public Vector4 TransformNormal(Vector3 normal) => new Vector4(normal, 1f) * _rotate;


        public Matrix4 _translate = Matrix4.Identity;
        public Matrix4 _scale = Matrix4.Identity;
        public Matrix4 localTransform = Matrix4.Identity;

        public void Translate(Vector3 translate) => _translate *= Matrix4.CreateTranslation(translate);

        public void Scale(Vector3 scale) => _scale *= Matrix4.CreateScale(scale);

        public void Rotate(Vector3 rotation) => _rotate *=
            Matrix4.CreateRotationX(MathHelper.DegreesToRadians(rotation.X))
            * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(rotation.Y))
            * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(rotation.Z));

        public abstract List<Vector3> Vertexes { get; protected set; }
        public abstract List<Vector3> Normals { get; protected set; }
        public abstract List<List<VertexInfo>> PolygonsIndexes { get; protected set; }
    }
}