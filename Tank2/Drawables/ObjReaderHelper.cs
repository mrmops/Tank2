using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using OpenTK;
using Tank2.Drawables.Implementation;

namespace Tank2.Drawables
{
    public class ObjReaderHelper
    {
        public static List<Custom> ReadObj(string filename)
        {
            var objects = new List<Custom>();
            var vertexBuffer = new List<Vector3>();
            var normalsBuffer = new List<Vector3>();
            var vertexInfoBuffer = new List<List<VertexInfo>>();

            foreach (var line in File.ReadLines(filename))
            {
                if (line.Equals("#"))
                    continue;

                if (line.StartsWith("# object") && vertexBuffer.Count != 0)
                {
                    // objects.Add(new Custom(vertexBuffer, normalsBuffer, vertexInfoBuffer, new Vector3(0.5f, 0.5f, 0.5f)));
                    // vertexBuffer = new List<Vector3>();
                    // normalsBuffer = new List<Vector3>();
                    // vertexInfoBuffer = new List<List<VertexInfo>>();
                    continue;
                }


                if (line.StartsWith("v "))
                {
                    var vertexArray = line
                        .ToLower()
                        .Split(" ")
                        .Where(str => str != "v" && !string.IsNullOrEmpty(str))
                        .Select(s => float.Parse(s, CultureInfo.InvariantCulture) / 4)
                        .ToArray();
                    vertexBuffer.Add(new Vector3(vertexArray[0], vertexArray[1], vertexArray[2]));
                }

                if (line.StartsWith("vn "))
                {
                    var normalArray = line
                        .ToLower()
                        .Split(" ")
                        .Where(str => str != "vn" && !string.IsNullOrEmpty(str))
                        .Select(s => float.Parse(s, CultureInfo.InvariantCulture))
                        .ToArray();
                    normalsBuffer.Add(new Vector3(normalArray[0], normalArray[1], normalArray[2]));
                }

                if (line.StartsWith("f"))
                {
                    var indexesArray = line
                        .ToLower()
                        .Split(" ")
                        .Where(str => str != "f" && !string.IsNullOrEmpty(str))
                        .Select(str =>
                        {
                            var indexes = str.Split("/");
                            return new VertexInfo(int.Parse(indexes[0]), int.Parse(indexes[2]));
                        })
                        .ToList();
                    vertexInfoBuffer.Add(indexesArray);
                }
            }
            if(vertexBuffer.Count != 0)
                objects.Add(new Custom(vertexBuffer, normalsBuffer, vertexInfoBuffer, new Vector3(0.5f, 0.5f, 0.5f)));
            return objects;
        }
    }
}