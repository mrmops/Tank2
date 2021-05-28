using System.Collections.Generic;
using OpenTK;

namespace Tank2.Drawables.Implementation
{
    public class QPlane : BaseDrawableGl
    {
        public QPlane(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, bool upNormal, Vector3 color) : base(color)
        {
            Vertexes = new List<Vector3>()
            {
                new Vector3(p1), new Vector3(p2), new Vector3(p3), new Vector3(p4)
            };
            Normals = new List<Vector3>() {new Vector3(0f, upNormal ? 1f : 0f, 0f)};
            PolygonsIndexes = new List<List<VertexInfo>>()
            {
                new List<VertexInfo>()
                {
                    new VertexInfo(1, 1),
                    new VertexInfo(2, 1),
                    new VertexInfo(3, 1),
                    new VertexInfo(4, 1)
                }
            };
        }

        public override List<Vector3> Vertexes { get; protected set; }
        public override List<Vector3> Normals { get; protected set; }
        public override List<List<VertexInfo>> PolygonsIndexes { get; protected set; }
    }
}