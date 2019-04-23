using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesProject
{
    public class Triangle : IShape
    {
        private double x1;
        private double y1;
        private double x2;
        private double y2;
        private double x3;
        private double y3;

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;
        }

        private static double GetSideLength(double xFirstPoint, double xSecondPoint, double yFirstPoint, double ySecondPoint)
        {
            return Math.Sqrt(Math.Pow(xFirstPoint - xSecondPoint, 2) + Math.Pow(yFirstPoint - ySecondPoint, 2));
        }

        private static double GetMin(double x1, double x2, double x3)
        {
            return Math.Min(x1, Math.Min(x2, x3));
        }

        private static double GetMax(double x1, double x2, double x3)
        {
            return Math.Max(x1, Math.Max(x2, x3));
        }

        public double GetWidth()
        {
            return GetMax(x1, x2, x3) - GetMin(x1, x2, x3);
        }

        public double GetHeight()
        {
            return GetMax(y1, y2, y3) - GetMin(y1, y2, y3);
        }

        public double GetArea()
        {
            double halfPerimeter = GetPerimeter() / 2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - GetSideLength(x1, x2, y1, y2)) * (halfPerimeter - GetSideLength(x2, x3, y2, y3)) * (halfPerimeter - GetSideLength(x3, x1, y3, y1)));
        }

        public double GetPerimeter()
        {
            return GetSideLength(x1, x2, y1, y2) + GetSideLength(x2, x3, y2, y3) + GetSideLength(x3, x1, y3, y1);
        }

        public override string ToString()
        {
            return string.Format("Class: triangle, point 1: ({0:f2};{1:f2}), point 2: ({2:f2};{3:f2}), point 3: ({4:f2};{5:f2}) width: {6:f2}, height: {7:f2}, area: {8:f2}, perimeter: {9:f2}", x1, y1, x2, y2, x3, y3, GetWidth(), GetHeight(), GetArea(), GetPerimeter());
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }
            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }
            Triangle triangle = (Triangle)obj;

            return x1 == triangle.x1 && x2 == triangle.x2 && x3 == triangle.x3 && y1 == triangle.y1 && y2 == triangle.y2 && y3 == triangle.y3;
        }

        public override int GetHashCode()
        {
            int prime = 7;
            int hash = 1;
            hash = prime * hash + x1.GetHashCode();
            hash = prime * hash + x2.GetHashCode();
            hash = prime * hash + x3.GetHashCode();
            hash = prime * hash + y1.GetHashCode();
            hash = prime * hash + y2.GetHashCode();
            hash = prime * hash + y3.GetHashCode();

            return hash;
        }


    }
}
