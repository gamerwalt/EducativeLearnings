using Fundamentals;
using System;

namespace Fundamentals.OutputConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new LinkedList();

            linkedList.AddFirst(30);
            linkedList.AddFirst(20);
            linkedList.AddFirst(10);
            linkedList.AddLast(40);
            linkedList.AddLast(50);

            var arr = linkedList.ToArray();
            foreach(var item in arr)
                Console.WriteLine(item);

            Console.WriteLine("*********************");
            Console.WriteLine(linkedList.FindKthNodeFromEnd(1));
            Console.WriteLine(linkedList.FindKthNodeFromEnd(2));
            Console.WriteLine(linkedList.FindKthNodeFromEnd(3));
            Console.WriteLine(linkedList.FindKthNodeFromEnd(0));
        }
    }
}
