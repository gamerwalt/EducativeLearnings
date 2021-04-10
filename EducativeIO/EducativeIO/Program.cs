using EducativeArrays;
using LeetCodeArrays;
using System;

namespace EducativeIO
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 4, 5, 6, 1, 2, 3 };

            var result = ArrayChallenges.BinarySearchRotated(arr, 3);

            Console.WriteLine(result);
        }
    }
}
