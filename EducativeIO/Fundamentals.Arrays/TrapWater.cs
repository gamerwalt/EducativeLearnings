using System;
using System.Collections.Generic;
using System.Text;

namespace Fundamentals
{
    public class TrapWater
    {
        public static int Trap(int[] height)
        {
            if (height == null) return 0;
            if (height.Length == 0) return 0;

            var totalWater = 0;
            var length = height.Length;

            var leftMaxWaterHeight = new int[length];
            var rightMaxWaterHeight = new int[length];

            leftMaxWaterHeight[0] = height[0];
            rightMaxWaterHeight[0] = height[0];
            for (int i = 1; i < length; i++)
            {
                leftMaxWaterHeight[i] = Math.Max(leftMaxWaterHeight[i - 1], height[i]);
            }

            rightMaxWaterHeight[length - 1] = height[length - 1];
            for (int i = length - 2; i >= 0; i--)
            {
                rightMaxWaterHeight[i] = Math.Max(rightMaxWaterHeight[i + 1], height[i]);
            }

            for (int i = 1; i < length - 1; i++)
            {
                totalWater += Math.Min(leftMaxWaterHeight[i], rightMaxWaterHeight[i]) - height[i];
            }

            return totalWater;
        }
    }
}
