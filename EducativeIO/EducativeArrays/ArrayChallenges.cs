using System;

namespace EducativeArrays
{
    public class ArrayChallenges
    {

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
