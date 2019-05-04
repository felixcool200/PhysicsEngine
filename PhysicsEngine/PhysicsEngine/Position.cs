using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine
{
    public class Position
    {
        public class Point
        {
            public float X { get; set; }
            public float Y { get; set; }

            public Point(float X, float Y)
            {
                this.X = X;
                this.Y = Y;
            }

            public static Point operator +(Point p1, Point p2)
            {
                return new Point(p1.X + p2.X, p1.Y + p2.Y);
            }

            public static Point operator -(Point p1, Point p2)
            {
                return new Point(p1.X - p2.X, p1.Y - p2.Y);
            }

            public Vector2 ToVector2(Point p)
            {
                return new Vector2(p.X, p.Y);
            }
        }
        public class Vector2
        {
            public float X { get; set; }
            public float Y { get; set; }

            public Vector2(float X, float Y)
            {
                this.X = X;
                this.Y = Y;
            }

            public static Vector2 operator* (Vector2 v1, Vector2 v2)
            {
                return new Vector2(v1.X * v2.X, v1.Y * v2.Y);
            }

            public static Vector2 operator+ (Vector2 v1, Vector2 v2)
            {
                return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
            }
        }
    }
}
