using System;
using System.Collections.Generic;
using System.Text;

namespace Fundamentals
{
    public class Algorithms
    {
        public static int[] BubbleSort(int[] nums)
        {
            var length = nums.Length;
            while(length >= 0)
            {
                for(int i = 0; i<length-1; i++)
                {
                    if (nums[i] > nums[i + 1])
                        Swap(nums, i, i + 1);
                }

                length--;
            }

            return nums;
        }

        //O(N Log n)
        public static int[] MergeSort(int[] nums)
        {
            MergeSort(nums, new int[nums.Length], 0, nums.Length - 1);

            return nums;
        }

        private static void MergeSort(int[] nums, int[] temp, int leftStart, int rightEnd)
        {
            if (leftStart >= rightEnd) return;
            var middle = (leftStart + rightEnd) / 2;

            MergeSort(nums, temp, leftStart, middle);
            MergeSort(nums, temp, middle + 1, rightEnd);
            MergeHalves(nums, temp, leftStart, rightEnd);
        }

        private static void MergeHalves(int[] nums, int[] temp, int leftStart, int rightEnd)
        {
            var leftEnd = (rightEnd + leftStart) / 2;
            var rightStart = leftEnd + 1;
            var size = rightEnd - leftStart + 1;

            var left = leftStart;
            var right = rightStart;
            var index = leftStart;

            while(left <= leftEnd && right <= rightEnd)
            {
                if(nums[left] <= nums[right])
                {
                    temp[index] = nums[left];
                    left++;
                }
                else
                {
                    temp[index] = nums[right];
                    right++;
                }
                index++;
            }

            Array.Copy(nums, left, temp, index, leftEnd - left + 1);
            Array.Copy(nums, right, temp, index, rightEnd - right + 1);
            Array.Copy(temp, leftStart, nums, leftStart, size);
        }

        private static void Swap(int[] nums, int a, int b)
        {
            var temp = nums[a];
            nums[a] = nums[b];
            nums[b] = temp;
        }
    }
}
