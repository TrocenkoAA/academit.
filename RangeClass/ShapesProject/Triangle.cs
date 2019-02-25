using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesProject
{
    public class Triangle : IShape
    {
        private double SideLength1(double x1, double x2, double y1, double y2)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(x1 - x2), 2) + Math.Pow(Math.Abs(y1 - y2), 2));
        }

        private double SideLength2(double x2, double x3, double y2, double y3)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(x2 - x3), 2) + Math.Pow(Math.Abs(y2 - y3), 2));
        }

        private double SideLength3(double x1, double x3, double y1, double y3)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(x3 - x1), 2) + Math.Pow(Math.Abs(y3 - y1), 2));
        }

        private double GetMin(double x1, double x2, double x3)
        {
            double[] array = new double[] { x1, x2, x3 };
            for (int i = 0; i < array.Length - 1; i++)
            {
                double min = array[i];
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < min)
                    {
                        min = array[j];
                        minIndex = j;
                    }
                }
                array[minIndex] = array[i];
                array[i] = min;
            }
            return array[0];
        }

        private double GetMax(double x1, double x2, double x3)
        {
            double[] array = new double[] { x1, x2, x3 };
            for (int i = 0; i < array.Length - 1; i++)
            {
                double max = array[i];
                int maxIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] > max)
                    {
                        max = array[j];
                        maxIndex = j;
                    }
                }
                array[maxIndex] = array[i];
                array[i] = max;
            }
            return array[0];
        }

        private double x1, y1, x2, y2, x3, y3;

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;
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
            double halfPerimeter = (SideLength1(x1, x2, y1, y2) + SideLength2(x2, x3, y2, y3) + SideLength3(x3, x1, y3, y1)) / 2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - SideLength1(x1, x2, y1, y2)) * (halfPerimeter - SideLength2(x2, x3, y2, y3)) * (halfPerimeter - SideLength3(x3, x1, y3, y1)));
        }

        public double GetPerimeter()
        {
            return SideLength1(x1, x2, y1, y2) + SideLength2(x2, x3, y2, y3) + SideLength3(x3, x1, y3, y1);
        }

        public override string ToString()
        {
            return string.Format("Class: triangle, width: {0:f2}, height: {1:f2}, area: {2:f2}, perimeter: {3:f2}", GetWidth(), GetHeight(), GetArea(), GetPerimeter());
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
