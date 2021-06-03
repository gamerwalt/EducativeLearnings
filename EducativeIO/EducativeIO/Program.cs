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
            var jobs = new List<Job>()
            {
                new Job(1, 4, 3),
                new Job(2, 5, 4),
                new Job(7, 9, 6)
            };

            var results = MergeIntervals.FindMaximumCPULoad(jobs);

            Console.WriteLine(results);
        }
    }
}
