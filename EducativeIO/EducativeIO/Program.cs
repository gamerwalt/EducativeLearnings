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
            var arr = new int[] { 1, 0, 1, 1 };
            var result = TwoPointers.TripletSumCloseToTarget(arr, 100);

            Console.WriteLine(result);
        }
    }
}
