using System;
using System.Collections.Generic;
using System.Text;

namespace Educative.IO.Common
{
    public class Palindromes
    {
        public static bool IsPalindromeString(string str)
        {
            if (String.IsNullOrWhiteSpace(str)) return false;

            //let's try the two pointer approach
            var left = 0;
            var right = str.Length - 1;

            while(left <= right)
            {
                var leftChar = str[left];
                var rightChar = str[right];

                if (leftChar != rightChar) return false;
                left++;
                right--;
            }

            return true;
        }

        public static string LongestPalindromeInAString(string str)
        {
            var left = 0; var right = 0;

            for(int position = 0; position<str.Length; position++)
            {
                var length1 = ExpandAroundPosition(position, position, str);
                var length2 = ExpandAroundPosition(position, position + 1, str);

                var current = Math.Max(length1, length2);

                if(current > right - left)
                {
                    left = position - (current - 1) / 2;
                    right = position + current / 2;
                }
            }

            return str.Substring(left, right - left + 1);
        }

        private static int ExpandAroundPosition(int left, int right, string s)
        {
            while(left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }

            return right - left - 1;
        }
    }
}
