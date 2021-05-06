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
            var arr = new int[] { -2, -1, 0, 2, 3 };
            var result = TwoPointers.SortedArraySquares(arr);
            foreach(var item in result)
                Console.WriteLine(item);
        }
    }
}
