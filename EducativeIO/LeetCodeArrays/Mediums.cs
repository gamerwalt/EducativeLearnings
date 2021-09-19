using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook
{
    public class Mediums
    {
        ///https://leetcode.com/problems/longest-substring-without-repeating-characters/
        ///Given a string s, find the length of the longest substring without repeating characters.
        ///Idea: 
        ///1. To solve this, we need to create a Hashset to store the characters
        ///2. Iterate through the string
        ///3. If we find the character in the HashSet, we remove it and increment the start variable thereby decreasing the window
        ///4. If we haven't, we add it and increment the window by incrementing the end pointer
        ///5. We also find out the number of items in the hashSet
        public static int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 0) return 0;

            var dict = new HashSet<Char>();
            var ans = int.MinValue;
            var start = 0;
            var end = 0;

            while (end < s.Length)
            {
                if(!dict.Contains(s[end]))
                {
                    dict.Add(s[end]);
                    end++;
                    ans = Math.Max(dict.Count, ans);
                }
                else
                {
                    dict.Remove(s[start]);
                    start++;
                }
            }

            return ans;
        }

        public static string LongestPalindrome(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return "";

            int start = 0;
            int end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                //Get these values for the 2 cases of even and odd lenghts;
                var len1 = ExpandAroundCenter(s, i, i);
                var len2 = ExpandAroundCenter(s, i, i + 1);
                var len = Math.Max(len1, len2);

                //find the boundary of the string
                //end will go to the right
                //left will go to the left
                if(len > end - start)
                {
                    start = i - ((len - 1) / 2);
                    end = i + (len / 2);
                }
            }

            //start at start and the length is the end - start + 1 (plus 1 because we're dealing with indices here. Would be 0 based)
            return s.Substring(startIndex: start, end - start + 1);
        }

        private static int ExpandAroundCenter(string s, int left, int right)
        {
            //while we're still in bounds and the character on the left pointer is equal to the character on the right pointer
            //we keep incrementing the right pointer and keep decrementing the left pointer
            //once we break out of the loop, we return the window length of the string
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }

            return right - left - 1;
        }

        private static int MaxArea(int[] height)
        {
            if (height.Length == 0) return 0;
            var overallWater = int.MinValue;
            var left = 0;
            var right = height.Length - 1;

            while(left < right)
            {
                var distance = right - left;
                var minHeight = Math.Min(height[left], height[right]);
                overallWater = Math.Max(overallWater, distance * minHeight);
                if(height[right] > height[left])
                {
                    left++;
                }
                else
                {
                    right++;
                }
            }

            return overallWater;
        }

        public static int FindMissingNumber(int[] nums)
        {
            //to find missing number = expectedSum - actualSum
            if (nums.Length == 0) return 0;
            var expectedSum = nums.Length * (nums.Length + 1) / 2;
            var actualSum = 0;

            for (int i = 0; i < nums.Length; i++)
                actualSum += nums[i];    

            return expectedSum - actualSum;
        }
    }
}
