using Educative.IO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingInterviewPatterns
{
    public class MergeIntervalsReview
    {
        public static List<Interval> MergeIntervals(List<Interval> intervals)
        {
            //1. Sort by the start time
            //2. Generate a Result to output
            //3. Iterate through the List of Intervals
            //4.    if the result interval is empty, we add the first interval
            //5.    If it isn't empty, we check the last inputted interval's last time and compare to the current interval's
            //      last time as well as compare the last inputted interval's last time to the start time of the current interval.
            //      If the current interval's start time is less than the last inputted interval's last time and the current
            //      Interval's last time is greater, we take the greater. If it is less, we take the last inputted

            ///Result:
            ///[6, 7] [2, 4], [5, 9]
            ///[2, 4] [5, 9] [6, 7]
            ///
            ///Result: [2, 4], [5, 9], 
            if (intervals == null) return null;

            intervals.Sort(new IntervalComparer());
            var result = new List<Interval>();

            foreach(var interval in intervals)
            {
                if (result.Count == 0 || result.Last().end < interval.start)
                    result.Add(interval);
                else
                    result.Last().end = Math.Max(result.Last().end, interval.end);
            }

            return result;
        }

    }
}
