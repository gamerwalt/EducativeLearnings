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
            var v = new string[] { "cat", "fox" };
            var result = SlidingWindow.FindWordConcatenation("catcatfoxfox", v);
            foreach(var item in result)
                Console.WriteLine(item);
        }
    }
}
