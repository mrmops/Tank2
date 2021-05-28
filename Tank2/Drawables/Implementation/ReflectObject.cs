using OpenTK;

namespace Tank2.Drawables.Implementation
{
    public class ReflectObject: IDrawableGl
    {

        private IDrawableGl obj;
        private Matrix4 scale = Matrix4.CreateScale(-1f, 1f, 1f);

        public ReflectObject(IDrawableGl obj)
        {
            this.obj = obj;
        }

        public void DrawPolygons(Matrix4 worldTransform)
        {
            obj.DrawPolygons(worldTransform);
            worldTransform *= scale;
            obj.DrawPolygons(worldTransform);

        }
    }
}