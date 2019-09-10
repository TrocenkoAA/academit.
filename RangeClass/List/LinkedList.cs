﻿using System;
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

            ListItem<T> element = null;
            int indexCount = 0;
            for (ListItem<T> listElement = head; index >= indexCount; listElement = listElement.Next, indexCount++)
            {
                if (index == indexCount)
                {
                    element = listElement;
                    break;
                }
            }
            return element;
        }

        public void Add(T data) //вставка в конец
        {
            if (data == null)
            {
                data = default(T);
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

        public void AddFirst(T data) //встаавка вперед
        {
            if (data == null)
            {
                data = default(T);
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
                RemoveFirstElement();
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
            if (Count == 0)
            {
                throw new Exception("Список пуст");
            }

            return head;
        }

        public ListItem<T> SetElement(int index, T data)//изменение элемента по индексу
        {
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
            if (index > MaxIndex || index < 0)
            {
                throw new IndexOutOfRangeException("Индекс за пределами списка");
            }

            ListItem<T> newData = new ListItem<T>(data);

            if (index == 0)
            {
                AddFirst(data);
            }
            else if (index == MaxIndex)
            {
                Add(data);
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

            head = head.Next;
            Count--;
            return removedElement;
        }

        public bool RemoveByData(T removeData)//удаление по значению
        {
            if (head.Data.Equals(removeData))
            {
                head = head.Next;
                Count--;
                return true;
            }

            int counter = 0;
            for (ListItem<T> curentElement = head, previousElement = null; counter <= MaxIndex; previousElement = curentElement, curentElement = curentElement.Next, counter++)
            {       
                if (curentElement.Data == null)
                {
                    if (removeData == null)
                    {
                        previousElement.Next = curentElement.Next;
                        curentElement.Next = null;
                        Count--;
                        return true;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (curentElement.Data.Equals(removeData))
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
