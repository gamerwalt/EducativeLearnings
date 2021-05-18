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

            linkedList.Reverse();
            arr = linkedList.ToArray();
            Console.WriteLine("______________");
            foreach(var item in arr)
                Console.WriteLine(item);
        }
    }
}
