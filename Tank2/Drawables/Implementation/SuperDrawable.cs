using System.Collections.Generic;
using System.Linq;
using OpenTK;

namespace Tank2.Drawables.Implementation
{
    public class SuperDrawable : BaseDrawableGl
    {
        public SuperDrawable(Vector3 color, List<BaseDrawableGl> drawableGls) : base(color)
        {
            var shiftVertexes = 0;
            var shiftNormals = 0;
            foreach (var baseDrawableGl in drawableGls)
            {
                Vertexes.AddRange(baseDrawableGl.Vertexes.Select(x => baseDrawableGl.TransformVertex(x).Xyz));
                Normals.AddRange(baseDrawableGl.Normals.Select(x => baseDrawableGl.TransformNormal(x).Xyz));
                PolygonsIndexes.AddRange(baseDrawableGl.PolygonsIndexes.Select(list =>
                    list.Select(info =>
                            new VertexInfo(info.VertexIndex + shiftVertexes, info.NormalIndex + shiftNormals))
                        .ToList()));
                shiftVertexes = Vertexes.Count;
                shiftNormals = Normals.Count;
            }
        }

        public override List<Vector3> Vertexes { get; protected set; } = new List<Vector3>();
        public override List<Vector3> Normals { get; protected set; } = new List<Vector3>();
        public override List<List<VertexInfo>> PolygonsIndexes { get; protected set; } = new List<List<VertexInfo>>();
    }
}