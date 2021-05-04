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
            var v = new int[] { 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 1 };
            var result = SlidingWindow.StringAnagrams("abbcabc", "abc");
            foreach(var item in result)
                Console.WriteLine(item);
        }
    }
}
