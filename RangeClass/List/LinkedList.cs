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
        private ListItem<T> tail;
        private int count;

        public void Add(T data) //вставка в конец
        {
            ListItem<T> listItem = new ListItem<T>(data);

            if (head == null)
            {
                head = listItem;
            }
            else
            {
                tail.Next = listItem;
            }

            tail = listItem;
            count++;
        }

        public void AddFirst(T data)
        {
            ListItem<T> listItem = new ListItem<T>(data);
            if (head == null)
            {
                head = listItem;
                tail = listItem;
            }
            else
            {
                listItem.Next = head;
                head = listItem;
            }
            count++;
        }

        public ListItem<T> RemoveElement(int index)//удаление по индексу
        {
            if (count - 1 < index)
            {
                throw new IndexOutOfRangeException("Индекс больше длины списка");
            }

            ListItem<T> removedItem = null; ;
            if (index == 0)
            {
                removedItem = head;
                head = head.Next;
                count--;
            }

            if (index == count - 1)
            {
                for (ListItem<T> i = head; index < count - 1; i = i.Next)
                {
                    if (index == count - 1)
                    {
                        removedItem = tail;
                        tail = i;
                    }
                }
                count--;
            }

            int indexCount = 0;
            for (ListItem<T> i = head; index > indexCount; i = i.Next, indexCount++)
            {
                if (index == indexCount + 1)
                {
                    removedItem = i.Next;
                    i.Next = removedItem.Next;
                    count--;
                }
            }
            return removedItem;
        }

        public int GetListLength()//длина списка
        {
            return count;
        }

        public ListItem<T> GetFirstElement()//получить первый элемент
        {
            return head;
        }

        public ListItem<T> GetElement(int index)//получение элемента по индексу
        {
            if (count - 1 < index)
            {
                throw new IndexOutOfRangeException("Индекс больше длины списка");
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

        public ListItem<T> SetElement(int index, T data)//изменение элемента по индексу
        {
            if (count - 1 < index)
            {
                throw new IndexOutOfRangeException("Индекс больше длины списка");
            }

            ListItem<T> previousData = new ListItem<T>(data);
            int indexCount = 0;
            for (ListItem<T> listElement = head; index >= indexCount; listElement = listElement.Next, indexCount++)
            {
                if (index == indexCount)
                {
                    previousData.Data = listElement.Data;
                    listElement.Data = data;
                }
            }
            return previousData;
        }

        public void InsertElement(int index, T data)//вставка по индексу
        {
            if (count - 1 < index)
            {
                throw new IndexOutOfRangeException("Индекс больше длины списка");
            }

            ListItem<T> newData = new ListItem<T>(data);

            if (index == 0)
            {
                newData.Next = head;
                head = newData;
                count++;
            }

            int indexCount = 0;
            for (ListItem<T> listElement = head; index > indexCount; listElement = listElement.Next, indexCount++)
            {
                if (index == indexCount + 1)
                {
                    newData.Next = listElement.Next;
                    listElement.Next = newData;
                    count++;
                }
            }
        }

        public ListItem<T> RemoveFirstElement()//удаалить первый элемент
        {
            ListItem<T> removedElement = new ListItem<T>(head.Data);

            if (count == 1)
            {
                head = null;
                tail = null;
            }
            else
            {
                head = head.Next;
            }
            count--;
            return removedElement;
        }

        public bool RemoveByData(T removeData)//удаление по значению
        {
            for (ListItem<T> listElement = head; listElement.Next != null; listElement = listElement.Next)
            {
                if (listElement.Data.Equals(removeData) && listElement == head)
                {
                    head = head.Next;
                    count--;
                    return true;
                }
                if (listElement.Next.Data.Equals(removeData))
                {
                    int range = 0;
                    for (ListItem<T> nextListItem = listElement; range <= 2; range++, nextListItem = nextListItem.Next)
                    {
                        if (range == 2)
                        {
                            if (nextListItem == null)
                            {
                                listElement.Next = null;
                                tail = listElement;
                                count--;
                                return true;
                            }

                            listElement.Next = nextListItem;
                            count--;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void Reverse()//разворот списка
        {
            if (count == 0 || count == 1)
            {
                return;
            }

            ListItem<T>[] arrayList = new ListItem<T>[count];
            int i = 0;

            for (ListItem<T> element = head; i < count; element = element.Next, i++)
            {
                arrayList[i] = element;
            }

            i--;
            for (ListItem<T> element = arrayList[i]; i > 0; i--)
            {
                element.Next = arrayList[i - 1];
                element = arrayList[i - 1];
            }
            head = arrayList[count - 1];
            tail = arrayList[0];
            tail.Next = null;
        }

        public LinkedList<T> Copy()  //копирование
        {
            LinkedList<T> newLinkedList = new LinkedList<T>();
            ListItem<T>[] arrayList = new ListItem<T>[count];
            int i = 0;

            for (ListItem<T> element = head; i < count; element = element.Next, i++)
            {
                arrayList[i] = element;
            }

            i = 0;
            for (ListItem<T> element = head; i < count; element = element.Next, i++)
            {
                newLinkedList.Add(arrayList[i].Data);
            }
            return newLinkedList;
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
        //методы
    }
}
