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

        public void Add(T data)
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

        public void RemoveItem(int index)
        {
            int indexCount = 0;
            for (ListItem<T> i = head; index == indexCount; i = i.Next, indexCount++)
            {

            }
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
