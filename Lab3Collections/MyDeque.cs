using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab3Collections 
{
  public class MyDeque<T> : IEnumerable<T>
    {
        Node<T> head; 
        Node<T> tail; 
        int count; 
 
        
        public void AddLast(T data)
        {
            Node<T> node = new Node<T>(data);
 
            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }
        public void AddFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.Previous = node;
            count++;
        }
        public T RemoveFirst()
        {
            if (count == 0)
                throw new InvalidOperationException();
            T output = head.Data;
            if(count==1)
            {
                head = tail = null;
            }
            else
            {
                head = head.Next;
                head.Previous = null;
            }
            count--;
            return output;
        }
        public T RemoveLast()
        {
            if (count == 0)
                throw new InvalidOperationException();
            T output = tail.Data;
            if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                tail = tail.Previous;
                tail.Next = null;
            }
            count--;
            return output;
        }
        public T First
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return head.Data;
            }
        }
        public T Last
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return tail.Data;
            }
        }
 
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
 
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
 
        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }
 
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
 
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

         public override string ToString()
        {
            var sb = new StringBuilder("[");

            foreach (T s in this)
            {
                sb.Append(s.ToString());
                sb.Append(",");
            }

            sb.Append("]");
            return sb.ToString();
        }

         public static MyDeque<T> operator *(MyDeque<T> first, MyDeque<T> second)
        {
            MyDeque<T> result = new MyDeque<T>();

            if (first.head == null) throw new Exception("Empty deque"); 

            Node<T>? current = first.head;
            while (current != null)
            {
                if (second.Contains(current.Data)) result.AddFirst(current.Data);
                current = current.Previous;
            }

            return result;
        }

         public static MyDeque<T> operator +(MyDeque<T> first, MyDeque<T> second)
        {
            MyDeque<T> result = new MyDeque<T>();
                        Node<T>? current = first.head ?? throw new Exception("Empty deque");

            while (current != null)
            {
                result.AddFirst(current.Data);
                current = current.Next;
            }

            if (second.head == null) return result;
            
            current = second.head;
            while (current != null)
            {
                result.AddFirst(current.Data);
                current = current.Next;
            }

            return result;
        }

        public static MyDeque<T> operator -(MyDeque<T> first, MyDeque<T> second)
        {
            MyDeque<T> result = new MyDeque<T>();

            if (first.head == null) throw new Exception("Empty deque");

            Node<T>? current = first.head;
            while (current != null)
            {
                if (!second.Contains(current.Data)) result.AddFirst(current.Data);
                current = current.Previous;
            }

            return result;
        }
    }
}
