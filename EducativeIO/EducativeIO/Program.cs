using EducativeArrays;
using System;

namespace EducativeIO
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 4, 2, 1, 5, 0 };
            
            var result = ArrayChallenges.FindSecondMaximum(arr);

            Console.WriteLine(result);
        }
    }
}
