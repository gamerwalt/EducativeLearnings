using Educative.IO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviewPatterns
{
    public class MergeIntervals
    {
        public static List<Interval> Merge(List<Interval> intervals)
        {
            if (intervals.Count < 2) return intervals;

            intervals.Sort(delegate (Interval a, Interval b)
            {
                if (a.start == b.start) return a.end.CompareTo(b.end);
                return a.start.CompareTo(b.start);
            });

            for(int i = 0; i<intervals.Count-1; i++)
            {
                var current = intervals[i];
                var next = intervals[i + 1];
                if((current.end < next.end) && (current.start < next.start) && current.end > next.start)
                {
                    current.end = Math.Max(current.end, next.end);
                    intervals.RemoveAt(i + 1);
                    i--;
                }
                
                if(current.end > next.end)
                {
                    intervals.RemoveAt(i + 1);
                    i--;
                }
            }

            return intervals;
        }

        public static List<Interval> InsertThenMerge(List<Interval> intervals, Interval intervalToInsert)
        {
            for(int i =  0; i<intervals.Count-1; i++)
            {
                var current = intervals[i];
                var next = intervals[i + 1];

                if(intervalToInsert.start < current.start)
                {
                    current = intervalToInsert;
                    next = intervals[i];

                    intervals[i].start = intervalToInsert.start;
                    intervals[i].end = Math.Max(current.end, next.end);
                    if (i > 0) i--;
                }
                else if ((intervals[i].end < next.end) && (intervals[i].start < next.start) && intervals[i].end > next.start)
                {
                    intervals[i].end = Math.Max(current.end, next.end);
                    intervals.RemoveAt(i + 1);
                    i--;
                }
            }

            return intervals;
        }

        public static List<Interval> IntervalIntersection(Interval[] firstIntervals, Interval[] secondIntervals)
        {
            List<Interval> intervalsIntersection = new List<Interval>();
            var pointer1 = 0;
            var pointer2 = 0;

            while (pointer1 < firstIntervals.Length && pointer2 < secondIntervals.Length)
            {
                var a = firstIntervals[pointer1];
                var b = secondIntervals[pointer2];

                // have to check if there's an intersection here
                if((a.start >= b.start && a.start <= b.end) ||
                        (b.start >= a.start && b.start <= a.end))
                    intervalsIntersection.Add(new Interval(Math.Max(a.start, b.start), Math.Min(a.end, b.end)));

                if (a.end < b.end)
                    pointer1++;
                else
                    pointer2++;
            }

            return intervalsIntersection;
        }
    }
}
