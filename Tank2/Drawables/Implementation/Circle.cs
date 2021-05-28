using System.Collections.Generic;
using OpenTK;

namespace Tank2.Drawables.Implementation
{
    public class Circle: BaseDrawableGl
    {
        private float _radius;
        private int _countSides;

        public Circle(Vector3 color, float radius, int countSides) : base(color)
        {
            _radius = radius;
            _countSides = countSides;
            GenerateVertexes();
        }

        private void GenerateVertexes()
        {
            var startPoint = new Vector3(_radius, 0, 0);
            var rotateAngle = 360 / _countSides;
            var plug = new List<VertexInfo>();
            Normals.Add(new Vector3(0, 0, 1));
            for (int i = 0; i < _countSides; i++)
            {
                var newPoint = new Vector4(startPoint) *
                               Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(rotateAngle * i));
                Vertexes.Add(newPoint.Xyz);
                plug.Add(new VertexInfo(Vertexes.Count, Normals.Count));
            }
            PolygonsIndexes.Add(plug);
        }

        public override List<Vector3> Vertexes { get; protected set; } = new List<Vector3>();
        public override List<Vector3> Normals { get; protected set; } = new List<Vector3>();
        public override List<List<VertexInfo>> PolygonsIndexes { get; protected set; } = new List<List<VertexInfo>>();
    }
}