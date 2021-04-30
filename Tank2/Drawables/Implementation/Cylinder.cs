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
        public float Width { get; private set; }
        public int AnglesNumber { get; private set; }

        public Cylinder(Vector3 color, float radius, float width, int anglesNumber) : base(color)
        {
            Radius = radius;
            Width = width;
            AnglesNumber = anglesNumber;
            CreateVertexes(radius, width, anglesNumber);
        }

        private void CreateVertexes(float radius, float width, int anglesCount)
        {
            var angel = (float) (2 * Math.PI / anglesCount);
            var rotationMatrix = Matrix4.CreateRotationY(angel);
            var startPoint = new Vector3(radius, 0f, 0f);
            var previousPoint = startPoint;

            Vertexes.Add(new Vector3(startPoint.X, width / 2f, startPoint.Z));
            Vertexes.Add(new Vector3(startPoint.X, width / -2f, startPoint.Z));
            Normals.Add(startPoint.Normalized());

            for (int i = 1; i < anglesCount; i++)
            {
                var vertexInfos = new List<VertexInfo>();
                vertexInfos.Add(new VertexInfo(Vertexes.Count - 1, Normals.Count));
                vertexInfos.Add(new VertexInfo(Vertexes.Count, Normals.Count));
                var localPoint = (new Vector4(previousPoint, 1) * rotationMatrix).Xyz;
                var upLocalFirst = new Vector3(localPoint.X, width / 2f, localPoint.Z);
                Vertexes.Add(upLocalFirst);
                var downLocalFirst = new Vector3(localPoint.X, width / -2f, localPoint.Z);
                Vertexes.Add(downLocalFirst);
                Normals.Add(localPoint.Normalized());
                vertexInfos.Add(new VertexInfo(Vertexes.Count, Normals.Count));
                vertexInfos.Add(new VertexInfo(Vertexes.Count - 1, Normals.Count));
                PolygonsIndexes.Add(vertexInfos);
                previousPoint = localPoint;
            }

            var vertexInfo = new List<VertexInfo>();
            vertexInfo.Add(new VertexInfo(1, 1));
            vertexInfo.Add(new VertexInfo(2, 1));
            vertexInfo.Add(new VertexInfo(Vertexes.Count, Normals.Count));
            vertexInfo.Add(new VertexInfo(Vertexes.Count - 1, Normals.Count));
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

        protected override List<Vector3> Vertexes { get; set; } = new List<Vector3>();
        protected override List<Vector3> Normals { get; set; } = new List<Vector3>();
        protected override List<List<VertexInfo>> PolygonsIndexes { get; set; } = new List<List<VertexInfo>>();
    }
}