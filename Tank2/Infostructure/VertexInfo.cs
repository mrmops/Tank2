namespace Tank2
{
    public class VertexInfo
    {
        public bool UseTexture { get; set; }
        
        public int? TextureIndex { get; set; }
        public int VertexIndex { get; private set; }
        public int NormalIndex { get; private set; }

        public VertexInfo(int vertexIndex, int normalIndex,  bool useTexture = false, int? textureIndex = null)
        {
            VertexIndex = vertexIndex;
            NormalIndex = normalIndex;
            TextureIndex = textureIndex;
            UseTexture = useTexture;
        }
    }
}