using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeClass
{
    public class Range
    {
        private double from;
        private double to;             

        public Range(double from, double to)
        {
            this.from = from;
            this.to = to;
        }

        public double From
        {
            get
            {
                return from;
            }
            set
            {
                from = From;
            }
        }
        public double To
        {
            get
            {
                return to;
            }
            set
            {
                to = To;
            }
        }

        public double GetLength()
        {
            return to - from;
        }

        public bool IsInside(double number)
        {
            return (number >= from && number <= To);
        }

        public void Print()
        {
            Console.WriteLine("{0}, {1}", From, To);
        }
    }
}
