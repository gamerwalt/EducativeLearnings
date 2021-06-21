using Fundamentals;
using System;

namespace Fundamentals.OutputConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new MyStack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine(stack.Top());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Empty());
        }
    }
}
