using System;


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
                list.Add("ноль");
                list.Add("один");
                list.Add("два");
                list.Add("три");
                list.Add("четыре");
                list.Add(null);
                list.Add("шесть");
                list.Add(null);
                list.Add("восемь");

                LinkedList<string> listCopy = new LinkedList<string>();
                listCopy.Add(null);
                listCopy.Add(null);
                listCopy.Add(null);
                listCopy.Add(null);
                listCopy.Add(null);
                listCopy.Add(null);
                listCopy.Add(null);
                listCopy.Add(null);

                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();

                Console.WriteLine(list.RemoveElement(0));
                Console.WriteLine(list.GetFirstElement());
                Console.WriteLine(list.GetElement(5));
                Console.WriteLine(list.SetElement(6, "изменение"));
                list.AddFirst("теперь первый");
                list.InsertElement(6, "вставка");
                Console.WriteLine(list.RemoveFirstElement());
                Console.WriteLine(list.RemoveByData("восемь"));
                Console.WriteLine(list.Count);
                list.Reverse();
                list.Copy(listCopy);

                Console.WriteLine();

                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();

                foreach (var item in listCopy)
                {
                    Console.WriteLine(item);
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
