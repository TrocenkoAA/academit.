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
                return "Null";
            }
            return Data.ToString();
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            ListItem<T> item = (ListItem<T>)obj;
            if (item.Data == null && Data == null)
            {
                return true;
            }
            return (dynamic)item.Data == (dynamic)Data;
        }
    }
}
