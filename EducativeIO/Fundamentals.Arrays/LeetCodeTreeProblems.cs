using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Fundamentals
{
    public class LeetCodeTreeProblems
    {
        List<IList<int>> list;
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            list = new List<IList<int>>();

            TraverseLevelOrder(root, 0);

            return list;
        }

        private void TraverseLevelOrder(TreeNode node, int level)
        {
            if (node == null)
                return;

            if(level == list.Count)
                list.Add(new List<int>());

            list[level].Add(node.val);
            TraverseLevelOrder(node.left, level + 1);
            TraverseLevelOrder(node.right, level + 1);
        }

        public IList<double> AverageOfLevels(TreeNode root)
        {
            list = new List<IList<int>>();
            var averages = new List<double>();
            
            TraverseLevelOrder(root, 0);

            foreach(var item in list)
            {
                var sumPerLevel = 0;
                var totalNumbers = 0;
                foreach(var number in item)
                {
                    sumPerLevel += number;
                    totalNumbers++;
                }
                var averagePerLevel = (double) sumPerLevel / totalNumbers;
                averages.Add(averagePerLevel);
            }

            return averages;
        }

        public IList<IList<int>> TraversePostOrder(TreeNode root)
        {
            list = new List<IList<int>>();

            TraverseLevelOrder(root, 0);

            list.Reverse();

            return list;
        }


    }
}
