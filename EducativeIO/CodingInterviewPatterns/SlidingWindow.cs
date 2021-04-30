using System;
using System.Collections.Generic;
using System.Text;

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
            /// Solution:
            /// keep looping and then getting the sum
            /// if at any point, the sum is greater than or equal to S, that's our queue to get the minimum lenght of the contigous sub array
            /// we find the min between the current min and then the current window we are in.
            /// the current window is always the end pointer - start pointer + 1
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

        /// <summary>
        /// Find the length of the Longest substring in a string with no more than K distinct characters
        /// </summary>
        /// <param name="str"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int LongestSubstringKDistinct(string str, int k)
        {
            ///Solution: Loop through the string
            ///For each character, add it to a map, increase the frequency when you add a new character
            ///if for any reason, the total distinct characters in the map is greater than K, then we have to start checking our window
            ///decrease the window while the distinct characters are greater than K. In this situation, when the window shrinks, we remove the 
            ///character from the map or we decrease it's frequency in the map. If it ever gets to 0, we remove it from the map
            var characterMap = new Dictionary<char, int>();
            int start = 0;
            int maxLength = int.MinValue;
            for(int end = 0; end<str.Length; end++)
            {
                var currentChar = str[end];
                characterMap.TryGetValue(currentChar, out var charCount);
                charCount++;
                characterMap[currentChar] = charCount;

                while(characterMap.Count > k)
                {
                    var characterGoingOut = str[start];
                    characterMap.TryGetValue(characterGoingOut, out var characterGoingOutCount);
                    characterGoingOutCount--;
                    characterMap[characterGoingOut] = characterGoingOutCount;
                    characterMap.TryGetValue(characterGoingOut, out characterGoingOutCount);
                    if (characterGoingOutCount == 0)
                    {
                        characterMap.Remove(characterGoingOut);
                    }
                    start++;
                }

                maxLength = Math.Max(maxLength, end - start + 1);
            }

            return maxLength;
        }
    }
}
