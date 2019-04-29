using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesProject
{
    class Program
    {
        public static string GetMaxAreaShape(IShape[] shapesArray)
        {
            var areaComparer = new AreaComparer();
            Array.Sort(shapesArray, areaComparer);
            return shapesArray[0].ToString();
        }

        public static string GetNextToMaxPerimeterShape(IShape[] shapesArray)
        {
            var perimeterComparer = new PerimeterComparer();
            Array.Sort(shapesArray, perimeterComparer);
            return shapesArray[1].ToString();
        }

        static void Main(string[] args)
        {
            IShape[] shapesArray = new IShape[] { new Circle(4), new Rectangle(2, 4), new Triangle(1, 4, 2, -2, 4, 3), new Square(6), new Circle(3), new Rectangle(3, 2), new Triangle(-1, 4, 2, -2, 4, 2), new Square(8) };

            Console.WriteLine("Max area shape: {0}",GetMaxAreaShape(shapesArray));

            Console.WriteLine();

            Console.WriteLine("Previous to max perimeter shape: {0}",GetNextToMaxPerimeterShape(shapesArray));
        }
    }
}
