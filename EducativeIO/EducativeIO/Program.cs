using Educative.IO.Common;
using EducativeArrays;
using LeetCodeArrays;
using System;
using System.Collections.Generic;

namespace EducativeIO
{
    class Program
    {
        static void Main(string[] args)
        {
            var v = new int[] {2, 1, 5, 1, 3, 2 };
            var k = 3;
            var result = ArrayChallenges.FindMaxSumSubArray2(k, v);
            Console.WriteLine(result);
        }
    }
}
