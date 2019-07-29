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
                /*LinkedList<int> list = new LinkedList<int>();
                list.Add(1);
                list.Add(2);
                list.Add(3);
                list.Add(4);
                list.Add(6);
                list.Add(8);
                list.Add(10);
                list.Add(11);*/

                LinkedList<string> list = new LinkedList<string>();
                list.Add("раз");
                list.Add("два");
                list.Add("три");
                list.Add("четыре");
                list.Add(null);
                list.Add("пять");
                list.Add(null);
                list.Add("шесть");

                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();

                Console.WriteLine(list.RemoveElement(4));
                Console.WriteLine(list.GetFirstElement());
                Console.WriteLine(list.GetElement(0));
                Console.WriteLine(list.SetElement(3, "изменение"));
                list.AddFirst("теперь первый");
                list.InsertElement(2, "вставка");
                Console.WriteLine(list.RemoveFirstElement());
                Console.WriteLine(list.RemoveByData(null));
                Console.WriteLine(list.Count);
                //list.Reverse();
                //LinkedList<int> copiedList = list.Copy();

                Console.WriteLine();

                foreach (var item in list)
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
