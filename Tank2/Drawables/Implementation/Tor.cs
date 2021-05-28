using System.Collections.Generic;
using System.Linq;
using OpenTK;

namespace Tank2.Drawables.Implementation
{
    public class Tor: BaseDrawableGl
    {
        private float _radius;
        private float _smallRadius;
        private int _countSides;

        public Tor(Vector3 color, float radius, float smallRadius, int countSides) : base(color)
        {
            _radius = radius;
            _smallRadius = smallRadius;
            _countSides = countSides;
            GenerateVertexes();
        }

        private void GenerateVertexes()
        {
            var direction = new Vector3(_radius, 0, 0);
            var circle = CreateCircle(_smallRadius);
            var rotateAngle = 360 / _countSides;
            var normalsPrev = circle.Select(x => x.Normalized()).ToList();
            List<VertexInfo> preVertexesInfo = new List<VertexInfo>();
            var firstVertexesInfo = preVertexesInfo;
            for (int i = 0; i < normalsPrev.Count; i++)
            {
                Vertexes.Add(circle[i] + direction);
                Normals.Add(normalsPrev[i]);
                preVertexesInfo.Add(new VertexInfo(Vertexes.Count, Normals.Count));
            }
            
            for (int i = 1; i < _countSides; i++)
            {
                var rotationY = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(rotateAngle * i));
                var newDirection = (new Vector4(direction) * rotationY).Xyz;
                var newVer = circle
                    .Select(x => (new Vector4(x) * rotationY).Xyz)
                    .ToList();
                var normals = newVer.Select(x => x.Normalized()).ToList();
                var newVertexesInfo = new List<VertexInfo>();
                for (int j = 0; j < normals.Count; j++)
                {
                    Vertexes.Add(newVer[j] + newDirection);
                    Normals.Add(normals[j]);
                    newVertexesInfo.Add(new VertexInfo(Vertexes.Count, Normals.Count));
                }

                for (int j = 0; j < newVertexesInfo.Count - 1; j++)
                {
                    PolygonsIndexes.Add(new List<VertexInfo>()
                    {  
                        preVertexesInfo[j],
                        preVertexesInfo[j + 1],
                        newVertexesInfo[j + 1],
                        newVertexesInfo[j]
                    });
                }
                
                PolygonsIndexes.Add(new List<VertexInfo>()
                {  
                    preVertexesInfo[0],
                    preVertexesInfo[preVertexesInfo.Count - 1],
                    newVertexesInfo[newVertexesInfo.Count - 1],
                    newVertexesInfo[0]
                });
                preVertexesInfo = newVertexesInfo;
            }
            
            for (int j = 0; j < preVertexesInfo.Count - 1; j++)
            {
                PolygonsIndexes.Add(new List<VertexInfo>()
                {  
                    preVertexesInfo[j],
                    preVertexesInfo[j + 1],
                    firstVertexesInfo[j + 1],
                    firstVertexesInfo[j]
                });
            }
                
            PolygonsIndexes.Add(new List<VertexInfo>()
            {  
                preVertexesInfo[0],
                preVertexesInfo[preVertexesInfo.Count - 1],
                firstVertexesInfo[firstVertexesInfo.Count - 1],
                firstVertexesInfo[0]
            });
        }

        private List<Vector3> CreateCircle(float smallRadius)
        {
            var vetexes = new List<Vector3>();
            var startPoint = new Vector3(0, 0, smallRadius);
            var rotateAngle = 360 / _countSides;
            for (int i = 0; i < _countSides; i++)
            {
                var newPoint = new Vector4(startPoint) *
                               Matrix4.CreateRotationY(MathHelper.DegreesToRadians(rotateAngle * i));
                vetexes.Add(newPoint.Xyz);
            }

            return vetexes;
        }

        public override List<Vector3> Vertexes { get; protected set; } = new List<Vector3>();
        public override List<Vector3> Normals { get; protected set; } = new List<Vector3>();
        public override List<List<VertexInfo>> PolygonsIndexes { get; protected set; } = new List<List<VertexInfo>>();
    }
}