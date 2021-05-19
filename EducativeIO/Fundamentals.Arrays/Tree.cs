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
