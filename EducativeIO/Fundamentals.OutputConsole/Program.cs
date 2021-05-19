using Fundamentals;
using System;

namespace Fundamentals.OutputConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree();
            tree.Insert(7);
            tree.Insert(4);
            tree.Insert(9);
            tree.Insert(1);
            tree.Insert(6);
            tree.Insert(8);
            tree.Insert(10);

            Console.WriteLine(tree.Find(20));
        }
    }
}
