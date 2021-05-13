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
            var str1 = "xy#z";
            var str2 = "xzz#";

            Console.WriteLine(TwoPointers.BackspaceCompare(str1, str2));
        }
    }
}
