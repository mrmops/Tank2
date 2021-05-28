using System;
using System.Collections.Generic;
using OpenTK;

namespace Tank2.Drawables
{
    public class Sphere : BaseDrawableGl
    {
        public float Radius { get; private set; }

        public int VerticalSegmentsCount { get; private set; }
        public int HorisontalSegmentsCount { get; private set; }

        public Sphere(Vector3 color, float radius, int verticalSegmentsCount, int horisontalSegmentsCount) : base(color)
        {
            Radius = radius;
            VerticalSegmentsCount = verticalSegmentsCount;
            HorisontalSegmentsCount = horisontalSegmentsCount;
            CreateVertexes();
        }

        private void CreateVertexes()
        {
            var verticalVertexesCount = VerticalSegmentsCount - 1;
            var vertexes = new VertexInfo[HorisontalSegmentsCount, verticalVertexesCount];

            var startPoint = new Vector3(0, Radius, 0);
            Vertexes.Add(startPoint);
            Normals.Add(new Vector3(0, 1, 0));
            var startInfo = new VertexInfo(Vertexes.Count, Normals.Count);
            var vertAngle = (float) (Math.PI / VerticalSegmentsCount);
            var horAngle = (float) (Math.PI * 2 / HorisontalSegmentsCount);
            var rotationZ = Matrix4.CreateRotationZ(vertAngle);
            for (int hor = 0; hor < HorisontalSegmentsCount; hor++)
            {
                var rotationY = Matrix4.CreateRotationY(horAngle * hor);
                var localStart = new Vector4(startPoint, 1f) * rotationZ;
                for (int ver = 0; ver < verticalVertexesCount; ver++)
                {
                    var newPoint = (localStart * Matrix4.CreateRotationZ(vertAngle * ver) * rotationY).Xyz;
                    Vertexes.Add(newPoint);
                    var normal = newPoint.Normalized();
                    Normals.Add(normal);
                    vertexes[hor, ver] = new VertexInfo(Vertexes.Count, Normals.Count);
                }
            }

            var endPoint = new Vector3(0, -Radius, 0);
            Vertexes.Add(endPoint);
            Normals.Add(new Vector3(0, -1, 0));
            var endInfo = new VertexInfo(Vertexes.Count, Normals.Count);

            for (int x = 0; x < HorisontalSegmentsCount; x++)
            {
                var next = x < HorisontalSegmentsCount - 1 ? x + 1 : 0;
                PolygonsIndexes.Add(new List<VertexInfo>() {vertexes[x, 0], vertexes[next, 0], startInfo});
                var lastIndex = verticalVertexesCount - 1;
                PolygonsIndexes.Add(
                    new List<VertexInfo>() {vertexes[x, lastIndex], vertexes[next, lastIndex], endInfo});
                for (int y = 0; y < verticalVertexesCount - 1; y++)
                {
                    PolygonsIndexes.Add(new List<VertexInfo>()
                    {
                        vertexes[x, y], vertexes[x, y + 1],
                        vertexes[next, y + 1], vertexes[next, y]
                    });
                }
            }
        }


        public override List<Vector3> Vertexes { get; protected set; } = new List<Vector3>();
        public override List<Vector3> Normals { get; protected set; } = new List<Vector3>();
        public override List<List<VertexInfo>> PolygonsIndexes { get; protected set; } = new List<List<VertexInfo>>();
    }
}