using System;
using System.Collections.Generic;
using System.Collections;


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

        private int MaxIndex
        {
            get
            {
                return Count - 1;
            }
        }

        public ListItem<T> GetElement(int index)//получение элемента по индексу
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException("Индекс за границами списка");
            }

            int i = 0;
            for (ListItem<T> listElement = head; index >= i; listElement = listElement.Next, i++)
            {
                if (index == i)
                {
                    return listElement;
                }
            }
            return null;
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
            if (index > MaxIndex || index < 0)
            {
                throw new IndexOutOfRangeException("Индекс за пределами списка");
            }

            ListItem<T> removedItem = null;
            if (index == 0)
            {
                return RemoveFirstElement();
            }
            else
            {
                ListItem<T> previousItem = GetElement(index - 1);
                removedItem = previousItem.Next;
                previousItem.Next = removedItem.Next;
                Count--;
            }
            return removedItem.Data;
        }

        public T GetFirstElement()//получить первый элемент
        {
            if (Count == 0)
            {
                throw new Exception("Список пуст");
            }

            return head.Data;
        }

        public T SetElement(int index, T data)//изменение элемента по индексу
        {
            if (index > MaxIndex || index < 0)
            {
                throw new IndexOutOfRangeException("Индекс за пределами списка");
            }

            T previousData = GetElement(index).Data;
            GetElement(index).Data = data;
            return previousData;
        }

        public void InsertElement(int index, T data)//вставка по индексу
        {
            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException("Индекс за пределами списка");
            }

            ListItem<T> newData = new ListItem<T>(data);

            if (index == 0)
            {
                AddFirst(data);
            }
            else if (index > MaxIndex)
            {
                Add(data);
            }
            else
            {
                ListItem<T> lastElement = GetElement(index - 1);
                newData.Next = lastElement.Next;
                lastElement.Next = newData;
            }
            Count++;
        }

        public T RemoveFirstElement()//удаалить первый элемент
        {
            if (Count == 0)
            {
                throw new Exception("Список пуст");
            }

            T removedElement = head.Data;

            head = head.Next;
            Count--;
            return removedElement;
        }

        public bool RemoveByData(T removeData)//удаление по значению
        {
            if (Count == 0)
            {
                throw new Exception("Список пуст");
            }

            ListItem<T> removedObject = new ListItem<T>(removeData);

            if (head.Equals(removedObject))
            {
                head = head.Next;
                Count--;
                return true;
            }

            int i = 1;
            for (ListItem<T> curentElement = GetElement(i), previousElement = head; i <= MaxIndex; previousElement = curentElement, curentElement = curentElement.Next, i++)
            {
                if (curentElement.Equals(removedObject))
                {
                    previousElement.Next = curentElement.Next;
                    curentElement.Next = null;
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

        public void Copy(LinkedList<T> newList)  //копирование
        {
            if (newList.Count != Count)
            {
                throw new IndexOutOfRangeException("Размеры списков не равны");
            }
            ListItem<T> element = head;
            ListItem<T> copiedElement = newList.head;

            while (element != null)
            {
                copiedElement.Data = element.Data;
                element = element.Next;
                copiedElement = copiedElement.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
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
