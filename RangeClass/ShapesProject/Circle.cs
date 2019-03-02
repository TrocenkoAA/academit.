using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesProject
{
    class Circle : IShape, IComparable<IShape>
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double GetWidth()
        {
            return radius * 2;
        }

        public double GetHeight()
        {
            return radius * 2;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public override string ToString()
        {
            return string.Format("Class: circle, radius: {0:f2} width: {1:f2}, height: {2:f2}, area: {3:f2}, perimeter: {4:f2}", radius, GetWidth(), GetHeight(), GetArea(), GetPerimeter());
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
            Circle circle = (Circle)obj;
            return radius == circle.radius;
        }

        public override int GetHashCode()
        {
            int prime = 7;
            int hash = 1;
            hash = prime * hash + radius.GetHashCode();

            return hash;
        }

        public int CompareTo(IShape obj)
        {
            if (GetArea() < obj.GetArea())
            {
                return 1;
            }
            if (GetArea() > obj.GetArea())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
