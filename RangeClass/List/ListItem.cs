using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class ListItem<T>
    {
        public ListItem(T data)
        {
            Data = data;
        }

        public T Data
        {
            get;
            set;
        }

        public ListItem<T> Next
        {
            get;
            set;
        }

        public override string ToString()
        {
            if (Data == null)
            {
                return string.Format("Null");
            }
            return Data.ToString();
        }
    }
}
