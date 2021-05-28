using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Tank2.Drawables.Implementation
{
    public class TextureCustom: BaseDrawableGl
    {
        private List<Point> textureVertexes;
        private Bitmap texture;

        public TextureCustom(Vector3 color, List<Point> textureVertexes, List<Vector3> vertexes, List<Vector3> normals,
            List<List<VertexInfo>> polygonsIndexes, string pathTexture) : base(color)
        {
            this.textureVertexes = textureVertexes;
            Vertexes = vertexes;
            Normals = normals;
            PolygonsIndexes = polygonsIndexes;
            texture = new Bitmap(pathTexture);
            GL.GenTextures(1, out int textureId);
            GL.BindTexture(TextureTarget.Texture2D, textureId);
            
            BitmapData data = texture.LockBits(new System.Drawing.Rectangle(0, 0, texture.Width, texture.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            texture.UnlockBits(data);
            
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            GL.Enable(EnableCap.Texture2D);
        }

        protected override void OnVertexSet(VertexInfo vertexInfo)
        {
            if (vertexInfo.UseTexture)
            {
                var vertexInfoTextureIndex = vertexInfo.TextureIndex ?? 0;
                var coor = textureVertexes[vertexInfoTextureIndex - 1];
                GL.TexCoord2(coor.X, coor.Y);
            }
        }

        public override List<Vector3> Vertexes { get; protected set; }
        public override List<Vector3> Normals { get; protected set; }
        public override List<List<VertexInfo>> PolygonsIndexes { get; protected set; }
    }
}