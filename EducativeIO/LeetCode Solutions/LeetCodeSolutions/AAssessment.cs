using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeSolutions
{
    public class AAssessment
    {

        public static int StringToInteger(string str)
        {
            str = str.Trim();
            if (string.IsNullOrWhiteSpace(str)) return 0;

            long num = 0;
            var sign = 1;
            var signInitialized = false;

            for (int i = 0; i < str.Length; i++)
            {
                var item = str[i];
                if (signInitialized && (item.Equals('-') || item.Equals('+'))) break;
                if ((item.Equals('-') || item.Equals('+')) && !signInitialized)
                {
                    sign = item == '-' ? -1 : 1;
                    signInitialized = true;
                    continue;
                }

                if (!Char.IsDigit(item))
                    break;

                num = num * 10 + item - '0';

                if (sign == 1 && (sign * num > int.MaxValue)) return int.MaxValue;
                if (sign == -1 && (sign * num < int.MinValue)) return int.MinValue;
            }

            return (int)num * sign;
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums.Length < 3) return new List<IList<int>>();

            var list = new List<IList<int>>();

            Array.Sort(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0 || nums[i - 1] != nums[i])
                {
                    var firstNumber = nums[i];
                    var left = i + 1;
                    var right = nums.Length - 1;
                    while (left < right)
                    {
                        var sum = firstNumber + nums[left] + nums[right];
                        if (sum == 0)
                        {
                            list.Add(new List<int>() { firstNumber, nums[left], nums[right] });
                            right--;
                            left++;
                            while (left < right && nums[left] == nums[left - 1])
                                left++;
                        }
                        else if (sum > 0)
                        {
                            right--;
                        }
                        else
                        {
                            left++;
                        }
                    }
                }
            }

            return list;
        }
    }
}
