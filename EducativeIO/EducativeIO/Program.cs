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
            var v = new int[] { 1, 2, 3, 4, 6 };
            var target = 6;
            var result = TwoPointers.PairWithTargetSumBruteForce(v, target);
            foreach(var item in result)
                Console.WriteLine(item);

            result = TwoPointers.PairWithTargetSumWith2Pointers(v, target);
            foreach(var item in result)
                Console.WriteLine(item);

            result = TwoPointers.PairWithTargetSumWithHashMap(v, target);
            foreach (var item in result)
                Console.WriteLine(item);
        }
    }
}
