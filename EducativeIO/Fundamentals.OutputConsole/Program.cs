using Fundamentals;
using System;

namespace Fundamentals.OutputConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree();
            tree.Root = new Tree.Node(20);
            tree.Root.LeftChild = new Tree.Node(10);
            tree.Root.LeftChild.LeftChild = new Tree.Node(6);
            tree.Root.LeftChild.LeftChild.LeftChild = new Tree.Node(3);
            tree.Root.LeftChild.LeftChild.RightChild = new Tree.Node(8);
            tree.Root.LeftChild.RightChild = new Tree.Node(21);
            tree.Root.RightChild = new Tree.Node(30);
            tree.Root.RightChild.LeftChild = new Tree.Node(4);

            tree.Traverse_BFS();
        }
    }
}
