using System;
using System.Collections.Generic;
using CodingInterviewPatterns;
using Educative.IO.Common;
using Facebook;
using Facebook.Explore;

namespace EducativeIO
{

    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };

            var res = RemoveDuplicatesFromSortedArray.RemoveDuplicates(nums);
            Console.WriteLine(res);
        }

        public static int SingleNumber(int[] nums)
        {
            var a = 0;
            for(int i = 0; i<nums.Length; i++)
            {
                a ^= nums[i];
            }

            return a;
        }
        
        public static void BubbleSort(int[] arr)
        {
            var isSorted = false;
            var lastUnsorted = arr.Length - 1;
            while(!isSorted)
            {
                isSorted = true;
                for(int i = 0; i < lastUnsorted; i++)
                {
                    if(arr[i] > arr[i + 1])
                    {
                        Swap(arr, i, i + 1);
                        isSorted = false;
                    }
                }
                lastUnsorted--;
            }
        }

        private static void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        private static int[] MergeSort(int[] arr)
        {
            MergeSort(arr, new int[arr.Length], 0, arr.Length - 1);

            return arr;
        }

        private static void MergeSort(int[] arr, int[]  temp, int leftStart, int rightEnd)
        {
            if (leftStart >= rightEnd)
                return;

            var middle = leftStart + ((rightEnd - leftStart) / 2);
            MergeSort(arr, temp, leftStart, middle);
            MergeSort(arr, temp, middle + 1, rightEnd);
            MergeHalves(arr, temp, leftStart, rightEnd);
        }

        private static void MergeHalves(int[] arr, int[] temp, int leftStart, int rightEnd)
        {
            var leftEnd = leftStart + ((rightEnd - leftStart) / 2);
            var rightStart = leftEnd + 1;
            var size = rightEnd - leftStart + 1;

            var left = leftStart;
            var right = rightStart;
            var index = leftStart;

            while(left <= leftEnd && right <= rightEnd)
            {
                if(arr[left] <= arr[right])
                {
                    temp[index] = arr[left];
                    left++;
                }
                else
                {
                    temp[index] = arr[right];
                    right++;
                }
                index++;
            }

            //copy left
            Array.Copy(arr, left, temp, index, leftEnd - left + 1);

            //copy right
            Array.Copy(arr, right, temp, index, rightEnd - right + 1);

            //Copy from temp to arr
            Array.Copy(temp, leftStart, arr, leftStart, size);
        }

        private static int[] QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);

            return arr;
        }

        private static void QuickSort(int[] arr, int left, int right)
        {
            if (left >= right) return;

            var pivot = arr[left + ((right - left) / 2)];
            int index = Partition(arr, left, right, pivot);
            QuickSort(arr, left, index - 1);
            QuickSort(arr, index, right);
        }

        private static int Partition(int[] arr, int left, int right, int pivot)
        {
            while(left <= right)
            {
                while (arr[left] < pivot)
                    left++;

                while (arr[right] > pivot)
                    right--;

                if(left <= right)
                {
                    var temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                    left++;
                    right--;
                }
            }

            return left;
        }
    }
}
