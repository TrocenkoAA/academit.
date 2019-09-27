using System;
using System.Collections.Generic;
using System.Collections;


namespace List
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private ListItem<T> head;

        public LinkedList()
        {

        }

        public LinkedList(int capacity)
        {
            int i = 0;
            while (i < capacity)
            {
                AddFirst(default(T));
                i++;
            }
        }

        public int Count
        {
            get;
            private set;
        }

        private int MaxIndex
        {
            get
            {
                return Count - 1;
            }
        }

        private static void DataCopy(ListItem<T> inputItem, ListItem<T> outputItem)
        {
            while (inputItem != null)
            {
                outputItem.Data = inputItem.Data;
                inputItem = inputItem.Next;
                outputItem = outputItem.Next;
            }
        }

        public ListItem<T> GetElement(int index)//получение элемента по индексу
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException("Индекс за границами списка");
            }

            int i = 0;
            ListItem<T> listElement = head;

            while (index != i)
            {
                listElement = listElement.Next;
                i++;
            }
            return listElement;
        }

        public void Add(T data) //вставка в конец
        {
            ListItem<T> listItem = new ListItem<T>(data);

            if (head == null)
            {
                head = listItem;
            }
            else
            {
                GetElement(MaxIndex).Next = listItem;
            }
            Count++;
        }

        public void ClearAll()
        {
            Count = 0;
            head = null;
        }// очистить список

        public void AddFirst(T data) //встаавка вперед
        {
            ListItem<T> listItem = new ListItem<T>(data);
            if (head == null)
            {
                head = listItem;
            }
            else
            {
                listItem.Next = head;
                head = listItem;
            }
            Count++;
        }

        public T RemoveElement(int index)//удаление по индексу
        {
            if (Count == 0)
            {
                throw new NullReferenceException("Список пуст");
            }
            if (index > MaxIndex || index < 0)
            {
                throw new IndexOutOfRangeException("Индекс за пределами списка");
            }
            if (index == 0)
            {
                return RemoveFirstElement();
            }

            ListItem<T> previousItem = GetElement(index - 1);
            ListItem<T> removedItem = previousItem.Next;
            previousItem.Next = removedItem.Next;
            Count--;
            return removedItem.Data;
        }

        public T GetFirstElement()//получить первый элемент
        {
            if (Count == 0)
            {
                throw new NullReferenceException("Список пуст");
            }

            return head.Data;
        }

        public T SetElement(int index, T data)//изменение элемента по индексу
        {
            if (Count == 0)
            {
                throw new NullReferenceException("Список пуст");
            }
            if (index > MaxIndex || index < 0)
            {
                throw new IndexOutOfRangeException("Индекс за пределами списка");
            }

            ListItem<T> indexElement = GetElement(index);
            T previousData = indexElement.Data;
            indexElement.Data = data;
            return previousData;
        }

        public void InsertElement(int index, T data)//вставка по индексу
        {
            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException("Индекс за пределами списка");
            }
            if (Count == 0 && index != 0)
            {
                throw new NullReferenceException("Список пуст");
            }

            if (index == 0)
            {
                AddFirst(data);
            }
            else if (index == Count)
            {
                Add(data);
            }
            else
            {
                ListItem<T> newData = new ListItem<T>(data);
                ListItem<T> lastElement = GetElement(index - 1);
                newData.Next = lastElement.Next;
                lastElement.Next = newData;
                Count++;
            }
        }

        public T RemoveFirstElement()//удаалить первый элемент
        {
            if (Count == 0)
            {
                throw new NullReferenceException("Список пуст");
            }

            T removedData = head.Data;

            head = head.Next;
            Count--;
            return removedData;
        }

        public bool RemoveByData(T removeData)//удаление по значению
        {
            if (Count == 0)
            {
                throw new NullReferenceException("Список пуст");
            }

            if (Equals(head.Data, removeData))
            {
                head = head.Next;
                Count--;
                return true;
            }

            ListItem<T> currentElement = head.Next;
            while (currentElement != null)
            {
                if (Equals(currentElement.Next.Data, removeData))
                {
                    ListItem<T> removedLink = currentElement.Next;
                    currentElement.Next = removedLink.Next;
                    Count--;
                    return true;
                }
                currentElement = currentElement.Next;
            }
            return false;
        }

        public void Reverse()//разворот списка
        {
            ListItem<T> element = head;
            ListItem<T> previousElement = null;

            while (element != null)
            {
                ListItem<T> nextElement = element.Next;

                element.Next = previousElement;
                previousElement = element;
                head = element;

                element = nextElement;
            }
        }

        /*public static void Copy(LinkedList<T> inputList, LinkedList<T> outputList)  //копирование
        {
            if (inputList.Count > outputList.Count)
            {
                outputList.ClearAll();
                int i = 0;
                while (i < inputList.Count)
                {
                    outputList.AddFirst(default(T));
                    i++;
                }
                DataCopy(inputList.head, outputList.head);
            }
            else
            {
                DataCopy(inputList.head, outputList.head);
            }
        }*/

        public LinkedList<T> Copy()//копированик другой вариант
        {
            LinkedList<T> newList = new LinkedList<T>(Count);

            DataCopy(head, newList.head);
            return newList;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListItem<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
