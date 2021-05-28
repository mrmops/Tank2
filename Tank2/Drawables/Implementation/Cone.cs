using System.Collections.Generic;
using System.Drawing.Drawing2D;
using OpenTK;

namespace Tank2.Drawables.Implementation
{
    public class Cone : BaseDrawableGl
    {
        private float _radius;
        private float _height;
        private int _countSides;

        public Cone(Vector3 color, float radius, float height, int countSides) : base(color)
        {
            _radius = radius;
            _height = height;
            _countSides = countSides;
            GenerateVertexes();
        }

        private void GenerateVertexes()
        {
            var startPoint = new Vector3(_radius, 0, 0);
            var rotateAngle = 360f / _countSides;
            var plug = new List<VertexInfo>();
            Normals.Add(new Vector3(0, 0, -1));
            var vertexInfos = new List<VertexInfo>();
            for (int i = 0; i < _countSides; i++)
            {
                var newPoint = new Vector4(startPoint) *
                               Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(rotateAngle * i));
                var newPointXyz = newPoint.Xyz;
                Vertexes.Add(newPointXyz);
                Normals.Add(newPointXyz.Normalized());
                plug.Add(new VertexInfo(Vertexes.Count, Normals.Count));
                vertexInfos.Add(new VertexInfo(Vertexes.Count, Normals.Count));
            }

            PolygonsIndexes.Add(plug);

            var vector3 = new Vector3(0, 0, _height);
            Vertexes.Add(vector3);
            Normals.Add(vector3.Normalized());
            var vertexInfo = new VertexInfo(Vertexes.Count, Normals.Count);

            for (int i = 0; i < vertexInfos.Count - 1; i++)
            {
                PolygonsIndexes.Add(new List<VertexInfo>()
                {
                    vertexInfos[i],
                    vertexInfos[i + 1],
                    vertexInfo
                });
            }

            PolygonsIndexes.Add(new List<VertexInfo>()
            {
                vertexInfos[0],
                vertexInfos[vertexInfos.Count - 1],
                vertexInfo
            });
        }

        public override List<Vector3> Vertexes { get; protected set; } = new List<Vector3>();
        public override List<Vector3> Normals { get; protected set; } = new List<Vector3>();
        public override List<List<VertexInfo>> PolygonsIndexes { get; protected set; } = new List<List<VertexInfo>>();
    }
}