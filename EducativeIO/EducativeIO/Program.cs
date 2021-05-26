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
            var intervals = new List<Interval>() { new Interval(4, 5), new Interval(2, 3), new Interval(3, 6), new Interval(5, 7), new Interval(7, 8) };

            var results = MergeIntervals.FindAllConflictingAppointments(intervals);

            foreach(var item in results)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
