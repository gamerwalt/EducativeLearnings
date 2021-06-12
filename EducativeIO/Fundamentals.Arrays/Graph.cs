using System;
using System.Collections.Generic;
using System.Text;

namespace Fundamentals
{
    public class Graph
    {
        Dictionary<string, Node> nodes = new Dictionary<string, Node>();
        Dictionary<Node, List<Node>> adjancecyList = new Dictionary<Node, List<Node>>();

        public void AddNode(string label)
        {
            var node = new Node(label);
            nodes.TryAdd(label, node);
            adjancecyList.Add(node, new List<Node>());
        }

        public void RemoveNode(string label)
        {
            var node = nodes.GetValueOrDefault(label);
            if (node == null)
                return;

            foreach(var item in adjancecyList.Keys)
            {
                adjancecyList.GetValueOrDefault(item).Remove(node);
            }

            adjancecyList.Remove(node);
            nodes.Remove(label);
        }

        public void AddEdge(string from, string to)
        {
            var fromNode = nodes.GetValueOrDefault(from);
            var toNode = nodes.GetValueOrDefault(to);
            if (fromNode == null || toNode == null)
                throw new ArgumentException();

            adjancecyList.GetValueOrDefault(fromNode).Add(toNode);
        }

        public void RemoveEdge(string from, string to)
        {
            var fromNode = nodes.GetValueOrDefault(from);
            var toNode = nodes.GetValueOrDefault(to);
            if (fromNode == null || toNode == null)
                return;

            adjancecyList.GetValueOrDefault(fromNode).Remove(toNode);
        }

        public void Print()
        {
            foreach(var source in adjancecyList.Keys)
            {
                var targets = adjancecyList.GetValueOrDefault(source);
                if(targets.Count > 0)
                {
                    var items = string.Join(',', targets);
                    Console.WriteLine($"{source} is connected to {items}");
                }
            }
        }

        private class Node
        {
            private string Label { get; set; }
            public Node(string label)
            {
                this.Label = label;
            }

            public override string ToString()
            {
                return this.Label;
            }
        }
    }
}
