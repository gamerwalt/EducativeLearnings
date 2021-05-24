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
            intervals.Add(new Interval(1, 4));
            intervals.Add(new Interval(2, 5));
            intervals.Add(new Interval(7, 9));

            var result = MergeIntervals.Merge(intervals);
        }
    }
}
