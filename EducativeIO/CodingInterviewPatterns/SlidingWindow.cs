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

        /// <summary>
        /// Given an array of characters where each character represents a fruit tree, you are given two baskets, 
        /// and your goal is to put maximum number of fruits in each basket. The only restriction is that each basket 
        /// can have only one type of fruit.
        /// You can start with any tree, but you can’t skip a tree once you have started.You will pick one fruit from 
        /// each tree until you cannot, i.e., you will stop when you have to pick from a third fruit type.
        /// Write a function to return the maximum number of fruits in both baskets.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int FindLengthOfMaxFruitsInEachBasket(char[] arr)
        {
            ///Solution: Loop through the array
            ///while looping, we keep a count of the number of characters we have seen in a map
            ///if we have more than 2 fruits, we want to slide the window forward until we have only 2 in the map
            ///while that has happened, we keep counting the number of fruits we are picking and putting into the map
            var characterMap = new Dictionary<char, int>();
            int start = 0;
            int maxLength = int.MinValue;
            for (int end = 0; end < arr.Length; end++)
            {
                var currentChar = arr[end];
                characterMap.TryGetValue(currentChar, out var charCount);
                charCount++;
                characterMap[currentChar] = charCount;

                while (characterMap.Count > 2)
                {
                    var characterGoingOut = arr[start];
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

        /// <summary>
        /// Given a string, find the length of the longest substring, which has no repeating characters.
        /// </summary>
        /// <param name="str"></param>
        public static int FindLengthOfNoRepeatSubString(string str)
        {
            ///Solution:
            ///In this scenario, you want to create a map to keep track of the frequency of characterfs
            ///when we notice that a character is going to be more than 1, we take the current length of the string in the window
            ///we move the window forward and keep checking for the max length

            int maxLength = int.MinValue;
            int start = 0;
            var frequencyMap = new Dictionary<char, int>();
            for(int end = 0; end<str.Length; end++)
            {
                var currentCharacter = str[end];
                frequencyMap.TryGetValue(currentCharacter, out var charCount);
                charCount++;
                frequencyMap[currentCharacter] = charCount;
                
                while(charCount > 1)
                {
                    var characterGoingOut = str[start];
                    frequencyMap.TryGetValue(characterGoingOut, out var characterGoingOutCount);
                    characterGoingOutCount--;
                    frequencyMap[characterGoingOut] = characterGoingOutCount;
                    if(characterGoingOutCount == 0)
                    {
                        frequencyMap.Remove(characterGoingOut);
                    }

                    frequencyMap.TryGetValue(currentCharacter, out charCount);
                    start++;
                }
                maxLength = Math.Max(maxLength, end - start + 1);
            }

            return maxLength;
        }

        /// <summary>
        /// Given a string with lowercase letters only, if you are allowed to replace no more than ‘k’ letters with any letter, 
        /// find the length of the longest substring having the same letters after replacement.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int LongestSubstringWithSameLettersAfterReplacement(string str, int k)
        {
            ///The Solution is to loop through the string
            ///the moment we get a new character, and we still have operations to change/replace a character, we do it and remove 1 from operations
            ///we get the length and then continue, the moment we have no operations anymore, we move the sliding window start position
            int maxLength = int.MinValue;
            int windowStart = 0;
            int operations = k;
            var frequencyMap = new Dictionary<char, int>();
            char previousCharacter;

            for(int windowEnd = 0; windowEnd < str.Length; windowEnd++)
            {
                var currentCharacter = str[windowEnd];

                maxLength = Math.Max(maxLength, windowEnd - windowStart + 1);
            }

            return maxLength;
        }
    }
}
