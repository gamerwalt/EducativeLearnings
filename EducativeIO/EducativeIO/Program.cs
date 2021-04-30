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
            var v = new char[] { 'A', 'B', 'C', 'B', 'B', 'C' };
            var result = SlidingWindow.FindLengthOfMaxFruitsInEachBasket(v);
            Console.WriteLine(result);
        }
    }
}
