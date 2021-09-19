using System;
using System.Collections.Generic;
using System.Text;
/*
 * 
 Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
 * 
 */
namespace Facebook.Explore
{
    public class ThreeSum
    {
        public static IList<IList<int>> Three3Sum(int[] nums)
        {
            if (nums.Length < 3) return new List<IList<int>>();

            Array.Sort(nums);

            var result = new List<IList<int>>();

            for(var index = 0; index < nums.Length; index++)
            {
                if(index == 0 || nums[index] != nums[index - 1])
                {
                    var firstNumber = nums[index];
                    var left = index + 1;
                    var right = nums.Length - 1;
                    while(left < right)
                    {
                        var sum = firstNumber + nums[left] + nums[right];
                        if(sum == 0)
                        {
                            result.Add(new List<int>() { firstNumber, nums[left], nums[right] });
                            left++;
                            right--;
                            //in order we don't get a duplicate list
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

            return result;
        }
    }
}
