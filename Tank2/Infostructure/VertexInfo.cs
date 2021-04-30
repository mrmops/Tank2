namespace Tank2
{
    public class VertexInfo
    {
        public int VertexIndex { get; private set; }
        public int NormalIndex { get; private set; }

        public VertexInfo(int vertexIndex, int normalIndex)
        {
            VertexIndex = vertexIndex;
            NormalIndex = normalIndex;
        }
    }
}