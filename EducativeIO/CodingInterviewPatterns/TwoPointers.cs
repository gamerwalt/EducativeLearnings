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
        /// <summary>
        /// Given an array of unsorted numbers, find all unique triplets in it that add up to zero.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static List<List<int>> TripletSumToZero(int[] arr)
        {
            ///Solution
            ///Sort the array first. Then loop through the array, however, for each loop, we get the current index and do a search pair on the remaining
            ///indices. We have to be careful of duplicates as well, so we check if we have a duplicate and just skip
            ///in the SearchPair function which is close to the 2 sum, we have to make sure that if we have the same element/value on both sides, we skip
            ///as well
            Array.Sort(arr);
            var results = new List<List<int>>();
            var found = new List<int>();

            for(int i = 0; i<arr.Length -2; i++)
            {
                if (i > 0 && arr[i] == arr[i - 1]) continue;

                var targetSum = -arr[i]; //This will negate a positive number or make a positive number negative
                var leftPointer = i + 1; //we start searching from the next number in the array
                SearchPair(arr, targetSum, leftPointer, results);
            }

            return results;
        }

        private static void SearchPair(int[] arr, int targetSum, int leftPointer, List<List<int>> results)
        {
            int rightPointer = arr.Length - 1; //let's get the right pointer which will always be the last index

            while(leftPointer < rightPointer)
            {
                int currentSum = arr[leftPointer] + arr[rightPointer];
                if (currentSum == targetSum)
                {
                    results.Add(new List<int>() { -targetSum, arr[leftPointer], arr[rightPointer] });
                    leftPointer++;
                    rightPointer--;
                    //try to skip the same element on both sides
                    while (leftPointer < rightPointer && arr[leftPointer] == arr[leftPointer - 1])
                        leftPointer++;
                    while (leftPointer < rightPointer && arr[rightPointer] == arr[rightPointer + 1])
                        rightPointer--;
                }
                else if (targetSum > currentSum)
                    leftPointer++;
                else
                    rightPointer--;
            }
        }

        /// <summary>
        /// Given an array of unsorted numbers and a target number, find a triplet in the array whose sum is as close to the target number as possible, 
        /// return the sum of the triplet. 
        /// If there are more than one such triplet, return the sum of the triplet with the smallest sum.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public static int TripletSumCloseToTarget(int[] arr, int targetSum)
        {
            var minSumDifference = int.MaxValue;
            if (arr.Length == 0 || arr == null) return -1;

            Array.Sort(arr);

            for(int i = 0; i<arr.Length - 2; i++)
            {
                var firstNumber = arr[i];
                var leftPointer = i + 1;
                var rightPointer = arr.Length - 1;

                while(leftPointer < rightPointer)
                {
                    int targetDifference = targetSum - firstNumber - arr[leftPointer] - arr[rightPointer];
                    
                    if (targetDifference == 0) //we found an exact match to the targetsum
                        return targetSum - targetDifference;

                    if(Math.Abs(targetDifference) < Math.Abs(minSumDifference)
                        || (Math.Abs(targetDifference) == Math.Abs(minSumDifference)) && targetDifference > minSumDifference) //not sure of this line
                    {
                        minSumDifference = targetDifference;
                    }

                    if (targetDifference > 0)
                        leftPointer++;
                    else
                        rightPointer--;
                }
            }

            return targetSum - minSumDifference;

        }

        /// <summary>
        /// Given an array arr of unsorted numbers and a target sum, count all triplets in it such that arr[i] + arr[j] + arr[k] < target 
        /// where i, j, and k are three different indices. Write a function to return the count of such triplets.
        /// Sample: [-1, 4, 2, 1, 3], target=5 
        /// Output: 4
        /// Explanation:There are four triplets whose sum is less than the target: [-1, 1, 4], [-1, 1, 3], [-1, 1, 2], [-1, 2, 3]
        /// [-1, 1, 2, 3, 4]
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int TripletWithSmallerSumThanTarget(int[] arr, int target)
        {
            int count = -1;
            if (arr.Length == 0 || arr == null) return -1;

            Array.Sort(arr);

            for(int i = 0; i<arr.Length - 2; i++)
            {
                count += SearchPair(arr, target - arr[i], i);
            }

            return count;
        }

        private static int SearchPair(int[] arr, int target, int first)
        {
            var count = 0;
            var leftPointer = first + 1;
            var rightPointer = arr.Length - 1;

            while(leftPointer < rightPointer)
            {
                if(arr[leftPointer] + arr[rightPointer] < target)
                {
                    count += rightPointer - leftPointer;
                    leftPointer++;
                }
                else
                {
                    rightPointer--;
                }
            }

            return count;
        }
    }
}
