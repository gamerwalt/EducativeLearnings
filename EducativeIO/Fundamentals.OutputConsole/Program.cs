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

            var tree2 = new Tree();
            tree2.Insert(5);
            tree2.Insert(4);
            tree2.Insert(9);
            tree2.Insert(1);
            tree2.Insert(6);
            tree2.Insert(8);
            tree2.Insert(10);

            Console.WriteLine(tree.Equals(tree2));
        }
    }
}
