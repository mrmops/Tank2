using System;
using OpenTK;

namespace Tank2.Drawables.Implementation
{
    public class RepeatRotate: IDrawableGl
    {
        private BaseDrawableGl _drawableGl;
        private int _count;

        public RepeatRotate(BaseDrawableGl drawableGl, int count)
        {
            _drawableGl = drawableGl;
            _count = count;
        }

        public void DrawPolygons(Matrix4 worldTransform)
        {
            var angle = 360f / _count;
            for (var i = 0; i < _count; i++)
            {
                _drawableGl.Rotate(new Vector3(angle, 0, 0));
                _drawableGl.DrawPolygons(worldTransform);
            }
        }
    }
}