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
            var intervals = new List<Interval>() { new Interval(4, 5), new Interval(2, 3), new Interval(2, 4), new Interval(3, 5) };

            var results = MergeIntervals.FindMinimumMeetingRooms(intervals);

            Console.WriteLine(results);
        }
    }
}
