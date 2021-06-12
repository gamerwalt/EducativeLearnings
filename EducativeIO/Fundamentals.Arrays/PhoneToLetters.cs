using System;
using System.Collections.Generic;
using System.Text;

namespace Fundamentals
{
    public class PhoneToLetters
    {
        public static List<string> MapDigitsToLetters(string digits)
        {
            var result = new List<string>();

            if (digits != null && digits.Length > 0)
            {
                var map = new string[] { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
                DFS(digits, map, result, new StringBuilder(), 0);
            }

            return result;
        }

        private static void DFS(string digits, string[] map, List<string> result, StringBuilder sb, int index)
        {
            if (index == digits.Length)
            {
                result.Add(sb.ToString());
                return;
            }

            var digit = int.Parse(digits[index].ToString());
            var letters = map[digit];

            for (int i = 0; i < letters.Length; i++)
            {
                var ch = letters[i];
                sb.Append(ch);
                DFS(digits, map, result, sb, index + 1);
                sb.Remove(sb.Length - 1, 1);
            }
        }
    }
}
