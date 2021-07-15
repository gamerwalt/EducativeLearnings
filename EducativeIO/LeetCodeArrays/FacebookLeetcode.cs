using System;

namespace Facebook
{
    public class FacebookLeetcode
    {

        public bool ValidPalindrome(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;

            return IsValidPalindrome(s, 0, s.Length - 1, false);
        }

        private bool IsValidPalindrome(string s, int left, int right, bool characterDeleted)
        {
            while(left < right)
            {
                if(s[left] != s[right])
                {
                    if (characterDeleted)
                        return false;

                    return IsValidPalindrome(s, left + 1, right, true) || IsValidPalindrome(s, left, right - 1, true);
                }

                left++;
                right--;
            }

            return true;
        }

        public static int[] Array1Question(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return new int[] { };

            var result = new int[nums.Length];
            result[0] = 1;

            for (int j = 1; j < nums.Length; j++)
            {
                result[0] *= nums[j];
            }

            for (int i = 1; i < nums.Length; i++)
            {
                result[i] = (result[0] / nums[i]) * nums[0];
            }

            return result;
        }

        public static int[] ProductExceptSelf(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return new int[] { };

            var right = new int[nums.Length];
            var left = new int[nums.Length];
            var results = new int[nums.Length];

            left[0] = 1;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                left[i + 1] = left[i] * nums[i];
            }

            right[nums.Length - 1] = 1;
            for (int i = nums.Length - 1; i > 0; i--)
            {
                right[i - 1] = right[i] * nums[i];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                results[i] = left[i] * right[i];
            }

            return results;
        }
    }
}
