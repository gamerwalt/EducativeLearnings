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
            var v = new int[] { 2, 2, 2, 11 };
            var result = TwoPointers.RemoveDuplicates(v);
            Console.WriteLine(result);

            v = new int[] { 2, 3, 3, 3, 6, 9, 9 };
            result = TwoPointers.RemoveDuplicates(v);
            Console.WriteLine(result);

            v = new int[] { 3, 2, 3, 6, 3, 10, 9, 3 };
            var key = 3;
            result = TwoPointers.RemoveKey(v, key);
            Console.WriteLine(result);
        }
    }
}
