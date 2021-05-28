using System;
using System.Collections.Generic;
using OpenTK;

namespace Tank2.Drawables.Implementation
{
    public class RotateObject: IDrawableGl
    {
        private List<IDrawableGl> _drawableGls;
        private Matrix4 rotateMatrix;

        public RotateObject(List<IDrawableGl> drawableGls, Vector3 angle)
        {
            _drawableGls = drawableGls;
            rotateMatrix = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(angle.X))
                           * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(angle.Y))
                           * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(angle.Z));
        }

        public void DrawPolygons(Matrix4 worldTransform)
        {
            
            _drawableGls.ForEach(x => x.DrawPolygons(worldTransform * rotateMatrix));
        }
    }
}