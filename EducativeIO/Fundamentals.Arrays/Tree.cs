using System;
using System.Collections.Generic;
using System.Text;

namespace Fundamentals
{
    public class Tree
    {
        private Node Root;

        public void Insert(int value)
        {
            var node = new Node(value);

            if(Root == null)
            {
                Root = node;
                return;
            }

            Insert(Root, value);
        }

        public bool Find(int value)
        {
            return Find(Root, value);
        }

        private bool Find(Node node, int value)
        {
            if (node == null) return false;

            if (node.Value == value) return true;

            if (value > node.Value)
                return Find(node.RightChild, value);
            else
                return Find(node.LeftChild, value);
        }

        private Node Insert(Node node, int value)
        {
            if(node == null)
            {
                var nodeToInsert = new Node(value);
                node = nodeToInsert;
                return node;
            }

            if(value > node.Value)
            {
                node.RightChild = Insert(node.RightChild, value);
            }
            else
            {
                node.LeftChild = Insert(node.LeftChild, value);
            }

            return node;
        }

        public void Traverse_DFS_PreOrder()
        {
            Traverse_DFS_PreOrder(Root);
        }

        private void Traverse_DFS_PreOrder(Node node)
        {
            if (node == null) return;

            Console.WriteLine(node.Value);
            Traverse_DFS_PreOrder(node.LeftChild);
            Traverse_DFS_PreOrder(node.RightChild);
        }

        public void Traverse_DFS_InOrder()
        {
            Traverse_DFS_InOrder(Root);
        }

        private void Traverse_DFS_InOrder(Node node)
        {
            if (node == null) return;

            Traverse_DFS_InOrder(node.LeftChild);
            Console.WriteLine(node.Value);
            Traverse_DFS_InOrder(node.RightChild);
        }

        public void Traverse_DFS_PostOrder()
        {
            Traverse_DFS_PostOrder(Root);
        }

        private void Traverse_DFS_PostOrder(Node node)
        {
            if (node == null) return;

            Traverse_DFS_PostOrder(node.LeftChild);
            Traverse_DFS_PostOrder(node.RightChild);
            Console.WriteLine(node.Value);
        }

        public void Traverse_BFS()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(Root.Value);

            Traverse_BFS(Root, queue);
        }

        private void Traverse_BFS(Node node, Queue<int> queue)
        {
            if (node == null) return;
            if (node.LeftChild != null)
                queue.Enqueue(node.LeftChild.Value);
            if (node.RightChild != null)
                queue.Enqueue(node.RightChild.Value);

            Traverse_BFS(node.LeftChild, queue);
            Traverse_BFS(node.RightChild, queue);

            if(queue.Count > 0)
                Console.WriteLine(queue.Dequeue());
        }

        private class Node
        {
            public int Value;
            public Node LeftChild;
            public Node RightChild;

            public Node(int value)
            {
                Value = value;
            }

            public override string ToString()
            {
                return Value.ToString();
            }
        }
    }
}
