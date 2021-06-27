using System;
using System.Collections.Generic;
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
    }
}
