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
            var v = new int[] { 2, 1, 5, 2, 3, 2 };
            var result = SlidingWindow.FindMinSubArray(7, v);
            Console.WriteLine(result);
        }
    }
}
