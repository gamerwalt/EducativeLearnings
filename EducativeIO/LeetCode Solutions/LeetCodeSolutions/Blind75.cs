using System.Collections.Generic;
using System.Linq;

namespace LeetCodeSolutions
{
    public class Blind75
    {
        public static int MaxProfit(int[] prices)
        {
            int minPrice = int.MaxValue;
            int maxProfit = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minPrice)
                    minPrice = prices[i];
                else if (prices[i] - minPrice > maxProfit)
                    maxProfit = prices[i] - minPrice;
            }

            return maxProfit;
        }

        public static bool ContainsDuplicates(int[] nums)
        {
            for(int i = 0; i<nums.Length; i++)
            {
                for(int j = i + 1; j<nums.Length; j++)
                {
                    if (nums[i] == nums[j]) return true;
                }
            }

            return false;
        }

        public static bool ContainsDuplicates2(int[] nums)
        {
            var numbers = new Dictionary<int, bool>();
            for(int i = 0; i<nums.Length; i++)
            {
                if (numbers.ContainsKey(nums[i]))
                    return true;
                else
                    numbers.Add(nums[i], true);
            }

            return false;
        }

        public static bool checkVowel(char c)
        {
            var vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };

            return vowels.Any(d => d.Equals(c));
        }
    }
}
