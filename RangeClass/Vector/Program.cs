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
                //Vector v9 = new Vector(0);


                v1.VectorSubtract(v2);
                Console.WriteLine(v1.ToString());

                v5.VectorAdd(v2);
                Console.WriteLine(v5.ToString());

                v6.ScalarMuliyply(5);
                Console.WriteLine(v6.ToString());

                v2.VectorInvert();
                Console.WriteLine(v2.ToString());

                Console.WriteLine(v3.GetVectorLength());

                Console.WriteLine(v3.GetComponent(3));

                v3.SetComponent(3, 6);
                Console.WriteLine(v3.ToString());

                Console.WriteLine(v7.Equals(v8));

                Vector vector1 = Vector.GetNewVectorSumm(v6, v8);
                Console.WriteLine(vector1.ToString());

                Vector vector2 = Vector.GetNewVectorDifference(v3, v7);
                Console.WriteLine(vector2.ToString());

                double result = Vector.GetScalarMultiplicate(v1, v2);
                Console.WriteLine(result);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
