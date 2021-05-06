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
            var arr = new int[] { -3, 0, 1, 2, -1, 1, -2 };
            var result = TwoPointers.TripletSumToZero(arr);
            foreach(var item in result)
                foreach(var i in item)
                    Console.WriteLine(i);

            
        }
    }
}
