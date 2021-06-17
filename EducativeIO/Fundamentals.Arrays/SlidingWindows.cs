using System;
using System.Collections.Generic;
using System.Text;

namespace Fundamentals
{
    public class SlidingWindows
    {
        public static int MinimumSizeSubarraySum(int[] nums, int s)
        {
            var windowSum = 0;
            var windowStart = 0;
            var minLength = int.MaxValue;
            for(int windowEnd = 0; windowEnd<nums.Length; windowEnd++)
            {
                windowSum += nums[windowEnd];

                while(windowSum >= s)
                {
                    minLength =  Math.Min(minLength, windowEnd - windowStart + 1);
                    windowSum -= nums[windowStart];
                    windowStart++;
                }
            }

            return minLength == int.MaxValue ? 0 : minLength;
        }
    }
}
