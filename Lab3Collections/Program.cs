using System.Security.Cryptography;

namespace Lab3Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var q = new MyQueue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            Console.WriteLine($"{q}\n");
            var q2 = new MyQueue<int>();
            q2.Enqueue(2);
            q2.Enqueue(4);
            Console.WriteLine($"{q2}\n");
            MyQueue<int> q3 = q * q2;
            Console.WriteLine($"{q3}\n");
        }
        static void TestStack()
        {
            var s = new MyStack<int>();
            s.Push(1);
            s.Push(2);
            Console.WriteLine($"{s}\n");
            var s2 = new MyStack<int>();
            s2.Push(1);
            s2.Push(4);
            Console.WriteLine($"{s2}\n");
            MyStack<int> s3 = s + s2;
            Console.WriteLine($"{s3}\n");
        }
    }
}
