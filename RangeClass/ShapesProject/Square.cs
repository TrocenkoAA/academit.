using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesProject
{
    public class Square : IShape
    {
        private double sideLength;

        public Square(double sideLength)
        {
            this.sideLength = sideLength;
        }

        public double GetWidth()
        {
            return sideLength;
        }

        public double GetHeight()
        {
            return sideLength;
        }

        public double GetArea()
        {
            return Math.Pow(sideLength, 2);
        }

        public double GetPerimeter()
        {
            return sideLength * 4;
        }

        public override string ToString()
        {
            return string.Format("Class: square, width: {0:f2}, height: {1:f2}, area: {2:f2}, perimeter: {3:f2}", GetWidth(), GetHeight(), GetArea(), GetPerimeter());
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
            Square square = (Square)obj;
            return sideLength == square.sideLength;
        }

        public override int GetHashCode()
        {
            int prime = 7;
            int hash = 1;
            hash = prime * hash + sideLength.GetHashCode();
            hash = prime * hash + GetArea().GetHashCode();
            return hash;
        }
    }
}
