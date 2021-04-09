using EducativeArrays;
using LeetCodeArrays;
using System;

namespace EducativeIO
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 10, 6, 9, -3, 23, -1, 34, 56, 67, -1, -4, -8, -2, 9, 10, 34, 67 };

            var result = EducativeArraysNetStandard.ArrayChallenges.FindMaxSlidingWindow(arr, 3);

            foreach(var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
