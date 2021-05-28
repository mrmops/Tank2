using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using OpenTK;

namespace Tank2.Drawables.Implementation
{
    public class Ring : BaseDrawableGl
    {
        public override List<Vector3> Vertexes { get; protected set; } = new List<Vector3>();
        public override List<Vector3> Normals { get; protected set; } = new List<Vector3>();
        public override List<List<VertexInfo>> PolygonsIndexes { get; protected set; } = new List<List<VertexInfo>>();
        public float InnerRadius { get; private set; }
        
        public float OuterRadius { get; private set; }
        public int AnglesNumber { get; private set; }

        public Ring(Vector3 color, float innerRadius, float outerRadius, int anglesNumber) : base(color)
        {
            InnerRadius = innerRadius;
            OuterRadius = outerRadius;
            AnglesNumber = anglesNumber;
            CreateVertexes(innerRadius, anglesNumber, true);
            CreateVertexes(outerRadius, anglesNumber, false);
            AddPlugs();
            Translate(new Vector3(0, 2, 0));
            Scale(new Vector3(0.5f, 1f, 0.5f));
            Rotate(new Vector3(90f, 0f, 0f));
        }

        private void AddPlugs()
        {
            Normals.Add(Vector3.UnitY);
            Normals.Add(-Vector3.UnitY);
            var halfVertexesCount = Vertexes.Count / 2;
            for (int i = 0; i < halfVertexesCount - 2; i++)
            {
                var isUp = i % 2 == 0;
                var normalIndex = isUp ? Normals.Count - 1 : Normals.Count;
                var polygon = new List<VertexInfo>()
                {
                    new VertexInfo(i + 1, normalIndex),
                    new VertexInfo(i + 3, normalIndex),
                    new VertexInfo(i + 3 + halfVertexesCount, normalIndex),
                    new VertexInfo(i + 1 + halfVertexesCount, normalIndex),
                };
                PolygonsIndexes.Add(polygon);
            }
            
            var normalIndexUp = Normals.Count - 1;
            PolygonsIndexes.Add(new List<VertexInfo>()
            {
                new VertexInfo(halfVertexesCount - 1, normalIndexUp),
                new VertexInfo(1, normalIndexUp),
                new VertexInfo(halfVertexesCount + 1, normalIndexUp),
                new VertexInfo(Vertexes.Count - 1, normalIndexUp),
            });
            
            var normalIndexDown = Normals.Count;
            PolygonsIndexes.Add(new List<VertexInfo>()
            {
                new VertexInfo(halfVertexesCount, normalIndexDown),
                new VertexInfo(2, normalIndexDown),
                new VertexInfo(halfVertexesCount + 2, normalIndexDown),
                new VertexInfo(Vertexes.Count, normalIndexDown),
            });
        }

        private void CreateVertexes(float radius, int anglesCount, bool invertNormal)
        {
            var startIndex = Vertexes.Count;
            var angel = (float) (2 * Math.PI / anglesCount);
            var rotationMatrix = Matrix4.CreateRotationY(angel);
            var startPoint = new Vector3(radius, 0f, 0f);
            var previousPoint = startPoint;

            Vertexes.Add(new Vector3(startPoint.X, 1 / 2f, startPoint.Z));
            Vertexes.Add(new Vector3(startPoint.X, 1 / -2f, startPoint.Z));
            Normals.Add(startPoint.Normalized());

            for (var i = 1; i < anglesCount; i++)
            {
                var vertexInfos = new List<VertexInfo>
                {
                    new VertexInfo(Vertexes.Count - 1, Normals.Count), new VertexInfo(Vertexes.Count, Normals.Count)
                };
                var localPoint = (new Vector4(previousPoint, 1) * rotationMatrix).Xyz;
                var upLocalFirst = new Vector3(localPoint.X, 1 / 2f, localPoint.Z);
                Vertexes.Add(upLocalFirst);
                var downLocalFirst = new Vector3(localPoint.X, 1 / -2f, localPoint.Z);
                Vertexes.Add(downLocalFirst);
                Normals.Add(invertNormal ? localPoint.Normalized() * -1 : localPoint.Normalized());
                vertexInfos.Add(new VertexInfo(Vertexes.Count, Normals.Count));
                vertexInfos.Add(new VertexInfo(Vertexes.Count - 1, Normals.Count));
                PolygonsIndexes.Add(vertexInfos);
                previousPoint = localPoint;
            }

            var vertexInfo = new List<VertexInfo>
            {
                new VertexInfo(startIndex + 1, 1),
                new VertexInfo(startIndex + 2, 1),
                new VertexInfo(Vertexes.Count, Normals.Count),
                new VertexInfo(Vertexes.Count - 1, Normals.Count)
            };
            PolygonsIndexes.Add(vertexInfo);
        }
    }
}