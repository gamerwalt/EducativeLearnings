using Fundamentals;
using System;

namespace Fundamentals.OutputConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] tests = new int[][] 
            {
                new int[] {0, 1},
                new int[] {1, 2},
                new int[] {3, 2},
                new int[] {4, 3},
                new int[] {2, 4} //Remove this to make it true. This is a connection from 4 having a prerequisite of 2
            };
            Console.WriteLine(GraphProblems.CanFinishCourses(5, tests));
        }
    }
}
