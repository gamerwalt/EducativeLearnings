using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeSolutions
{
    public class StringProblems
    {
        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0) return "";

            return LongestCommonPrefix(strs, 0, strs.Length - 1);
        }

        private static string LongestCommonPrefix(string[] strs, int left, int right)
        {
            if (left == right) return strs[left];

            var mid = (left + right) / 2;
            var leftCommon = LongestCommonPrefix(strs, 0, mid);
            var rightCommon = LongestCommonPrefix(strs, mid + 1, right);

            return CommonPrefix(leftCommon, rightCommon);
        }

        private static string CommonPrefix(string leftCommon, string rightCommon)
        {
            var min = Math.Min(leftCommon.Length, rightCommon.Length);
            for (int i = 0; i < min; i++)
            {
                if (leftCommon[i] != rightCommon[i])
                    return leftCommon.Substring(0, i);
            }

            return leftCommon.Substring(0, min);
        }
    }
}
