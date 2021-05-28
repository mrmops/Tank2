using System.Collections.Generic;
using OpenTK;

namespace Tank2.Drawables.Implementation
{
    public class Custom: BaseDrawableGl
    {
        public Custom(List<Vector3> vertexes, List<Vector3> normals, List<List<VertexInfo>> polygonsIndexes, 
            Vector3 color) : base(color)
        {
            Vertexes = vertexes;
            Normals = normals;
            PolygonsIndexes = polygonsIndexes;
        }

        public override List<Vector3> Vertexes { get; protected set; }
        public override List<Vector3> Normals { get; protected set; }
        public override List<List<VertexInfo>> PolygonsIndexes { get; protected set; }
    }
}