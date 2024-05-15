using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab3Collections
{
    public class Node<T> where T : notnull
    {
        public T Data { get; }
        public Node<T>? Next { get; set; }
        public Node<T>? Previous { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
            Previous = null;
        }
    }
    public class MyStack<T> : BaseCollection<T> where T: notnull
    {
        private readonly int _capacity;
        private readonly bool _isInfinite;
        private Node<T>? _top;
        public Node<T>? Top { get => _top; }

        public MyStack() : this(int.MaxValue, false)
        {
        }

        public MyStack(int capacity, bool isInfinite)
        {
            _capacity = capacity;
            _isInfinite = isInfinite;
        }

        public void Push(T item)
        {
            if (!_isInfinite && _count >= _capacity)
                throw new InvalidOperationException("MyStack overflow");

            Node<T> newNode = new Node<T>(item);
            newNode.Next = _top;
            _top = newNode;
            _count++;
        }

        public T Pop()
        {
            if (_top == null || _count == 0)
                throw new InvalidOperationException("MyStack is empty");

            T data = _top.Data;
            _top = _top?.Next ?? null;
            _count--;
            return data;
        }

        public T Peek()
        {
            if (_top == null || _count == 0)
                throw new InvalidOperationException("MyStack is empty");

            return _top.Data;
        }
        public bool Includes(T item)
        {
            var current = _top;
            while (current != null)
            {
                var curr_item = current.Data;
                if (curr_item.Equals(item)) return true;
                current = current.Next;
            }
            return false;
        }
        public static MyStack<T> operator *(MyStack<T> first, MyStack<T> second)
        {
            MyStack<T> result = new MyStack<T>();
            //MyStack<T> secondAsMyStack = second as MyStack<T>;
            //if (secondAsMyStack == null)
                //throw new ArgumentException("The second operand must be a MyStack<T>");

            //HashSet<T> commonElements = new HashSet<T>();
            Node<T>? current = first.Top;
            while (current != null)
            {
                if (second.Includes(current.Data)) result.Push(current.Data);
                current = current.Next;
            }

            return result;
        }

        // Перегрузка оператора +
        public static MyStack<T> operator +(MyStack<T> first, MyStack<T> second)
        {
            MyStack<T> result = new MyStack<T>();

            Node<T>? current = first.Top ?? throw new Exception("Empty stack");

            while (current != null)
            {
                result.Push(current.Data);
                current = current.Next;
            }

            //MyStack<T> secondAsMyStack = second as MyStack<T>;

            if (second.Top == null) return result;
            current = second.Top;
            while (current != null)
            {
                result.Push(current.Data);
                current = current.Next;
            }

            return result;
        }

        // Перегрузка оператора -
        public static MyStack<T> operator -(MyStack<T> first, MyStack<T> second)
        {
            MyStack<T> result = new MyStack<T>();

            if (first.Top == null) return result;
            Node<T>? current = first.Top;

            while (current != null)
            {
                T data = current.Data;
                if (!second.Includes(data)) result.Push(data);
                current = current.Next;
            }

            return result;
        }
        public override string ToString()
        {
            if (_top == null) return "[ ]";
            Node<T> current = _top;
            var sb = new StringBuilder("[");

            while (current.Next != null)
            {
                sb.Append($" {current.Data},\n ");
                current = current.Next;
            }
            sb.Append($" {current.Data} ]");
            return sb.ToString();
        }
    }
}
