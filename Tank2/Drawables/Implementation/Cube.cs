using System.Collections.Generic;
using OpenTK;

namespace Tank2.Drawables.Implementation
{
    public class Cube : BaseDrawableGl
    {
        public Cube(Vector3 color) : base(color)
        {
            GenerateVertexes();
        }

        private void GenerateVertexes()
        {
            for (int x = -1; x <= 1; x += 2)
            {
                for (int y = -1; y <= 1; y += 2)
                {
                    for (int z = -1; z <= 1; z += 2)
                    {
                        Vertexes.Add(new Vector3(x, y, z));
                    }
                }
            }
        }


        protected override List<Vector3> Vertexes { get; set; } = new List<Vector3>();

        protected override List<Vector3> Normals { get; set; } = new List<Vector3>()
        {
            new Vector3(0f, 0f, -1f),
            new Vector3(-1f, 0f, 0f),
            new Vector3(0f, 0f, 1f),
            new Vector3(1f, 0f, 0f),
            new Vector3(0f, -1f, 0f),
            new Vector3(0f, 1f, 0f),
        };

        protected override List<List<VertexInfo>> PolygonsIndexes { get; set; } = new List<List<VertexInfo>>()
        {
            new List<VertexInfo>()
            {
                new VertexInfo(1, 2),
                new VertexInfo(3, 2),
                new VertexInfo(4, 2),
                new VertexInfo(2, 2)
            },
            new List<VertexInfo>()
            {
                new VertexInfo(1, 1),
                new VertexInfo(3, 1),
                new VertexInfo(7, 1),
                new VertexInfo(5, 1)
            },
            new List<VertexInfo>()
            {
                new VertexInfo(5, 4),
                new VertexInfo(7, 4),
                new VertexInfo(8, 4),
                new VertexInfo(6, 4)
            },
            new List<VertexInfo>()
            {
                new VertexInfo(6, 3),
                new VertexInfo(2, 3),
                new VertexInfo(4, 3),
                new VertexInfo(8, 3)
            },
            new List<VertexInfo>()
            {
                new VertexInfo(1, 5),
                new VertexInfo(2, 5),
                new VertexInfo(6, 5),
                new VertexInfo(5, 5)
            },
            new List<VertexInfo>()
            {
                new VertexInfo(3, 6),
                new VertexInfo(4, 6),
                new VertexInfo(8, 6),
                new VertexInfo(7, 6)
            },
        };
    }
}