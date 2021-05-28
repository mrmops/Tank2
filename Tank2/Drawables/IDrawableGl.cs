using OpenTK;

namespace Tank2
{
    public interface IDrawableGl
    {
        void DrawPolygons(Matrix4 worldTransform);
    }
}