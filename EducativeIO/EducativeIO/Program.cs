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
            var intervals = new List<Interval>();
            intervals.Add(new Interval(1, 3));
            intervals.Add(new Interval(5, 7));
            intervals.Add(new Interval(8, 12));

            var result = MergeIntervals.InsertThenMerge(intervals, new Interval(4, 10));
        }
    }
}
