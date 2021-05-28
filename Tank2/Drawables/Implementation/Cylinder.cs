using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Net.Http.Headers;
using OpenTK;

namespace Tank2.Drawables.Implementation
{
    public class Cylinder : BaseDrawableGl
    {
        public float Radius { get; private set; }
        public int AnglesNumber { get; private set; }

        public Cylinder(Vector3 color, float radius, int anglesNumber) : base(color)
        {
            Radius = radius;
            AnglesNumber = anglesNumber;
            CreateVertexes(radius, anglesNumber);
            Translate(new Vector3(0, 2, 0));
            Scale(new Vector3(0.5f, 1f, 0.5f));
            Rotate(new Vector3(90f, 0f, 0f));
        }

        private void CreateVertexes(float radius, int anglesCount)
        {
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
                Normals.Add(localPoint.Normalized());
                vertexInfos.Add(new VertexInfo(Vertexes.Count, Normals.Count));
                vertexInfos.Add(new VertexInfo(Vertexes.Count - 1, Normals.Count));
                PolygonsIndexes.Add(vertexInfos);
                previousPoint = localPoint;
            }

            var vertexInfo = new List<VertexInfo>
            {
                new VertexInfo(1, 1),
                new VertexInfo(2, 1),
                new VertexInfo(Vertexes.Count, Normals.Count),
                new VertexInfo(Vertexes.Count - 1, Normals.Count)
            };
            PolygonsIndexes.Add(vertexInfo);

            AddPlugs();
        }

        private void AddPlugs()
        {
            Normals.Add(Vector3.UnitY);
            Normals.Add(-Vector3.UnitY);
            var upPlug = new List<VertexInfo>();
            var downPlug = new List<VertexInfo>();
            for (int i = 0; i < Vertexes.Count; i++)
            {
                if (i % 2 == 0)
                {
                    upPlug.Add(new VertexInfo(i + 1, Normals.Count - 1));
                }
                else
                {
                    downPlug.Add(new VertexInfo(i + 1, Normals.Count));
                }
            }

            PolygonsIndexes.Add(upPlug);
            PolygonsIndexes.Add(downPlug);
        }

        public override List<Vector3> Vertexes { get; protected set; } = new List<Vector3>();
        public override List<Vector3> Normals { get; protected set; } = new List<Vector3>();
        public override List<List<VertexInfo>> PolygonsIndexes { get; protected set; } = new List<List<VertexInfo>>();
    }
}