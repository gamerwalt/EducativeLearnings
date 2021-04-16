using Educative.IO.Common;
using System;
using System.Collections;
using System.Collections.Generic;


namespace EducativeArrays
{
    public class ArrayChallenges
    {
        /// <summary>
        /// Given an array of positive numbers and a positive number ‘k,’ find the maximum sum of any contiguous subarray of size ‘k’.
        /// 1. Solution: Loop through the arr,
        /// 2. To get the last index of the window, use i + k - 1.
        /// 3. For loop within another loop. The inner loop should only look at the length of i+k-1
        /// </summary>
        /// <param name="k"></param>
        /// <param name="arr"></param>
        public static int FindMaxSumSubArray(int k, int[] arr)
        {
            int maxSum = int.MinValue;
            for(int i = 0; i<arr.Length; i++)
            {
                int currentSum = 0;
                int windowSize = i + k - 1;
                if (windowSize > arr.Length - 1) break;
                for(int j = i; j<=windowSize; j++)
                {
                    currentSum = arr[j] + currentSum;
                }
                maxSum = Math.Max(maxSum, currentSum);
            }

            return maxSum;
        }

        /// <summary>
        /// A much better approach for O(n) is to loop, but on each loop, we increase window and keep the sum, but make sure the sum minuses the last
        /// item in the window going out and adds the new index comin in.
        /// </summary>
        /// <param name="k"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int FindMaxSumSubArray2(int k, int[] arr)
        {
            int windowSum = 0;
            int maxSum = 0;
            int windowStart = 0;
            for(int windowEnd = 0; windowEnd < arr.Length; windowEnd++)
            {
                windowSum += arr[windowEnd];

                if(windowEnd >= k-1)
                {
                    maxSum = Math.Max(maxSum, windowSum);
                    windowSum -= arr[windowStart];
                    windowStart++;
                }
            }

            return maxSum;
        }

        public static void CyclicSort(int[] arr)
        {
            for(int i =0; i<arr.Length; i++)
            {
                int val = arr[i];
                if(val - 1 != i)
                {
                    SwapWithValueInPlace(arr, i, val - 1);
                    i--;
                }
            }
        }

        private static void SwapWithValueInPlace(int[] arr, int currentIndex, int supposedIndex)
        {
            int temp = arr[currentIndex];
            arr[currentIndex] = arr[supposedIndex];
            arr[supposedIndex] = temp;
        }

        public static void QuickSort(int[] arr)
        {
            if (arr == null || arr.Length == 0) return;

            QuickSortRecurrsive(arr, 0, arr.Length - 1);
        }

        private static void QuickSortRecurrsive(int[] arr, int low, int high)
        {
            if (high > low)
            {
                int pivotIndex = PartitionForQuickSort(arr, low, high);

                QuickSortRecurrsive(arr, low, pivotIndex - 1);
                QuickSortRecurrsive(arr, pivotIndex + 1, high);
            }
                
        }

        private static int PartitionForQuickSort(int[] arr, int low, int high)
        {
            int pivotValue = arr[low];
            int i = low;
            int j = high;

            while (i < j)
            {
                while (i <= high && arr[i] <= pivotValue) i++;
                while (arr[j] > pivotValue) j--;

                if (i < j)
                {
                    // swap arr[i] and arr[j]
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            arr[low] = arr[j];
            arr[j] = pivotValue;

            // return the pivot index
            return j;
        }

        public static List<Pair> MergeIntervals(List<Pair> pairs)
        {
            var result = new List<Pair>();
            var currentInterval = new Pair(pairs[0].first, pairs[0].second);

            result.Add(currentInterval);

            for(int i = 1; i<pairs.Count; i++)
            {
                var first = pairs[i].first;
                var second = pairs[i].second;
                
                if(first > currentInterval.first && first > currentInterval.second)
                {
                    var newInterval = new Pair(first, second);
                    result.Add(newInterval);
                    currentInterval = newInterval;
                }
                else if(second > currentInterval.second)
                {
                    currentInterval.second = second;
                }
                
            }

            return result;
        }

        public static Tuple<int, int> FindBuySellStockPrices(int[] arr)
        {
            int currentBuy = arr[0];
            int currentProfit = int.MinValue;
            int globalSell = arr[1];
            int globalProfit = globalSell - currentBuy;

            for(int i = 1; i<arr.Length; i++)
            {
                currentProfit = GetCurrentProfit(arr[i], currentBuy);
                if(currentProfit > globalProfit)
                {
                    globalProfit = currentProfit;
                    globalSell = arr[i];
                }
                if(arr[i] < currentBuy)
                {
                    currentBuy = arr[i];
                }
            }

            return Tuple.Create(globalSell - globalProfit, globalSell);
        }

        private static int GetCurrentProfit(int currentSell, int currentBuy)
        {
            return currentSell - currentBuy;
        }

        public static void MoveZerosToLeft2(int[] arr)
        {
            int readIndex = arr.Length - 1;
            int writeIndex = arr.Length - 1;

            while(readIndex >= 0)
            {
                if(arr[readIndex] != 0)
                {
                    arr[writeIndex] = arr[readIndex];
                    writeIndex--;
                }

                readIndex--;
            }

            while (writeIndex >= 0)
            {
                arr[writeIndex] = 0;
                writeIndex--;
            }
        }

        public static void MoveZerosToLeft(int[] arr)
        {
            for(int i = 0; i<arr.Length; i++)
            {
                if(arr[i] == 0)
                {
                    int j = i;
                    for(j = i; j>0; j--)
                    {
                        arr[j] = arr[j - 1];
                    }
                    arr[j] = 0;
                }
            }
        }

        public static int FindLowIndex(int[] arr, int key)
        {
            int low = 0;
            int high = arr.Length - 1;
            int mid = high / 2;

            while(low <= high)
            {
                int middleElement = arr[mid];

                if(middleElement < key)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }

                mid = low + (high - low) / 2;
            }

            if (low < arr.Length && arr[low] == key)
            {
                return low;
            }

            return -1;
        }

        public static int FindHighIndex(int[] arr, int key)
        {
            int low = 0;
            int high = arr.Length - 1;
            int mid = high / 2;
            while(low<=high)
            {
                int middleElement = arr[mid];

                if (middleElement <= key)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }

                mid = low + (high - low) / 2;
            }

            if (high < arr.Length && arr[high] == key)
            {
                return high;
            }

            return -1;
        }

        public static int FindLeastCommonNumber(int[] arr1, int[] arr2, int[] arr3)
        {
            for(int i = 0; i<arr1.Length; i++)
            {
                var toFind = arr1[i];
                var foundInArray2 = FindResultInArray(arr2, toFind);
                var foundInArray3 = FindResultInArray(arr3, toFind);

                if (foundInArray2 && foundInArray3) return toFind;
            }

            return -1;
        }

        private static bool FindResultInArray(int[] arr, int toFind)
        {
            for(int i =0; i<arr.Length; i++)
            {
                if (arr[i] < toFind) continue;
                else if (arr[i] > toFind) return false;
                else if (arr[i] == toFind) return true;
            }

            return false;
        }

        public static int BinarySearchRotated(int[] arr, int key)
        {
            int start = 0;
            int end = arr.Length-1;
            while(start < end)
            {
                int midPoint = start + (end - start) / 2;
                if(arr[midPoint] > arr[end])
                {
                    start = midPoint + 1;
                }
                else
                {
                    end = midPoint;
                }
            }

            if(key >= arr[start] && key <= arr[0])
            {
                return BinarySearch(arr, start, arr.Length, key);
            }
            else if(key >= arr[start] && key >= arr[0])
            {
                return BinarySearch(arr, 0, start, key);
            }
            else
            {
                return -1;
            }

        }

        public static int BinarySearch(int[] a, int key)
        {
            int max = a.Length;
            int min = 0;

            return BinarySearch(a, min, max, key);
        }

        private static int BinarySearch(int[] a, int min, int max, int key)
        {
            int mid = min + (max - min) / 2;

            if (min > max || mid >= max) return -1;

            if (a[mid] == key) 
                return mid;
            else if (key < a[mid]) 
                return BinarySearch(a, min, mid, key);
            else 
                return BinarySearch(a, mid + 1, max, key);
        }

        public static int FindMaxSumSubArray(int[] arr)
        {
            var currMax = arr[0];
            var globalMax = arr[0];
            for(int i = 0; i<arr.Length; i++)
            {
                if (currMax < 0)
                {
                    currMax = arr[i];
                }
                else
                {
                    currMax += arr[i];
                }

                if(currMax > globalMax)
                {
                    globalMax = currMax;
                }

            }

            return currMax;
        }

        public static void MaxMin(int[] arr)
        {
            int i = 0;
            while(i < arr.Length)
            {
                int nextSmallest = arr[i];
                int nextLargest = arr[arr.Length -1];

                int j = 0;
                for(j = arr.Length-1; j>i; j--)
                {
                    int temp = arr[j-1];
                    arr[j] = temp;
                }

                arr[j] = nextLargest;
                if(i<j) arr[j + 1] = nextSmallest;

                i += 2;
            }
        }

        public static void ReArrange2(int[] arr)
        {
            int j = 0;
            for(int i = 0; i<arr.Length; i++)
            {
                if(arr[i] < 0)
                {
                    if(i != j)
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                    j++;
                }
            }
        }

        public static void ReArrange(int[] arr)
        {
            int i = 1;
            while(i < arr.Length)
            {
                if (i != 0 && arr[i - 1] >= 0 && arr[i] < 0)
                {
                    int temp = arr[i];
                    arr[i] = arr[i - 1];
                    arr[i - 1] = temp;
                }
                else if (i < arr.Length -1 && arr[i] >= 0 && arr[i + 1] < 0)
                {
                    int temp = arr[i + 1];
                    arr[i + 1] = arr[i];
                    arr[i] = temp;
                    i--;
                    continue;
                }
                i++;
            }
        }

        public static int[] RotateArray(int[] arr)
        {
            int n = arr.Length - 1;
            int lastElement = arr[n];

            for(int i = n; i>0; i--)
            {
                arr[i] = arr[i - 1];
            }

            arr[0] = lastElement;

            return arr;
        }

        public static int FindSecondMaximum(int[] arr)
        {
            int first = int.MinValue;
            int second = first;
            if (arr.Length < 2) throw new ArgumentException("The arr should contain at least 2 unique elements.");

            for(int i = 0; i<arr.Length; i++)
            {
                if(arr[i] > first)
                {
                    int temp = first;
                    first = arr[i];
                    second = temp;
                }
                else
                {
                    if(arr[i] > second)
                    {
                        second = arr[i];
                    }
                }
            }

            return second;
        }

        public static int FindFirstUnique(int[] arr)
        {
            int currentValue = arr[0];
            bool found = true;
            for(int i = 0; i<arr.Length; i++)
            {
                currentValue = arr[i];
                for(int j = 0; j<arr.Length; j++)
                {
                    if(currentValue == arr[j] && i != j)
                    {
                        found = false;
                        break;
                    }
                }

                if (found == true) return currentValue;
                found = true;
            }

            return currentValue;
        }

        public static int FindMinimum(int[] arr)
        {
            int min = int.MaxValue;

            for(int i = 0; i<arr.Length; i++)
            {
                if(arr[i] < min)
                {
                    min = arr[i];
                }
            }

            return min;
        }

        public static int[] FindProduct2(int[] arr)
        {
            int n = arr.Length;
            int temp = 1;
            int i = 1;
            int[] result = new int[n];

            for(i = 0; i < n; i++)
            {
                result[i] = temp;
                temp *= arr[i];
            }

            temp = 1;

            for(i = n - 1; i >= 0; i--)
            {
                result[i] *= temp;
                temp *= arr[i];
            }

            return result;
        }

        public static int[] FindProduct(int[] arr)
        {
            int[] result = new int[arr.Length];
            int productSum = 1;
            int currentIndex = 0;
            for(int i = 0; i<arr.Length; i++)
            {
                for(int j = 0; j<arr.Length; j++)
                {
                    currentIndex = j;

                    if (currentIndex != i)
                    {
                        productSum *= arr[j];
                        result[i] = productSum;
                    }
                }
                productSum = 1;
            }

            return result;
        }

        public static int[] FindSum(int[] arr, int n)
        {
            var resultArray = new int[2];
            if (arr.Length == 0) return arr;

            for(int i = 0; i<arr.Length; i++)
            {
                for(int j = i; j<arr.Length; j++)
                {
                    if(arr[i] + arr[j] == n)
                    {
                        resultArray[0] = arr[i];
                        resultArray[1] = arr[j];
                    }
                }
            }

            return resultArray;
        }

        public static int[] MergeArray(int[] arr1, int[] arr2)
        {
            var totalLength = arr1.Length + arr2.Length;
            var arrayResult = new int[totalLength];
            var index = 0;

            for (int i = 0; i < arr1.Length; i++)
            {
                arrayResult[index++] = arr1[i];
            }
            for (int i = 0; i < arr2.Length; i++)
            {
                arrayResult[index++] = arr2[i];
            }

            Array.Sort(arrayResult);

            return arrayResult;
        }

        public static int[] MergeArray2(int[] arr1, int[] arr2)
        {
            var totalLength = arr1.Length + arr2.Length;
            var arrayResult = new int[totalLength];
            var index = 0;
            var i = 0;
            var j = 0;

            while (i < arr1.Length && j < arr2.Length)
            {
                if (arr1[i] < arr2[j]) {
                    arrayResult[index++] = arr1[i++];
                }
                else
                {
                    arrayResult[index++] = arr2[j++];
                }
            }

            while (i < arr1.Length)
                arrayResult[index++] = arr1[i++];

            while (j < arr2.Length)
                arrayResult[index++] = arr2[j++];

            return arrayResult;
        }

        //https://www.educative.io/module/lesson/data-structures-in-java/m24OxJp9y4n
        /// <summary>
        /// Challenge 1: Remove Even Integers from an Array
        //  Given an array of size n, remove all even integers from it.Implement this solution in Java and see if it runs without an error.
        /// </summary>
        /// <param name="array"></param>
        public static int[] RemoveEven(int[] array)
        {
            var numberOfOddNumbers = 0;

            for(int i = 0; i<array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    numberOfOddNumbers++;
                }                
            }

            var arrayToReturn = new int[numberOfOddNumbers];
            var index = 0;

            for(int i = 0; i<array.Length; i++)
            {
                if(array[i] % 2 != 0)
                {
                    arrayToReturn[index++] = array[i];
                }
            }

            return arrayToReturn;
        }
    }
}
