using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Explore
{
    public class FindNextPermutation
    {
        public static void NextPermutation(int[] nums)
        {
            if (nums.Length == 0) return;

            var end = nums.Length - 2;
            while (end >= 0 && nums[end] >= nums[end + 1])
                end--;

            //we've reached the point where we've found a decreasing number
            //we need to now swap with the most increasing number just right after it
            if(end >=0)
            {
                var index = nums.Length - 1;
                while (nums[index] <= nums[end])
                    index--;

                //we should now have found the next increasing number, we need to swap them now
                Swap(nums, end, index);
            }

            //Then reverse the remaining numbers
            Reverse(nums, end + 1);
        }

        private static void Reverse(int[] nums, int start)
        {
            var end = nums.Length - 1;
            while(start < end)
            {
                Swap(nums, start, end);
                end--;
                start++;
            }
        }

        private static void Swap(int[] nums, int i, int j)
        {
            var temp = nums[j];

            nums[j] = nums[i];
            nums[i] = temp;
        }
    }
}
