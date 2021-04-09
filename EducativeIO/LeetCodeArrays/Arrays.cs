using System;

namespace LeetCodeArrays
{
    public class Arrays
    {
        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            int count = 0;
            int maxCount = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 1)
                {
                    count++;
                    if (count > maxCount) maxCount = count;
                }
                else
                {
                    count = 0;
                }
            }

            return maxCount;
        }

        public static int FindNumbers(int[] nums)
        {
            int globalCount = 0;
            
            for(int i = 0; i<nums.Length; i++)
            {
                int remainder = 0;
                int number = nums[i];
                int count = 1;
                while (number >= 10)
                {
                    remainder = number/10;
                    count++;

                    if (remainder <= 0) break;

                    number = remainder;
                }

                if (count % 2 == 0) globalCount++;
            }

            return globalCount;
        }

        public static int[] SortedSquares(int[] nums)
        {
            int[] newArr = new int[nums.Length];
            for(int i = 0; i<nums.Length; i++)
            {
                newArr[i] = nums[i] * nums[i];
            }

            System.Array.Sort(newArr);

            return newArr;
        }
    }
}
