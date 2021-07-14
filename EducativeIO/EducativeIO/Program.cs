using Educative.IO.Common;
using EducativeArrays;
using System;
using System.Collections.Generic;
using CodingInterviewPatterns;
using Facebook;

namespace EducativeIO
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { 1, 2, 3, 4 };

            var result = FacebookLeetcode.ProductExceptSelf(nums);

            foreach(var item in result)
            {
                Console.WriteLine(item);
            }
        }

        
    }
}
