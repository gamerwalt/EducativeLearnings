using LeetCodeSolutions;
using System;

namespace LeetCodeSolutionsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = AAssessment.ThreeSum(new int[] { -2, 0, 0, 2, 2 });
            foreach (var items in result)
            {
                foreach(var i in items)
                {
                    Console.Write(i);
                    Console.Write(',');
                }
                Console.WriteLine("*******");
            }
        }
    }
}
