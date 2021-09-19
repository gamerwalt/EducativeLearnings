using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Explore
{
    public class RemoveDuplicatesFromSortedArray
    {
        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;

            var slow = 0;
            
            for(var fast = 1; fast < nums.Length; fast++)
            {
                if(nums[fast] != nums[slow])
                {
                    slow++;
                    nums[slow] = nums[fast];
                }
            }

            return slow + 1;
        }
    }
}
