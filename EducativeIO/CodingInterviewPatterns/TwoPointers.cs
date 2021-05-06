using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviewPatterns
{
    public class TwoPointers
    {
        /// <summary>
        /// Given an array of sorted numbers and a target sum, find a pair in the array whose sum is equal to the given target.
        /// Note: There are 3 different ways to solve this.
        /// 1. Brute force: Loop through each index and then loop through the remaining items in the array to find the 2nd integer that adds to target
        /// 2. 2 Pointer approach: one pointer starts in the beginning and the other at the end, depending on the sum of those 2 numbers at the extremes,
        ///     if the sum of those 2 numbers is greater than the target, we decrease the end pointer to move closer to the start
        ///     if the sum of those 2 numbers is lesser than the target, we increase the start pointer to move closer to the end
        ///     This is mainly because the array is sorted
        /// 3. By using a hashmap/dictionary to keep the difference and the index of the numbers we've gone through in the array, as we go through the array,
        ///     if we don't see the number in the map, add the difference of the target and the actual number
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public static List<int> PairWithTargetSumBruteForce(int[] arr, int targetSum)
        {
            var result = new List<int>();
            
            for(int i = 0; i<arr.Length; i++)
            {
                var firstNum = arr[i];
                for(int j = 0; j<arr.Length; j++)
                {
                    if(i != j)
                    {
                        if(arr[i] + arr[j] == targetSum)
                        {
                            result.Add(i);
                            result.Add(j);

                            return result;
                        }
                    }
                }
            }

            return result;
        }

        public static List<int> PairWithTargetSumWith2Pointers(int[] arr, int targetSum)
        {
            var result = new List<int>();

            var leftPointer = 0;
            var rightPointer = arr.Length - 1;

            while(leftPointer < rightPointer)
            {
                var sum = arr[leftPointer] + arr[rightPointer];
                if(sum == targetSum)
                {
                    result.Add(leftPointer);
                    result.Add(rightPointer);
                    return result;
                }
                else if (sum > targetSum)
                {
                    rightPointer--;
                }
                else
                {
                    leftPointer++;
                }
            }

            return result;
        }

        public static List<int> PairWithTargetSumWithHashMap(int[] arr, int targetSum)
        {
            var result = new List<int>();
            var differencesMap = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                var difference = targetSum - arr[i];
                if(differencesMap.ContainsKey(difference))
                {
                    result.Add(differencesMap[difference]);
                    result.Add(i);
                    return result;
                }
                else
                {
                    differencesMap[arr[i]] = i;
                }
            }

            return result;
        }

        /// <summary>
        /// Given an array of sorted numbers, remove all duplicates from it. 
        /// You should not use any extra space; after removing the duplicates in-place return the length of the subarray that has no duplicate in it.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int RemoveDuplicates(int[] arr)
        {
            var slowPointer = 1;
            for(int i = 1; i < arr.Length; i++)
            {
                if(arr[slowPointer - 1] != arr[i])
                {
                    arr[slowPointer] = arr[i];
                    slowPointer++;
                }
            }

            return slowPointer;
        }

        public static int RemoveKey(int[] arr, int key)
        {
            var nextPointer = 0;
            for (int i = 0; i<arr.Length; i++)
            {
                if(arr[i] != key)
                {
                    arr[nextPointer] = arr[i];
                    nextPointer++;
                }
            }

            return nextPointer;
        }

        /// <summary>
        /// Given a sorted array, create a new array containing squares of all the numbers of the input array in the sorted order.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] SortedArraySquares(int[] arr)
        {
            int leftPointer = 0;
            int rightPointer = arr.Length - 1;
            int counter = rightPointer;

            var squaredArray = new int[arr.Length];

            while (leftPointer < rightPointer)
            {
                var leftNumber = Math.Abs(arr[leftPointer]);
                var rightNumber = Math.Abs(arr[rightPointer]);
                if(rightNumber > leftNumber)
                {
                    squaredArray[counter] = rightNumber * rightNumber;
                    rightPointer--;
                }
                else
                {
                    squaredArray[counter] = leftNumber * leftNumber;
                    leftPointer++;
                }

                counter--;
            }

            return squaredArray;
        }
    }
}
