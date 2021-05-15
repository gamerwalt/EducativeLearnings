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
            var number = 12;
            Console.WriteLine(FastAndSlow.FindHappyNumber(number));
            Console.WriteLine(FastAndSlow.FindHappyNumber2(number));


            number = 23;
            Console.WriteLine(FastAndSlow.FindHappyNumber(number));
            Console.WriteLine(FastAndSlow.FindHappyNumber2(number));
        }
    }
}
