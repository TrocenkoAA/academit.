using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeClass
{
    public class Range
    {
        public int From
        {
            get;
            set;
        }
        public int To
        {
            get;
            set;
        }

        public int GetLength()
        {
            return To - From;
        }

        public bool IsInside(int yourNumber)
        {
            return (yourNumber >= From && yourNumber <= To);
        }

        public void Print()
        {
            Console.WriteLine("{0}, {1}", From, To);
        }
    }
}
