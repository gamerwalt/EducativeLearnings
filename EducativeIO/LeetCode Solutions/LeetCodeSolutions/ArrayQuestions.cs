using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeSolutions
{
    public class ArrayQuestions
    {
        public static int[] RunningSum(int[] nums)
        {
            if (nums == null || nums.Length == 0) return new int[] { };

            for (int i = 0; i < nums.Length - 1; i++)
            {
                nums[i + 1] += nums[i];
            }

            return nums;
        }

        public static int[] ShuffleTheArray(int[] nums, int n)
        {
            if (nums == null || nums.Length == 0 || n == 0) return new int[] { };

            var result = new int[nums.Length];
            var counter = 0;
            var length = n;
            for (int i = 0; i < length; i++)
            {
                var first = nums[i];
                var second = nums[n];

                result[counter++] = first;
                result[counter] = second;

                counter++;
                n++;
            }

            return result;
        }

        public static IList<bool> KidsWithTheGreatestNumberOfCandies(int[] candies, int extraCandies)
        {
            if (candies == null || candies.Length == 0) return new List<bool>();

            var results = new List<bool>();

            var maximumCandies = int.MinValue;
            for(int i = 0; i<candies.Length; i++)
            {
                maximumCandies = Math.Max(maximumCandies, candies[i]);
            }

            for(int i = 0; i<candies.Length; i++)
            {
                if (candies[i] + extraCandies >= maximumCandies)
                    results.Add(true);
                else
                    results.Add(false);
            }

            return results;
        }

        public static int MaximumWealth(int[][] accounts)
        {
            if (accounts == null) return 0;

            var maxSum = int.MinValue;
            for(int i = 0; i<accounts.Length; i++)
            {
                var runningSum = 0;
                for(int j = 0; j<accounts[i].Length; j++)
                {
                    runningSum += accounts[i][j];
                }

                maxSum = Math.Max(maxSum, runningSum);
            }

            return maxSum;
        }

        public static int NumberOfIdenticalPairs(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            var count = 0;
            var frequency = new Dictionary<int, int>();

            for(int i = 0; i<nums.Length; i++)
            {
                if(frequency.ContainsKey(nums[i]))
                {
                    frequency.TryGetValue(nums[i], out var currentFrequency);
                    count += currentFrequency;
                    frequency[nums[i]] = currentFrequency + 1;
                }
                else
                {
                    frequency.Add(nums[i], 1);
                }
            }

            return count;
        }

        public static int NumberOfIslands(char[][] grid)
        {
            if (grid == null) return 0;

            var count = 0;
            var n = grid.Length;
            var m = grid[0].Length;

            for(int i = 0; i<n; i++)
            {
                for(int j = 0; j<m; j++)
                {
                    if(grid[i][j] == '1')
                    {
                        FindAndMarkLinkedIslands(grid, i, j, lengthOfGrid: n, totalSearchArea: m);
                        count++;
                    }
                }
            }

            return count;
        }

        private static void FindAndMarkLinkedIslands(char[][] grid, int i, int j, int lengthOfGrid, int totalSearchArea)
        {
            if (i < 0 || j < 0 || i >= lengthOfGrid || j >= totalSearchArea || grid[i][j] != '1')
                return;

            grid[i][j] = '0';

            FindAndMarkLinkedIslands(grid, i - 1, j, lengthOfGrid, totalSearchArea);
            FindAndMarkLinkedIslands(grid, i + 1, j, lengthOfGrid, totalSearchArea);
            FindAndMarkLinkedIslands(grid, i, j + 1, lengthOfGrid, totalSearchArea);
            FindAndMarkLinkedIslands(grid, i, j - 1, lengthOfGrid, totalSearchArea);
        }
        
        public static int[][] MergeIntervals(int[][] intervals)
        {
            if (intervals == null) return new int[][] { };

            intervals = intervals.OrderBy(c => c[0]).ToArray();

            var results = new List<int[]>();
            
            foreach(var interval in intervals)
            {
                if (results.Count == 0 || results.Last()[1] < interval[0])
                    results.Add(interval);
                else
                    results.Last()[1] = Math.Max(results.Last()[1], interval[1]);
            }

            return results.ToArray();
        }

        private static bool Overlap(int[] a, int[] b)
        {
            return a[0] <= b[0] && a[1] <= b[1] && b[0] < a[1];
        }

        public int someFunction()
        {
            var q = new Queue<int>();
            q.Enqueue(1);
            q.Dequeue();
            var c = q.Count();

            var x = new int[] { };
            var y = x.Length;

            var s = new Stack<int>();
            s.Push(1);
            s.Pop();
            s.Peek();
            c = s.Count();

            var st = new SortedList<int, bool>();
            st.Count();

            return 1;
        }
    }
}
