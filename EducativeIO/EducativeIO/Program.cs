using Educative.IO.Common;
using EducativeArrays;
using LeetCodeArrays;
using System;
using System.Collections.Generic;
using CodingInterviewPatterns;

namespace EducativeIO
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { -1, 4, 2, 1, 3 };
            var result = TwoPointers.TripletWithSmallerSumThanTarget(arr, 5);

            Console.WriteLine(result);
        }
    }
}
