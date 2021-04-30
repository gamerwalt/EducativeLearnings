using System;

namespace CodingInterviewPatterns
{
    public class SlidingWindow
    {
        /// <summary>
        /// Given an array of positive numbers and a positive number ‘k,’ find the maximum sum of any contiguous subarray of size ‘k’.
        /// </summary>
        /// <param name="k"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int FindMaxSumSubArray(int k, int[] arr)
        {
            ///Solution:
            ///Loop through the array, as you loop through and within the window, you will add the new index value coming in
            ///and you will remove the index value of the array going out of the window. You will only loop through the array once.

            int windowStart = 0;
            int windowEnd = 0;
            int windowSum = int.MinValue;
            int maxSum = 0;
            for(int i = 0; i<arr.Length; i++)
            {
                windowSum += arr[windowEnd];

                if(windowEnd >= k-1)
                {
                    maxSum = Math.Max(maxSum, windowSum);
                    windowSum -= arr[windowStart];
                    windowStart++;
                }
            }

            return maxSum;
        }

        /// <summary>
        /// Given an array of positive numbers and a positive number ‘S,’ find the length of the smallest contiguous subarray whose sum is 
        /// greater than or equal to ‘S’. 
        /// Return 0 if no such subarray exists.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int FindMinSubArray(int s, int[] arr)
        {
            int windowSum = 0;
            int minLength = int.MaxValue;
            int start = 0;
            for(int end = 0; end < arr.Length; end++)
            {
                windowSum += arr[end];

                while(windowSum >= s)
                {
                    minLength = Math.Min(minLength, end - start + 1);
                    windowSum -= arr[start++];
                }
            }

            return minLength == int.MaxValue ? 0 : minLength;
        }
    }
}
