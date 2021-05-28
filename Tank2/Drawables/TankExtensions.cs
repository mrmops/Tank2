using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using OpenTK;
using Tank2.Drawables.Implementation;

namespace Tank2.Drawables
{
    public static class TankExtensions
    {
        private static Vector3 _color = new Vector3(0f, 0.4f, 0.2f);
        private static Vector3 _greyWh = new Vector3(0.4f, 0.4f, 0.4f);
        private static Vector3 _greyBl = new Vector3(0.2f, 0.2f, 0.2f);
        private static Vector3 _black = _greyBl;
        
        private static int _sidesNumber = 40;

        public static List<IDrawableGl> Template(this List<IDrawableGl> objects)
        {
            return objects;
        }

        public static List<IDrawableGl> AddBody(this List<IDrawableGl> list)
            => DoActAndReturnList(list, objects =>
            {
                var translate = new Vector3(0f, 1f, 0f);

                #region plane

                var upPlane = new Custom(
                    new List<Vector3>()
                    {
                        new Vector3(-5.4f, 0, -2.5f),
                        new Vector3(5.4f, 0, -2.5f),
                        new Vector3(4.5f, 0, 2.5f),
                        new Vector3(-4.5f, 0, 2.5f),
                    },
                    new List<Vector3>()
                    {
                        new Vector3(0, 1, 0).Normalized(),
                    },
                    new List<List<VertexInfo>>()
                    {
                        new List<VertexInfo>()
                        {
                            new VertexInfo(1, 1),
                            new VertexInfo(2, 1),
                            new VertexInfo(3, 1),
                            new VertexInfo(4, 1),
                        }
                    },
                    _color);
                upPlane.Rotate(new Vector3(30, 0, 0));
                upPlane.Translate(translate + new Vector3(0, 6.7f, 13f));

                objects.Add(upPlane);

                #endregion

                #region CubeBody

                var cube = new Cube(_color);
                cube.Translate(translate + new Vector3(0f, 6f, -4.2f));
                cube.Scale(new Vector3(10.8f / 2, 7.0f / 2, 30.2f / 2));
                objects.Add(cube);

                #endregion

                #region upCube

                // var cube1 = new Cube(color);
                // cube1.Translate(new Vector3(0, 8.7f, 10.3f));
                // cube1.Scale(new Vector3(10.8f / 2, 1.8f / 2, 1.2f / 2));
                //
                // objects.Add(cube1);

                #endregion

                #region planeDown

                var downPlane = new Custom(
                    new List<Vector3>()
                    {
                        new Vector3(-5.4f, 0, -3.35f),
                        new Vector3(5.4f, 0, -3.35f),
                        new Vector3(5.4f, 0, 2.5f),
                        new Vector3(-5.4f, 0, 2.5f),
                    },
                    new List<Vector3>()
                    {
                        new Vector3(0, -1, 0).Normalized(),
                    },
                    new List<List<VertexInfo>>()
                    {
                        new List<VertexInfo>()
                        {
                            new VertexInfo(1, 1),
                            new VertexInfo(2, 1),
                            new VertexInfo(3, 1),
                            new VertexInfo(4, 1),
                        }
                    },
                    _color);
                downPlane.Rotate(new Vector3(-30, 0, 0));
                downPlane.Translate(translate + new Vector3(0, 4.2f, 13f));

                objects.Add(downPlane);

                #endregion

                #region HorizontalPlane

                var horPlane = new Custom(
                    new List<Vector3>()
                    {
                        new Vector3(-5.4f, 5.4f, 10.9f),
                        new Vector3(-5.4f, 5.4f, 15.7f),
                        new Vector3(-5.4f, 2.5f, 10.9f),
                    },
                    new List<Vector3>()
                    {
                        new Vector3(-1, 0, 0).Normalized(),
                    },
                    new List<List<VertexInfo>>()
                    {
                        new List<VertexInfo>()
                        {
                            new VertexInfo(1, 1),
                            new VertexInfo(2, 1),
                            new VertexInfo(3, 1),
                        }
                    },
                    _color);
                horPlane.Translate(translate);
                objects.Add(horPlane);

                #endregion

                #region HorizontalPlane

                var horPlane2 = new Custom(
                    new List<Vector3>()
                    {
                        new Vector3(5.4f, 5.4f, 10.9f),
                        new Vector3(5.4f, 5.4f, 15.7f),
                        new Vector3(5.4f, 2.5f, 10.9f),
                    },
                    new List<Vector3>()
                    {
                        new Vector3(1, 0, 0).Normalized(),
                    },
                    new List<List<VertexInfo>>()
                    {
                        new List<VertexInfo>()
                        {
                            new VertexInfo(1, 1),
                            new VertexInfo(2, 1),
                            new VertexInfo(3, 1),
                        }
                    },
                    _color);
                horPlane2.Translate(translate);
                objects.Add(horPlane2);

                #endregion

                #region HorizontalPlane

                var horPlane3 = new Custom(
                    new List<Vector3>()
                    {
                        new Vector3(-5.4f, 5.4f, 10.9f),
                        new Vector3(-5.4f, 5.4f, 15.7f),
                        new Vector3(5.4f, 5.4f, 15.7f),
                        new Vector3(5.4f, 5.4f, 10.9f),
                    },
                    new List<Vector3>()
                    {
                        new Vector3(0, 1, 0).Normalized(),
                    },
                    new List<List<VertexInfo>>()
                    {
                        new List<VertexInfo>()
                        {
                            new VertexInfo(1, 1),
                            new VertexInfo(2, 1),
                            new VertexInfo(3, 1),
                            new VertexInfo(4, 1),
                        }
                    },
                    _color);
                horPlane3.Translate(translate);
                objects.Add(horPlane3);

                #endregion

                #region HorizontalPlane

                var horPlane4 = new Custom(
                    new List<Vector3>()
                    {
                        new Vector3(-5.4f, 7.9f, 10.9f),
                        new Vector3(-5.4f, 5.4f, 10.9f),
                        new Vector3(-4.5f, 5.4f, 15.7f),
                    },
                    new List<Vector3>()
                    {
                        new Vector3(-1, 0, 0).Normalized(),
                    },
                    new List<List<VertexInfo>>()
                    {
                        new List<VertexInfo>()
                        {
                            new VertexInfo(1, 1),
                            new VertexInfo(2, 1),
                            new VertexInfo(3, 1),
                        }
                    },
                    _color);
                horPlane4.Translate(translate);
                objects.Add(horPlane4);

                #endregion

                #region HorizontalPlane

                var horPlane5 = new Custom(
                    new List<Vector3>()
                    {
                        new Vector3(5.4f, 7.9f, 10.9f),
                        new Vector3(5.4f, 5.4f, 10.9f),
                        new Vector3(4.5f, 5.4f, 15.7f),
                    },
                    new List<Vector3>()
                    {
                        new Vector3(1, 0, 0).Normalized(),
                    },
                    new List<List<VertexInfo>>()
                    {
                        new List<VertexInfo>()
                        {
                            new VertexInfo(1, 1),
                            new VertexInfo(2, 1),
                            new VertexInfo(3, 1),
                        }
                    },
                    _color);
                horPlane5.Translate(translate);
                objects.Add(horPlane5);

                #endregion

                #region plane

                var backUpPlane = new Custom(
                    new List<Vector3>()
                    {
                        new Vector3(5.4f, 9.5f, -19.1f),
                        new Vector3(-5.4f, 9.5f, -19.1f),
                        new Vector3(-5.4f, 7.3f, -21.5f),
                        new Vector3(5.4f, 7.3f, -21.5f),
                    },
                    new List<Vector3>()
                    {
                        new Vector3(0, 1, 0).Normalized(),
                    },
                    new List<List<VertexInfo>>()
                    {
                        new List<VertexInfo>()
                        {
                            new VertexInfo(1, 1),
                            new VertexInfo(2, 1),
                            new VertexInfo(3, 1),
                            new VertexInfo(4, 1),
                        }
                    },
                    _black);
                backUpPlane.Translate(translate);
                objects.Add(backUpPlane);

                #endregion

                #region plane

                var backVertPlane = new Custom(
                    new List<Vector3>()
                    {
                        new Vector3(5.4f, 6.4f, -21.5f),
                        new Vector3(-5.4f, 6.4f, -21.5f),
                        new Vector3(-5.4f, 7.3f, -21.5f),
                        new Vector3(5.4f, 7.3f, -21.5f),
                    },
                    new List<Vector3>()
                    {
                        new Vector3(0, 1, 0).Normalized(),
                    },
                    new List<List<VertexInfo>>()
                    {
                        new List<VertexInfo>()
                        {
                            new VertexInfo(1, 1),
                            new VertexInfo(2, 1),
                            new VertexInfo(3, 1),
                            new VertexInfo(4, 1),
                        }
                    },
                    _black);
                backVertPlane.Translate(translate);
                objects.Add(backVertPlane);

                #endregion

                #region plane

                var backDownPlane = new Custom(
                    new List<Vector3>()
                    {
                        new Vector3(5.4f, 6.4f, -21.5f),
                        new Vector3(-5.4f, 6.4f, -21.5f),
                        new Vector3(-5.4f, 2.6f, -19.1f),
                        new Vector3(5.4f, 2.6f, -19.1f),
                    },
                    new List<Vector3>()
                    {
                        new Vector3(0, 1, -1).Normalized(),
                    },
                    new List<List<VertexInfo>>()
                    {
                        new List<VertexInfo>()
                        {
                            new VertexInfo(1, 1),
                            new VertexInfo(2, 1),
                            new VertexInfo(3, 1),
                            new VertexInfo(4, 1),
                        }
                    },
                    _black);
                backDownPlane.Translate(translate);
                objects.Add(backDownPlane);

                #endregion

                #region plane

                var leftRightSides = new Custom(
                    new List<Vector3>()
                    {
                        new Vector3(5.4f, 9.5f, -19.1f),
                        new Vector3(5.4f, 7.3f, -21.5f),
                        new Vector3(5.4f, 6.4f, -21.5f),
                        new Vector3(5.4f, 2.6f, -19.1f),
                    },
                    new List<Vector3>()
                    {
                        new Vector3(0, -1, 0).Normalized(),
                    },
                    new List<List<VertexInfo>>()
                    {
                        new List<VertexInfo>()
                        {
                            new VertexInfo(1, 1),
                            new VertexInfo(2, 1),
                            new VertexInfo(3, 1),
                            new VertexInfo(4, 1),
                        }
                    },
                    _black);
                leftRightSides.Translate(translate);
                objects.Add(new ReflectObject(leftRightSides));

                #endregion
            });

        public static List<IDrawableGl> AddTracks(this List<IDrawableGl> list)
            => DoActAndReturnList(list, objects =>
            {
                AddUpRollers(objects);
                AddDownRollers(objects);

                AddCenterTrack(objects);

                // #region Track
                //
                // var z = 14.3f;
                // while (z > -20.31f)
                // {
                //     var trackElement = new Cube(color);
                //     var scaleX = 3.6f / 2f;
                //     var scaleY = 0.4f / 2f;
                //     trackElement.Scale(new Vector3(scaleX, scaleY, 0.6f / 2));
                //     var x = 7.6f;
                //     var y = 8.5f;
                //     trackElement.Translate(new Vector3(x, y, z));
                //     objects.Add(new ReflectObject(trackElement));
                //     
                //     var trackElement1 = new Cube(color);
                //     trackElement1.Scale(new Vector3(scaleX, scaleY, 0.3f / 2));
                //     trackElement1.Translate(new Vector3(x, y + 0.1f, z + -0.45f));
                //     objects.Add(new ReflectObject(trackElement1));
                //     z -= 0.9f;
                // }
                // #endregion

                var upTrack = new SuperDrawable(_black, GenerateTracks(_black, 33.5f));
                    /*.Select(x =>
                    {
                        x.Translate(new Vector3(7.6f, 7.5f, -19.5f));
                        return new ReflectObject(x);
                    });*/
                upTrack.Translate(new Vector3(7.6f, 7.5f, -19.5f));
                objects.Add(new ReflectObject(upTrack));

                var downTrack = new SuperDrawable(_black,GenerateTracks(_black, 27f))
                    /*.Select(x =>
                    {
                        x.Translate(new Vector3(7.6f, 1f, -15.5f));
                        return new ReflectObject(x);
                    })*/;
                downTrack.Translate(new Vector3(7.6f, 1f, -16.4f));
                objects.Add(new ReflectObject(downTrack));

                var leftTrack = GenerateTracks(_black, 5f);
                var superDrawable = new SuperDrawable(_black, leftTrack);
                superDrawable.Rotate(new Vector3(-47.5f, 0, 0));
                superDrawable.Translate(new Vector3(7.6f, 1.4f, 11.3f));
                
                objects.Add(new ReflectObject(superDrawable));
                
                var rightTrack = GenerateTracks(_black, 4.1f);
                var superDrawableRight = new SuperDrawable(_black, rightTrack);
                superDrawableRight.Rotate(new Vector3(45f, 0, 0));
                superDrawableRight.Translate(new Vector3(7.6f, 3.7f, -19.8f));
                
                objects.Add(new ReflectObject(superDrawableRight));
            });
        
        public static List<IDrawableGl> AddTracksPlugs(this List<IDrawableGl> list)
            => DoActAndReturnList(list, objects =>
            {
                var plane = new Cube(_color);
                plane.Scale(new Vector3(3.6f / 2, 0.3f / 2,34.7f / 2));
                plane.Translate(new Vector3(7.6f, 8f, -2.5f));

                objects.Add(new ReflectObject(plane));

                var sphere = new Sphere(_black, 1f, _sidesNumber, _sidesNumber);
                sphere.Translate(new Vector3(-2.8f, 9.3f, 11f));
                
                objects.Add(sphere);
                
                var cylinder = new Cylinder(_black, 1.2f * 2, _sidesNumber);
                cylinder.Translate(new Vector3(-2.8f, 7.2f, 10.8f));
                
                objects.Add(cylinder);
                
                var gun = new Cylinder(_black, 0.2f, _sidesNumber);
                gun.Scale(new Vector3(1, 3f, 1));
                gun.Translate(new Vector3(-2.8f, 7.2f, 12.2f));
                
                objects.Add(gun);
                
                var gun2 = new Cylinder(_black, 0.4f, _sidesNumber);
                gun2.Scale(new Vector3(1, 2f, 1));
                gun2.Translate(new Vector3(-2.8f, 7.2f, 11.7f));
                
                objects.Add(gun2);
            });
        
        public static List<IDrawableGl> AddHead(this List<IDrawableGl> list)
            => DoActAndReturnList(list, objects =>
            {
                #region headBody
                
                float y = 19f;
                var y2 = 12.5f;
                var vertexes = new List<Vector3>()
                {
                    new Vector3(-3.8f, y, 5.2f),
                    new Vector3(-5.3f, y, 1.4f),
                    new Vector3(-5.3f, y, 0),
                    new Vector3(-4.8f, y, -9.0f),

                    new Vector3(4.8f, y, -9.0f),
                    new Vector3(5.3f, y, 0),
                    new Vector3(5.3f, y, 1.4f),
                    new Vector3(3.8f, y, 5.2f),

                    new Vector3(-3.8f, y2, 5.2f),
                    new Vector3(-5.3f, y2, 1.4f),
                    new Vector3(-5.3f, y2, 0),
                    new Vector3(-4.8f, y2, -9.0f),

                    new Vector3(4.8f, y2, -9.0f),
                    new Vector3(5.3f, y2, 0),
                    new Vector3(5.3f, y2, 1.4f),
                    new Vector3(3.8f, y2, 5.2f),
                };
                var normals = new List<Vector3>()
                {
                    new Vector3(0, 1, 0),
                    new Vector3(0, -1, 0),
                };

                var rotation = Matrix4.CreateRotationY(MathHelper.DegreesToRadians(90));
                for (int i = 0; i < vertexes.Count / 2; i++)
                {
                    normals.Add((new Vector4(vertexes[i + 1] - vertexes[i]) * rotation).Xyz.Normalized());
                }
                
                var polygonsIndexes = new List<List<VertexInfo>>()
                {
                    new List<VertexInfo>()
                    {
                        new VertexInfo(1, 1),
                        new VertexInfo(2, 1),
                        new VertexInfo(3, 1),
                        new VertexInfo(4, 1),
                        new VertexInfo(5, 1),
                        new VertexInfo(6, 1),
                        new VertexInfo(7, 1),
                        new VertexInfo(8, 1),
                    },
                    new List<VertexInfo>()
                    {
                        new VertexInfo(9, 2),
                        new VertexInfo(10, 2),
                        new VertexInfo(11, 2),
                        new VertexInfo(12, 2),
                        new VertexInfo(13, 2),
                        new VertexInfo(14, 2),
                        new VertexInfo(15, 2),
                        new VertexInfo(16, 2),
                    },

                    new List<VertexInfo>()
                    {
                        new VertexInfo(1, 3),
                        new VertexInfo(2, 3),
                        new VertexInfo(9, 3),
                        new VertexInfo(10, 3),
                    },
                };

                for (int i = 1; i < vertexes.Count / 2; i++)
                {
                    polygonsIndexes.Add(new List<VertexInfo>()
                    {
                        new VertexInfo(i, i + 2),
                        new VertexInfo(i + 1, i + 2),
                        new VertexInfo(i + 9, i + 2),
                        new VertexInfo(i + 8, i + 2),
                    });
                }
                
                polygonsIndexes.Add(new List<VertexInfo>()
                {
                    new VertexInfo(1, 1 + 2),
                    new VertexInfo(8, 1 + 2),
                    new VertexInfo(vertexes.Count, 1 + 2),
                    new VertexInfo(9, 1 + 2),
                });

                var upPlane = new Custom(vertexes, normals, polygonsIndexes, _color);

                objects.Add(upPlane);
                
                #endregion

                var cube = new Cube(_color);
                cube.Scale(new Vector3(9.5f /2, 5f /2, 10.5f /2));
                cube.Translate(new Vector3(0, 10.5f, 0));
                
                objects.Add(cube);

                var cylinder = new Cylinder(_greyBl, 2.8f * 1.5f, _sidesNumber);
                cylinder.Scale(new Vector3(1, 6, 1));
                cylinder.Translate(new Vector3(0, 14.9f, 5.3f));
                cylinder.Rotate(new Vector3(0, 90, 0));
                
                objects.Add(cylinder);

                var cube2 = new Cube(_black);
                cube2.Scale(new Vector3(3.2f / 3, 3.6f / 3, 3.6f / 3));
                cube2.Translate(new Vector3(0, 16.8f, 8f));
                
                objects.Add((cube2));

                var gun = new Ring(_color, 0.7f, 0.9f, _sidesNumber);
                gun.Translate(new Vector3(0, 14.9f, 8f));
                gun.Scale(new Vector3(1, 9.5f, 1));
                
                objects.Add(gun);


            });

        private static List<BaseDrawableGl> GenerateCircleTracks(float angleStart, float angleEnd, float radius)
        {
            var dAngle = angleEnd - angleStart;
            var lenght = (float) (2 * Math.PI * radius);
            var selectedLenght = Math.Abs(lenght * dAngle / 360);
            var countTracks = (int) (selectedLenght / 0.9);
            var alpha = dAngle / countTracks;
            var startDirection = new Vector4(new Vector3(0, radius, 0));
            var result = new List<BaseDrawableGl>();
            for (int i = 0; i < countTracks; i++)
            {
                var element = GenerateTrackElement(_black, out var element1);
                var angle = angleStart + alpha * i;
                var rotation = new Vector3(angle, 0, 0);
                element.Rotate(rotation);
                element1.Rotate(rotation);
                var direction = (startDirection * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(angle))).Xyz;
                element.Translate(direction);
                element1.Translate(direction + new Vector3(0, 0, 0.45f));
                element1.localTransform *= Matrix4.CreateTranslation(0, 0, -0.45f);
                result.Add(element);
                result.Add(element1);
            }

            return result;
        }

        private static List<BaseDrawableGl> GenerateTracks(Vector3 color, float lenght)
        {
            var drawableGls = new List<BaseDrawableGl>();
            var z = 0f;
            while (z <= lenght)
            {
                var trackElement = GenerateTrackElement(color, out var trackElement1);

                var translate = new Vector3(0, 0, z);
                trackElement.Translate(translate);
                trackElement1.Translate(translate);
                drawableGls.Add(trackElement);
                drawableGls.Add(trackElement1);
                z += 0.9f;
            }

            return drawableGls;
        }

        private static Cube GenerateTrackElement(Vector3 color, out Cube trackElement1)
        {
            var scaleX = 3.6f / 2f;
            var scaleY = 0.4f / 2f;
            var trackElement = new Cube(color);
            trackElement.Scale(new Vector3(scaleX, scaleY, 0.6f / 2));

            trackElement1 = new Cube(color);
            trackElement1.Scale(new Vector3(scaleX, scaleY, 0.3f / 2));
            trackElement1.Translate(new Vector3(0, 0.1f, -0.45f));
            return trackElement;
        }

        private static void AddCenterTrack(List<IDrawableGl> objects)
        {
            #region Ring

            var y = 4f;
            var x = 7.3f;
            var z = 13.5f;
            var translate = new Vector3(x, y, z);
            var rotation = new Vector3(0, 90, 0);

            var ring1 = new Ring(_greyWh, 1.8f, 2.5f, _sidesNumber);
            ring1.Rotate(rotation);
            ring1.Translate(translate);
            ring1.Scale(new Vector3(1f, 0.5f, 1f));
            objects.Add(new ReflectObject(ring1));

            var roller1 = new Cylinder(_greyWh, 0.75f, _sidesNumber);
            roller1.Translate(translate - new Vector3(2.25f, 0f, 0f));
            roller1.Rotate(rotation);
            roller1.Scale(new Vector3(1f, 5f, 1f));
            objects.Add(new ReflectObject(roller1));

            var cube = new Cube(_black);
            cube.Translate(translate + new Vector3(0f, 1.25f * 1.5f, 0));
            cube.Scale(new Vector3(0.35f / 2, 1f / 2, 0.2f / 2));
            cube.localTransform *= Matrix4.CreateTranslation(new Vector3(0f, 1.125f, 0f));
            objects.Add(new ReflectObject(new RepeatRotate(cube, 6)));

            #endregion

            var translate1 = new Vector3(x, y, -19.3f);
            var rotation1 = new Vector3(0, 90, 0);

            var ring = new Ring(_greyWh, 2.5f, 3.1f, _sidesNumber);
            ring.Rotate(rotation1);
            ring.Translate(translate1);
            ring.Scale(new Vector3(1f, 0.5f, 1f));
            objects.Add(new ReflectObject(ring));

            var roller = new Cylinder(_greyWh, 0.75f, _sidesNumber);
            roller.Translate(translate1 - new Vector3(2.25f, 0f, 0f));
            roller.Rotate(rotation1);
            roller.Scale(new Vector3(1f, 5f, 1f));
            objects.Add(new ReflectObject(roller));

            var cube1 = new Cube(_greyBl);
            cube1.Translate(translate1 + new Vector3(0f, 1.25f * 1.5f, 0));
            cube1.Scale(new Vector3(0.35f / 2, 1.25f / 2, 0.2f / 2));
            cube1.localTransform *= Matrix4.CreateTranslation(new Vector3(0f, 1.125f, 0f));
            objects.Add(new ReflectObject(new RepeatRotate(cube1, 6)));
            
            var trackCircle = GenerateCircleTracks(0, 175, 3f / 2);
            foreach (var baseDrawableGl in trackCircle)
            {
                baseDrawableGl.Translate(translate + new Vector3(0.3f, 2f,0));
            }
            objects.AddRange(trackCircle.Select(gl => new ReflectObject(gl)));
            
            var trackCircle1 = GenerateCircleTracks(-135, -10, 4f / 2);
            foreach (var baseDrawableGl in trackCircle1)
            {
                baseDrawableGl.Translate(translate1 + new Vector3(0.3f, 2f,0));
            }
            objects.AddRange(trackCircle1.Select(gl => new ReflectObject(gl)));
        }

        private static void AddDownRollers(List<IDrawableGl> objects)
        {
            var color = _greyBl;
            for (int i = 0; i < 6; i++)
            {
                #region Roller

                var roller1 = new Cylinder(color, 1.5f * 2, _sidesNumber);
                var translate = new Vector3(7.6f, 1.1f, 10.7f + i * -5.4f);
                roller1.Translate(translate);
                var rotation = new Vector3(0, 90, 0);
                roller1.Rotate(rotation);
                roller1.Scale(new Vector3(1f, 2.6f, 1f));
                
                objects.Add(new ReflectObject(roller1));

                var outerRadius = 1.7f * 2;
                var innerRadius = 1.3f * 2;
                var rightRing = new Ring(_greyWh, innerRadius, outerRadius, _sidesNumber);
                rightRing.Translate(translate + new Vector3(1f, 0, 0));
                rightRing.Scale(new Vector3(1f, 1.3f, 1f));
                rightRing.Rotate(rotation);
                
                objects.Add(new ReflectObject(rightRing));
                
                var leftRing = new Ring(_greyWh, innerRadius, outerRadius, _sidesNumber);
                leftRing.Translate(translate + new Vector3(-1f, 0, 0));
                leftRing.Scale(new Vector3(1f, 1.3f, 1f));
                leftRing.Rotate(rotation);
                
                objects.Add(new ReflectObject(leftRing));
                
                var rollerCentral = new Cylinder(_black, 0.7f, _sidesNumber);
                rollerCentral.Translate(new Vector3(7.6f, 1.1f, 10.7f + i * -5.4f));
                rollerCentral.Rotate(new Vector3(0, 90, 0));
                rollerCentral.Scale(new Vector3(1f, 2.9f, 1f));
                
                objects.Add(new ReflectObject(rollerCentral));

                #endregion
            }
        }

        private static void AddUpRollers(List<IDrawableGl> objects)
        {
            var color = _greyWh;

            #region plane

            var upPlane = new Cylinder(color, 1.1f, _sidesNumber);
            var y = 5f;
            upPlane.Translate(new Vector3(7.6f, y, 7.0f));
            upPlane.Rotate(new Vector3(0, 90, 0));
            upPlane.Scale(new Vector3(1f, 1.8f, 1f));

            objects.Add(new ReflectObject(upPlane));

            #endregion

            #region plane

            var upPlane2 = new Cylinder(color, 1.1f, _sidesNumber);
            upPlane2.Translate(new Vector3(7.6f, y, -3.5f));
            upPlane2.Rotate(new Vector3(0, 90, 0));
            upPlane2.Scale(new Vector3(1f, 1.8f, 1f));

            objects.Add(new ReflectObject(upPlane2));

            #endregion

            #region plane

            var upPlane3 = new Cylinder(color, 1.1f, _sidesNumber);
            upPlane3.Translate(new Vector3(7.6f, y, -13.5f));
            upPlane3.Rotate(new Vector3(0, 90, 0));
            upPlane3.Scale(new Vector3(1f, 1.8f, 1f));

            objects.Add(new ReflectObject(upPlane3));

            #endregion
        }

        private static List<IDrawableGl> DoActAndReturnList(List<IDrawableGl> objects, Action<List<IDrawableGl>> action)
        {
            action.Invoke(objects);
            return objects;
        }
    }
}