using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                LinkedList<int> list = new LinkedList<int>();
                list.Add(1);
                list.Add(2);
                list.Add(3);
                list.Add(4);
                list.Add(6);
                list.Add(8);
                list.Add(10);
                list.Add(11);

                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();

                Console.WriteLine(list.RemoveElement(5));
                Console.WriteLine(list.GetFirstElement());
                Console.WriteLine(list.GetElement(0));
                Console.WriteLine(list.SetElement(3, 100));
                list.AddFirst(30);
                list.InsertElement(0, 40);
                Console.WriteLine(list.RemoveFirstElement());
                Console.WriteLine(list.RemoveByData(8));
                Console.WriteLine(list.GetListLength());
                list.Reverse();
                LinkedList<int> copiedList = list.Copy();

                Console.WriteLine();

                foreach (var item in copiedList)
                {
                    Console.WriteLine(item);
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
