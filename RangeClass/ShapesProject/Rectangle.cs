using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesProject
{
    public class Rectangle : IShape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public double GetWidth()
        {
            return width;
        }

        public double GetHeight()
        {
            return height;
        }

        public double GetArea()
        {
            return width * height;
        }

        public double GetPerimeter()
        {
            return height * 2 + height * 2;
        }

        public override string ToString()
        {
            return string.Format("Class: rectangle, sides length: {0:f2}/{1:f2}, width: {2:f2}, height: {3:f2}, area: {4:f2}, perimeter: {5:f2}", width, height, GetWidth(), GetHeight(), GetArea(), GetPerimeter());
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
            Rectangle rectangle = (Rectangle)obj;

            return width == rectangle.width && height == rectangle.height;
        }

        public override int GetHashCode()
        {
            int prime = 7;
            int hash = 1;
            hash = prime * hash + width.GetHashCode();
            hash = prime * hash + height.GetHashCode();

            return hash;
        }


    }
}
