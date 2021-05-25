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
            var intervals1 = new Interval[] { new Interval(1, 3), new Interval(5, 6), new Interval(7, 9) };
            var intervals2 = new Interval[] { new Interval(2, 3), new Interval(5, 7) };

            var result = MergeIntervals.IntervalIntersection(intervals1, intervals2);
        }
    }
}
