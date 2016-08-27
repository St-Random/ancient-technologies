using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientTechnology.Core {
    public static class DistanceHelper {
        public static float GetDistanceSquared(this Vector2 point, Rectangle rectangle) {
            float xDistance = 0,
                  yDistance = 0;

            if (rectangle.Bottom > point.Y || rectangle.Top < point.Y) {
                yDistance = Math.Min(Math.Abs(point.Y - rectangle.Top), Math.Abs(point.Y - rectangle.Bottom));
            }
            if (rectangle.Left > point.X || rectangle.Right < point.X) {
                xDistance = Math.Min(Math.Abs(point.X - rectangle.Left), Math.Abs(point.X - rectangle.Right));
            }

            return xDistance * xDistance + yDistance * yDistance;
        }
        public static float GetDistance(this Vector2 point, Rectangle rectangle) {
            return (float)Math.Sqrt(GetDistanceSquared(point, rectangle));
        }

        public static float GetDistanceSquared(this Rectangle rectangle, Vector2 point) {
            return GetDistanceSquared(point, rectangle);
        }
        public static float GetDistance(this Rectangle rectangle, Vector2 point) {
            return GetDistance(point, rectangle);
        }

        public static int GetDistanceSquared(this Rectangle rectangle1, Rectangle rectangle2) {
            int xDistance = 0,
                yDistance = 0;

            if (rectangle1.Bottom > rectangle2.Top || rectangle1.Top < rectangle2.Bottom) {
                yDistance = Math.Min(Math.Abs(rectangle1.Bottom - rectangle2.Top),
                                     Math.Abs(rectangle2.Bottom - rectangle1.Top));
            }

            if (rectangle1.Left > rectangle2.Right || rectangle1.Right < rectangle2.Left) {
                xDistance = Math.Min(Math.Abs(rectangle1.Left - rectangle2.Right),
                                     Math.Abs(rectangle2.Left - rectangle1.Right));
            }

            return xDistance * xDistance + yDistance * yDistance;
        }

        public static float GetDistance(this Rectangle rectangle1, Rectangle rectangle2) {
            return (float)Math.Sqrt(GetDistanceSquared(rectangle1, rectangle2));
        }
    }
}
