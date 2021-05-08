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
            var arr = new int[] { 2, 5, 3, 10 };
            var result = TwoPointers.FindSubArrayWithProductLessThanTargetUsingSlidingWindow(arr, 30);
            foreach(var item in result)
            {
                foreach(var i in item)
                {
                    Console.WriteLine(i);
                }

                Console.WriteLine("*********************");
            }

            Console.WriteLine("______________________________________________");


            arr = new int[] { 8, 2, 6, 5 };
            result = TwoPointers.FindSubArrayWithProductLessThanTargetUsingSlidingWindow(arr, 50);
            foreach (var item in result)
            {
                foreach (var i in item)
                {
                    Console.WriteLine(i);
                }

                Console.WriteLine("*********************");
            }
        }
    }
}
