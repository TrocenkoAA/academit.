using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private ListItem<T> head;

        public int Count
        {
            get;
            private set;
        }
        public int MaxIndex
        {
            get
            {
                int maxIndex = Count - 1;
                return maxIndex;
            }
        }

        public ListItem<T> GetElement(int index)//получение элемента по индексу
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException("Индекс за границами списка");
            }

            ListItem<T> element = null;
            int indexCount = 0;
            for (ListItem<T> listElement = head; index >= indexCount; listElement = listElement.Next, indexCount++)
            {
                if (index == indexCount)
                {
                    element = listElement;
                }
            }
            return element;
        }

        public void Add(T data) //вставка в конец
        {
            if (data == null)
            {
                throw new ArgumentNullException("Значение null");
            }

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

        public void AddFirst(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("Значение null");
            }

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

        public ListItem<T> RemoveElement(int index)//удаление по индексу
        {
            if (index > MaxIndex || index < 0)
            {
                throw new IndexOutOfRangeException("Индекс за пределами списка");
            }

            ListItem<T> removedItem = null;
            if (index == 0)
            {
                removedItem = head;
                head = head.Next;
                Count--;
            }
            else if (index == MaxIndex)
            {
                removedItem = GetElement(index);
                GetElement(index - 1).Next = null;
                Count--;
            }
            else
            {
                removedItem = GetElement(index);
                GetElement(index - 1).Next = GetElement(index + 1);
                Count--;
            }
            return removedItem;
        }

        public ListItem<T> GetFirstElement()//получить первый элемент
        {
            return head;
        }

        public ListItem<T> SetElement(int index, T data)//изменение элемента по индексу
        {
            if (data == null)
            {
                throw new ArgumentNullException("Значение null");
            }

            if (index > MaxIndex || index < 0)
            {
                throw new IndexOutOfRangeException("Индекс за пределами списка");
            }

            ListItem<T> previousData = new ListItem<T>(data);
            previousData.Data = GetElement(index).Data;
            GetElement(index).Data = data;
            return previousData;
        }

        public void InsertElement(int index, T data)//вставка по индексу
        {
            if (data == null)
            {
                throw new ArgumentNullException("Значение null");
            }

            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException("Индекс за пределами списка");
            }

            ListItem<T> newData = new ListItem<T>(data);

            if (index == 0)
            {
                newData.Next = head;
                head = newData;
                Count++;
            }
            else if (index == Count)
            {
                GetElement(MaxIndex).Next = newData;
                Count++;
            }
            else
            {
                newData.Next = GetElement(index);
                GetElement(index - 1).Next = newData;
                Count++;
            }
        }

        public ListItem<T> RemoveFirstElement()//удаалить первый элемент
        {
            if (Count == 0)
            {
                throw new Exception("Список пуст");
            }

            ListItem<T> removedElement = new ListItem<T>(head.Data);

            if (Count == 1)
            {
                head = null;
                Count--;
            }
            else
            {
                head = head.Next;
                Count--;
            }
            return removedElement;
        }

        public bool RemoveByData(T removeData)//удаление по значению
        {
            if (removeData == null)
            {

            }
            int counter = 0;

            for (ListItem<T> listElement = head; counter < Count; listElement = listElement.Next, counter++)
            {
                if (listElement.Data.Equals(removeData) && listElement == head)
                {
                    head = head.Next;
                    Count--;
                    return true;
                }

                if (listElement.Next.Data.Equals(removeData))
                {
                    if (counter + 2 > MaxIndex)
                    {
                        listElement.Next = null;
                        Count--;
                        return true;
                    }

                    listElement.Next = GetElement(counter + 2);
                    Count--;
                    return true;
                }
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

        public LinkedList<T> Copy()  //копирование
        {
            ListItem<T> element = head;
            LinkedList<T> newList = new LinkedList<T>();

            while (element != null)
            {
                newList.Add(element.Data);
                element = element.Next;
            }
            return newList;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
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
