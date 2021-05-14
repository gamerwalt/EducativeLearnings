using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Given an array with positive numbers and a target number, find all of its contiguous subarrays whose product is less than the target number.
        /// Input: [2, 5, 3, 10], target=30 
        /// Output: [2], [5], [2, 5], [3], [5, 3], [10]
        /// Explanation: There are six contiguous subarrays whose product is less than the target.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static List<List<int>> FindSubarrayWithProductLessThanTarget(int[] arr, int target)
        {
            if (arr.Length == 0 || arr == null) throw new ArgumentNullException();

            List<List<int>> result = new List<List<int>>();
            var product = 1;
            var left = 0;

            for(int right = 0; right<arr.Length; right++)
            {
                product *= arr[right];

                while (product >= target && left < arr.Length)
                {
                    var divideBy = arr[left];
                    left++;

                    product /= divideBy;
                }

                var tempList = new LinkedList<int>();

                for(int i = right; i>=left; i--)
                {
                    var value = arr[i];
                    tempList.AddFirst(value);
                    result.Add(tempList.ToList());
                }
            }

            return result;
        }

        public static List<List<int>> FindSubArrayWithProductLessThanTargetUsingSlidingWindow(int[] arr, int target)
        {
            if (arr.Length == 0 || arr == null) throw new ArgumentNullException();

            List<List<int>> result = new List<List<int>>();
            var product = 0;
            var windowStart = 0;
            var duplicateWindowEnd = 0;

            for(int windowEnd = 0; windowEnd<arr.Length; windowEnd++)
            {
                var windowSize = SlidingWindow.GetWindowSize(windowEnd, windowStart);

                if (windowSize <= 1 && arr[windowEnd] < target) result.Add(new List<int>() { arr[windowEnd] });

                duplicateWindowEnd = windowEnd;
                
                if(duplicateWindowEnd > 0)
                {
                    while (duplicateWindowEnd > windowStart)
                    {
                        if (arr[duplicateWindowEnd] < target)
                            result.Add(new List<int>() { arr[duplicateWindowEnd] });

                        product = arr[duplicateWindowEnd] * arr[windowStart];
                        if (product >= target)
                            windowStart++;
                        else if (product < target)
                        {
                            result.Add(new List<int>() { arr[windowStart], arr[duplicateWindowEnd] });
                            duplicateWindowEnd--;
                            windowStart++;
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Given an array containing 0s, 1s and 2s, sort the array in-place. 
        /// You should treat numbers of the array as objects, hence, we can’t count 0s, 1s, and 2s to recreate the array.
        /// Input: [1, 0, 2, 1, 0]
        /// Output: [0 0 1 1 2]
        /// </summary>
        /// <param name="arr"></param>
        public static void DutchFlag(int[] arr)
        {
            if (arr == null || arr.Length == 0) return;

            var high = arr.Length - 1;
            var low = 0;
            for(int i = 0; i< high;)
            {
                if(arr[i] == 0)
                {
                    SwapValues(arr, i, low);
                    low++;
                    i++;
                }
                else if (arr[i] == 1)
                {
                    i++;
                }
                else
                {
                    SwapValues(arr, i, high);
                    high--;
                }
            }
        }

        public static void SwapValues(int[] arr, int a, int b)
        {
            var temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        /// <summary>
        /// Given an array of unsorted numbers and a target number, find all unique quadruplets in it, whose sum is equal to the target number.
        /// Input: [4, 1, 2, -1, 1, -3], target=1
        /// Output: [-3, -1, 1, 4], [-3, 1, 1, 2]
        /// Explanation: Both the quadruplets add up to the target.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static List<List<int>> SearchQuadrupletsSumToTarget(int[] arr, int target)
        {
            if (arr == null || arr.Length == 0) throw new ArgumentException();
            var result = new List<List<int>>();

            Array.Sort(arr);
            var last = arr.Length - 1;
            for (int i = 0; i<arr.Length -3; i++)
            {
                SearchPairs(arr, i, last, target, result);
            }

            return result;
        }

        private static void SearchPairs(int[] arr, int firstIndex, int lastIndex, int target, List<List<int>> result)
        {
            var firstPointer = firstIndex + 1;
            var lastPointer = arr.Length - 1;
            while(firstPointer < lastPointer)
            {
                var sum = arr[firstIndex] + arr[lastIndex] + arr[firstPointer] + arr[lastPointer];
                if(sum == target)
                {
                    result.Add(new List<int>() { arr[firstIndex], arr[firstPointer], arr[lastPointer], arr[lastIndex] });
                    lastPointer--;
                    firstPointer++;
                }
                else if (sum > target)
                {
                    lastPointer--;
                }
                else
                {
                    firstPointer++;
                }
            }
        }

        /// <summary>
        /// Given two strings containing backspaces (identified by the character ‘#’), check if the two strings are equal.
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static bool BackspaceCompare(string str1, string str2)
        {
            ///Solution
            ///1. Loop through both strings with an index or counter starting from the back
            ///2. As we go through the strings, we want to get inside them and check. We create a child loop to loop through the strings.
            /// 2.1 
            /// We check by looping through the index we are currently on for the string
            /// and we check if it's a backspace/#, if it is, we add to a backspace count. This gives us how many characters we
            /// have to skip, TO SKIP, we check if the backspace count is greater than 0 then we reduce the backspace count and at the
            /// same time WE SKIP by reducing the index counter
            /// 2.2 
            /// NOW... if we don't encounter a backspace and the backspace count is not greater than 0, it means we've hit a valid character
            /// we have to break out of this loop to continue in the parent loop
            ///3. In the parent loop, we check if the current characteer index of both strings is less than 0
            /// 3.1 If it is, we return true
            /// 3.2 If one of the indices is at 0 and the other isn't, we return falce
            /// 3.3 If the character at both idices at any point is not equal to each other, we return false
            ///4. We keep the indices moving by setting them to the next index received from the child loop
            if (string.IsNullOrWhiteSpace(str1) || string.IsNullOrWhiteSpace(str2)) return false;

            var index1 = str1.Length - 1;
            var index2 = str2.Length - 1;
            while(index1 >= 0 || index2 >= 0)
            {
                var i = GetNextValidCharacterIndex(str1, index1);
                var j = GetNextValidCharacterIndex(str2, index2);

                if (i < 0 && j < 0) return true;

                if (i < 0 || j < 0) return false;

                if (str1[i] != str2[j]) return false;

                index1 = i - 1;
                index2 = j - 1;
            }

            return true;
        }

        private static int GetNextValidCharacterIndex(string str, int index)
        {
            var backspaceCount = 0;
            while(index >= 0)
            {
                if (str[index] == '#')
                    backspaceCount++;
                else if (backspaceCount > 0)
                    backspaceCount--;
                else
                    break;

                index--;
            }

            return index;
        }

        /// <summary>
        /// Given an array, find the length of the smallest subarray in it which when sorted will sort the whole array.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int ShortestWindowSort(int[] arr)
        {
            if (arr == null) return -1;
            if (arr.Length < 2) return -1;

            var low = 0;
            var high = arr.Length - 1;

            while(low <= high)
            {
                if (arr[low] > arr[low + 1] && arr[high] < arr[high - 1])
                    break;

                if (arr[low] < arr[low + 1])
                    low++;

                if (arr[high] > arr[high - 1])
                    high--;
            }

            if (low == arr.Length - 1)
                return 0;

            var min = int.MaxValue;
            var max = int.MinValue;
            for(int i = low; i<= high; i++)
            {
                min = Math.Min(min, arr[i]);
                max = Math.Max(max, arr[i]);
            }

            while (low > 0 && arr[low - 1] > min)
                low--;

            while (high < arr.Length - 1 && arr[high + 1] < max)
                high++;

            return high - low + 1;
        }
    }
}
