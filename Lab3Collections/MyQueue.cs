using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3Collections
{
    public class MyQueue<T> : BaseCollection<T> where T : notnull
    {
        private readonly int _capacity;
        private readonly bool _isInfinite;
        private Node<T>? _front;
        private Node<T>? _rear;
        public Node<T>? Front { get => _front; }
        public Node<T>? Rear { get => _rear; }

        public MyQueue() : this(int.MaxValue, false)
        {
        }

        public MyQueue(int capacity, bool isInfinite)
        {
            _capacity = capacity;
            _isInfinite = isInfinite;
        }

        public void Enqueue(T item)
        {
            if (!_isInfinite && _count >= _capacity)
                throw new InvalidOperationException("Queue overflow");

            Node<T> newNode = new Node<T>(item);
            if (_rear == null || _front == null)
            {
                _front = newNode;
                _rear = newNode;
            }
            else
            {
                Node<T> temp_front = _front;
                temp_front.Previous = newNode;
                //_rear.Next = newNode;
                _front = newNode;
                _front.Next = temp_front;
            }
            _count++;
        }

        public T Dequeue()
        {
            if (_count == 0 || _front == null)
                throw new InvalidOperationException("Queue is empty");

            T data = _front.Data;
            _front = _front.Next;
            if (_front == null)
                _rear = null;
            _count--;
            return data;
        }

        public T Peek()
        {
            if (_count == 0 || _front == null)
                throw new InvalidOperationException("Queue is empty");

            return _front.Data;
        }
        public bool Includes(T item)
        {
            var current = _front;
            while (current != null)
            {
                var curr_item = current.Data;
                if (curr_item.Equals(item)) return true;
                current = current.Previous;
            }
            return false;
        }

        public static MyQueue<T> operator *(MyQueue<T> first, MyQueue<T> second)
        {
            MyQueue<T> result = new MyQueue<T>();

            if (first.Rear == null) throw new Exception("Empty queue"); 

            Node<T>? current = first.Rear;
            while (current != null)
            {
                if (second.Includes(current.Data)) result.Enqueue(current.Data);
                current = current.Previous;
            }

            return result;
        }

        // Перегрузка оператора +
        public static MyQueue<T> operator +(MyQueue<T> first, MyQueue<T> second)
        {
            if (first.Rear == null) throw new Exception("Empty queue");

            MyQueue<T> result = new MyQueue<T>();

            Node<T>? current = first.Rear;
            while (current != null)
            {
                result.Enqueue(current.Data);
                current = current.Previous;
            }

            current = second.Rear;
            while (current != null)
            {
                result.Enqueue(current.Data);
                current = current.Previous;
            }

            return result;
        }

        // Перегрузка оператора -
        public static MyQueue<T> operator -(MyQueue<T> first, MyQueue<T> second)
        {
            MyQueue<T> result = new MyQueue<T>();

            if (first.Rear == null) throw new Exception("Empty queue");

            Node<T>? current = first.Rear;
            while (current != null)
            {
                if (!second.Includes(current.Data)) result.Enqueue(current.Data);
                current = current.Previous;
            }

            return result;
        }
        public override string ToString()
        {
            if (_front == null) return "[ ]";
            Node<T>? current = _front;
            var sb = new StringBuilder("[");

            while (current.Next != null)
            {
                sb.Append($" {current.Data}, ");
                current = current.Next;
            }
            sb.Append($" {current.Data} ]");
            return sb.ToString();
        }
    }
}
