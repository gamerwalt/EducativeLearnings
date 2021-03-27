using EducativeArrays;
using System;

namespace EducativeIO
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 10, -1, 20, 4, 5, -9, -6 };
            
            ArrayChallenges.ReArrange2(arr);

            foreach(var value in arr)
            {
                Console.WriteLine(value);
            }
        }
    }
}
