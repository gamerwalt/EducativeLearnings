using Fundamentals;
using System;

namespace Fundamentals.OutputConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new TreeNode(2147483647, null, null);
            x.left = new TreeNode(2147483647, null, null);
            x.left.left = new TreeNode(2147483647, null, null);

            var l = (new LeetCodeTreeProblems()).AverageOfLevels(x);
        }
    }
}
