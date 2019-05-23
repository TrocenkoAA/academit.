using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Vector v1 = new Vector(7, new double[] { 1, 4, 2, 4 });
                Vector v2 = new Vector(new double[] { 4, 2, 5, 1 });
                Vector v3 = new Vector(v2);
                Vector v4 = new Vector(4);
                Vector v5 = new Vector(4, new double[] { 4, 3, 2, 1 });
                Vector v6 = new Vector(4, new double[] { 1, 2, 3, 4 });
                Vector v7 = new Vector(new double[] { 1, 2, 3, 4, 5, 6 });
                Vector v8 = new Vector(new double[] { 6, 5, 4, 3, 2, 1 });
                Vector v10 = new Vector(4, new double[] { 1, 2, 3, 4, 5, 6, 7 });
                Vector v11 = new Vector(new double[] { 1, 2, 3, 4 });
                //Vector v9 = new Vector(0);


                v1.Substract(v2);
                Console.WriteLine(v1);

                v2.Add(v7);
                Console.WriteLine(v2);

                v5.Add(v2);
                Console.WriteLine(v5);

                v6.ScalarMultiply(5);
                Console.WriteLine(v6);

                v2.Invert();
                Console.WriteLine(v2);

                Console.WriteLine(v3.GetLength());

                Console.WriteLine(v3.GetComponent(3));

                v3.SetComponent(3, 6);
                Console.WriteLine(v3);

                Console.WriteLine(v7.Equals(v8));
                Console.WriteLine(v10.Equals(v11));

                Vector vector1 = Vector.GetSum(v6, v8);
                Console.WriteLine(vector1);

                Vector vector2 = Vector.GetDifference(v3, v7);
                Console.WriteLine(vector2);

                double result = Vector.GetScalarMultiplication(v1, v2);
                Console.WriteLine(result);

                Console.WriteLine(v10);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
