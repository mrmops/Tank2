using System;
using System.Collections.Generic;
using System.Numerics;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using Tank2.Drawables;
using Tank2.Drawables.Implementation;
using Vector3 = OpenTK.Vector3;

namespace Tank2
{
    public class Scene : GameWindow
    {

        private int _rotationAngelY;
        private int _rotationAngelX;
        private bool _mouseWasDown;

        private List<IDrawableGl> _drawableGls = new List<IDrawableGl>()
        {
            new Cylinder(new Vector3(0.5f, 0.5f, 0.5f), 0.5f, 2f, 12)
        };

        public Scene()
            : base(800, 600, GraphicsMode.Default, "OpenTK Quick Start Sample")
        {
            VSync = VSyncMode.On;
            //_drawableGls.AddRange(ObjReaderHelper.ReadObj("example.obj"));
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(0.1f, 0.2f, 0.5f, 0.0f);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Normalize);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float) Math.PI / 4,
                Width / (float) Height, 1.0f, 64.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);


            //Matrix4.

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);
            MakeMatAndLight();
            
            GL.Light(LightName.Light0, LightParameter.Ambient, Color4.White);


             /*float z = 4.0f;
             Vector3 clr1 = new Vector3(1.0f, 1.0f, 0.0f);
             Vector3 clr2 = new Vector3(1.0f, 0.0f, 0.0f);
             Vector3 clr3 = new Vector3(0.2f, 0.9f, 1.0f);
             Vector3 p1 = new Vector3(-1.0f, -1.0f, z);
             Vector3 p2 = new Vector3(1.0f, -1.0f, z);
             Vector3 p3 = new Vector3(1.0f, 1.0f, z);
             Vector3 p4 = new Vector3(-1.0f, 1.0f, z);
            
             var n = 50;
             var radius = 0.5f;
             var center = new Vector3(0, 0, z);
             float angle = 2 * (float) Math.PI / n;
             var vetexes = new List<Vector3>();
             for (var i = 0; i < n; i++)
             {
                 var startPoint = new Vector3();
                 startPoint.X = (float) (center.X + radius * Math.Cos(angle * i));
                 startPoint.Y = (float) (center.Y + (radius * Math.Sin(angle * i)));
                 startPoint.Z = z;
                 vetexes.Add(startPoint);
             }
            
             GL.Begin(PrimitiveType.Polygon);
             GL.Color3(clr1);
             foreach (var vec in vetexes)
             {
                 GL.Vertex3(vec);
             }
            
             GL.End();
             SwapBuffers();


            drawing
            GL.Begin(BeginMode.Quads);
            GL.Color3(clr1); GL.Vertex3(p1);
            GL.Color3(clr2); GL.Vertex3(p2);
            GL.Color3(clr3); GL.Vertex3(p3);
            GL.Color3(clr2); GL.Vertex3(p4);
            GL.End();*/
             
            GL.Translate(new Vector3(0.0f, -1.0f, 5.0f));
            GL.Rotate(_rotationAngelY, 0.0f, 1.0f, 0.0f);
            GL.Rotate(_rotationAngelX, 1.0f, 0.0f, 0.0f);
            foreach (var drawableGl in _drawableGls)
            {
                drawableGl.DrawPolygons();
            }
            SwapBuffers();
        }

        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            base.OnMouseMove(e);
            if(_mouseWasDown && e.XDelta != 0)
                _rotationAngelY += e.XDelta > 0 ? 5 : -5;
            
            if(_mouseWasDown && e.YDelta != 0)
                _rotationAngelX += e.YDelta > 0 ? 5 : -5;
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            _mouseWasDown = !_mouseWasDown;
        }

        public void MakeMatAndLight()
        {
            float[] light_position = { 30, 30, -30, 0 }; // Координаты источника света
            float[] lghtClr = { 1, 1, 1, 0 }; // Источник излучает белый цвет
            float[] mtClr = { 0, 1, 1, 1 }; // Материал зеленого цвета
            GL.Enable(EnableCap.Lighting); // Будем рассчитывать освещенность
            GL.Light(LightName.Light0, LightParameter.Position, light_position);
            GL.Light(LightName.Light0, LightParameter.Ambient, lghtClr); // Рассеивание
            GL.Enable(EnableCap.Light0); // Включаем в уравнение освещенности источник GL_LIGHT0
            // Диффузионная компонента цвета материала
            GL.Material(MaterialFace.Front, MaterialParameter.Diffuse, mtClr);
        }
    }
}