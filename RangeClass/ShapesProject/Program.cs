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
            AreaComparer ac = new AreaComparer();

            Array.Sort(shapesArray, ac);

            return shapesArray[0].ToString();
        }

        public static string GetNextToMaxAreaShape(IShape[] shapesArray)
        {
            AreaComparer ac = new AreaComparer();

            Array.Sort(shapesArray, ac);

            return shapesArray[1].ToString();
        }

        static void Main(string[] args)
        {
            IShape c1 = new Circle(4);
            IShape r1 = new Rectangle(2, 4);
            IShape t1 = new Triangle(1, 4, 2, -2, 4, 3);
            IShape s1 = new Square(6);
            IShape c2 = new Circle(3);
            IShape r2 = new Rectangle(3, 2);
            IShape t2 = new Triangle(-1, 4, 2, -2, 4, 2);
            IShape s2 = new Square(8);

            IShape[] shapesArray = new IShape[8];

            shapesArray[0] = c1;
            shapesArray[1] = r1;
            shapesArray[2] = t1;
            shapesArray[3] = s1;
            shapesArray[4] = c2;
            shapesArray[5] = r2;
            shapesArray[6] = t2;
            shapesArray[7] = s2;

            Console.WriteLine(GetMaxAreaShape(shapesArray));

            Console.WriteLine(GetNextToMaxAreaShape(shapesArray));
        }
    }
}
