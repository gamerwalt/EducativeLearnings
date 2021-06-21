using System;
using System.Collections.Generic;
using System.Text;

namespace Fundamentals
{
    public class Tree
    {
        private int BuildTreeCounter;
        public Node Root { get; set; }

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

        public int Height()
        {
            if (Root == null) return -1;
            return Height(Root);
        }

        private int Height(Node node)
        {
            if (node == null) return 0;

            if (IsLeaf(node)) return 0;

            return 1 + Math.Max(Height(node.LeftChild), Height(node.RightChild));
        }

        private static bool IsLeaf(Node node)
        {
            return node.LeftChild == null && node.RightChild == null;
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

        public bool Equals(Tree tree)
        {
            if (tree == null) return false;

            return Equals(Root, tree.Root);
        }

        private bool Equals(Node node, Node node2)
        {
            if (node == null && node2 == null) return true;

            if (node != null && node2 != null)
                return node.Value == node2.Value
                    && Equals(node.LeftChild, node2.LeftChild)
                    && Equals(node.RightChild, node2.RightChild);

            return false;
        }

        public void PrintNodesAtKDistance(int k)
        {
            if (Root == null) return;

            PrintNodesAtKDistance(Root, k);
        }

        public Node BuildTreeFromPreOrderAndInOrder(int[] preOrder, int[] inOrder)
        {
            //all the values in the preOrder can be used as the root
            //the left side of the root value's index in the inorder will be considered the left subtree
            //the right side of the root value's index in the inorder will be considered the right subtree
            return BuildTreeFromPreOrderAndInOrder(preOrder, inOrder, 0, preOrder.Length -1);
        }

        private Node BuildTreeFromPreOrderAndInOrder(int[] preOrder, int[] inOrder, int left, int right)
        {
            if (left > right) return null;

            var root = new Node(preOrder[BuildTreeCounter]);
            BuildTreeCounter++;

            var rootIndexInInOrderArray = Array.IndexOf(inOrder, root.Value);
            root.LeftChild = BuildTreeFromPreOrderAndInOrder(preOrder, inOrder, left, rootIndexInInOrderArray - 1);
            root.RightChild = BuildTreeFromPreOrderAndInOrder(preOrder, inOrder, rootIndexInInOrderArray + 1, right);

            return root;
        }

        private void PrintNodesAtKDistance(Node node, int k)
        {
            if (node == null) return;

            if (k == 0 && node != null)
            {
                Console.WriteLine(node.Value);
                return;
            }

            PrintNodesAtKDistance(node.LeftChild, k - 1);
            PrintNodesAtKDistance(node.RightChild, k - 1);
        }

        public int Size()
        {
            return Size(Root);
        }

        private int Size(Node node)
        {
            if (node == null) return 0;

            if (IsLeaf(node)) return 1;

            return 1 + Size(node.LeftChild) + Size(node.RightChild);
        }

        public int CountLeaves()
        {
            return CountLeaves(Root);
        }

        private int CountLeaves(Node node)
        {
            if (node == null) return 0;

            if (IsLeaf(node)) return 1;

            return CountLeaves(node.LeftChild) + CountLeaves(node.RightChild);
        }

        public class Node
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
