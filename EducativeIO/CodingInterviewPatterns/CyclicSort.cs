using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviewPatterns
{
    public class CyclicSort
    {
        public static void Sort(int[] nums)
        {
            if (nums.Length == 0) return;

            for (int i = 0; i < nums.Length; i++)
            {
                var val = nums[i];
                if (val - 1 != i)
                {
                    SwapWithValueInPlace(nums, i, val - 1);
                    i--;
                }
            }
        }

        private static void SwapWithValueInPlace(int[] nums, int i, int v)
        {
            var temp = nums[i];
            nums[i] = nums[v];
            nums[v] = temp;
        }

        public static int FindMissingNumber(int[] nums)
        {
            if (nums == null || nums.Length == 0) return -1;
            var i = 0;
            while (i < nums.Length)
            {
                if (nums[i] < nums.Length && nums[i] != nums[nums[i]])
                    SwapWithValueInPlace(nums, i, nums[i]);
                else
                    i++;
            }

            for (i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i)
                    return i;
            }

            return nums.Length;
        }

        public static List<int> FindNumbers(int[] nums)
        {
            var i = 0;
            while (i < nums.Length)
            {
                if (nums[i] != nums[nums[i] - 1])
                    SwapWithValueInPlace(nums, i, nums[i] - 1);
                else
                    i++;
            }

            var missingNumbers = new List<int>();
            for (i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i + 1)
                    missingNumbers.Add(i + 1);
            }

            return missingNumbers;
        }

        ///Input: [1, 4, 4, 3, 2]
        ///Output: 4
        public static int FindDuplicateNumber(int[] nums)
        {
            var i = 0;
            while (i < nums.Length)
            {
                if (nums[i] != i + 1)
                {
                    if (nums[i] != nums[nums[i] - 1])
                        SwapWithValueInPlace(nums, i, nums[i] - 1);
                    else
                        return nums[i];
                }
                else
                {
                    i++;
                }
            }

            return -1;
        }

        public static List<int> FindDuplicateNumbers(int[] nums)
        {
            var i = 0;
            while (i < nums.Length)
            {
                if (nums[i] != nums[nums[i] - 1]) //zero based
                    SwapWithValueInPlace(nums, i, nums[i] - 1);
                else
                    i++;
            }

            var duplicates = new List<int>();
            for (i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i + 1)
                    duplicates.Add(nums[i]);
            }

            return duplicates;
        }


        ///Find the Corrupt Pair (easy)
        ///We are given an unsorted array containing ‘n’ numbers taken from the range 1 to ‘n’. 
        ///The array originally contained all the numbers from 1 to ‘n’, but due to a data error, 
        ///one of the numbers got duplicated which also resulted in one number going missing. 
        ///Find both these numbers.
        ///Sample: [3, 1, 2, 3, 6, 4]
        ///Itera1: [2, 1, 3, 3, 6, 4], index 0
        ///Itera2: [1, 2, 3, 3, 6, 4], index 0, 1, 2, 3, 
        ///Itera3: [1, 2, 3, 3, 4, 6]
        ///Itera3: [1, 2, 3, 4, 3, 6]
        ///Output: [3, 5], 3 is duplicated, 5 is missing
        public static int[] FindMissingAndDuplicateNumbers(int[] nums)
        {
            if (nums == null || nums.Length == 0) return null;

            var i = 0;
            while (i < nums.Length)
            {
                if (nums[i] != nums[nums[i] - 1])
                    SwapWithValueInPlace(nums, i, nums[i] - 1);
                else
                    i++;
            }

            var results = new List<int>();

            for (i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i + 1)
                {
                    results.Add(nums[i]);
                    results.Add(i + 1);
                }

            }

            return results.ToArray();
        }


        ///Find the Smallest Missing Positive Number (medium)
        ///Given an unsorted array containing numbers, find the smallest missing positive number in it.
        ///Sample: [-3, 1, 5, 4, 2]
        ///Output: 3
        public static int FindMissingPositiveNumber(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            var i = 0;
            while(i < nums.Length)
            {
                if (nums[i] > 0 && nums[i] <= nums.Length && nums[i] != nums[nums[i] - 1])
                    SwapWithValueInPlace(nums, i, nums[i] - 1);
                else
                    i++;
            }

            for(i = 0; i< nums.Length; i++)
            {
                if (nums[i] != i + 1)
                    return i + 1;
            }

            return nums.Length + 1;
        }

        public static List<int> FindFirstMissingPositiveNumbers(int[] nums, int k)
        {
            if (k == 0 || nums == null || nums.Length == 0) return new List<int>();
            var i = 0;
            while(i < nums.Length)
            {
                if (nums[i] > 0 && nums[i] <= nums.Length && nums[i] != nums[nums[i] - 1])
                    SwapWithValueInPlace(nums, i, nums[i] - 1);
                else
                    i++;
            }

            var missingNumbers = new List<int>();
            var extraNumbers = new HashSet<int>();
            i = 0;
            for(i = 0; i<nums.Length && missingNumbers.Count < k; i++)
            {
                if(nums[i] != i + 1)
                {
                    missingNumbers.Add(i + 1);
                    extraNumbers.Add(nums[i]);
                }
            }

            for(i = 1; missingNumbers.Count < 3; i++)
            {
                var candidateNumber = i + nums.Length;
                if (!extraNumbers.Contains(candidateNumber))
                    missingNumbers.Add(candidateNumber);
            }

            return missingNumbers;
        }
    }
}
