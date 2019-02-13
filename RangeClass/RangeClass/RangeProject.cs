using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeClass
{
    class RangeProject
    {
        static void Main(string[] args)
        {
            Range range = new Range(7, 19);
            /*range.From = 7;
            range.To = 19;*/

            Console.WriteLine("Есть диапазон чисел, длиной {0}. Попробуйте ввести число, попадающее в этот диапазон", range.GetLength());

            int number = Convert.ToInt32(Console.ReadLine());

            while (!range.IsInside(number))
            {
                if (!range.IsInside(number))
                {
                    Console.WriteLine("Попробуйте еще раз");
                    number = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine("Это число попадает в диапазон {0}-{1}", range.From, range.To);
            range.Print();
        }
    }
}
