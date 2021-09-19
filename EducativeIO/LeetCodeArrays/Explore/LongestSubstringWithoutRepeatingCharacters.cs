using System;
using System.Collections.Generic;

/*
Given a string s, find the length of the longest substring without repeating characters.

    Input: s = "abcabcbb"
    Output: 3
    Explanation: The answer is "abc", with the length of 3.

    Input: s = ""
    Output: 0

    Input: s = "pwwkew"
    Output: 3
    Explanation: The answer is "wke", with the length of 3.
*/

namespace Facebook.Explore
{
    public class LongestSubstringWithoutRepeatingCharacters
    {

        public static int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return 0;

            var result = int.MinValue;
            var map = new HashSet<int>();
            //We will use this for a window and essentially remove and add to the hashset
            //if we find a character we have seen before, we remove it from the hashset
            //if we haven't, we add to the hashset and move the end forward to increase the window of what we've seen
            //basically, the amount of characters in the hashset is the window size or number of characters
            //without repeating characters
            var start = 0;
            var end = 0;

            while (end < s.Length)
            {
                if (!map.Contains(s[end]))
                {
                    map.Add(s[end]);
                    end++;
                    result = Math.Max(result, map.Count);
                }
                else
                {
                    //Remove it
                    map.Remove(s[start]);
                    start++;
                }
            }

            return result;
        }
    }
}
