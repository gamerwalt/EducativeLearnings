using Educative.IO.Common;
using EducativeArrays;
using LeetCodeArrays;
using System;
using System.Collections.Generic;

namespace EducativeIO
{
    class Program
    {
        static void Main(string[] args)
        {
            var pairs = new List<Pair>()
            {
                new Pair(1,5),
                new Pair(3,7),
                new Pair(4,6),
                new Pair(6,8),
            };

            var pairs2 = new List<Pair>()
            {
                new Pair(1,5),
                new Pair(3,7),
                new Pair(4,6),
                new Pair(6,8),
                new Pair(10,12),
                new Pair(11,15)
            };

            var pairs3 = new List<Pair>()
            {
                new Pair(10,12),
                new Pair(12,15)
            };

            var newPairs = ArrayChallenges.MergeIntervals(pairs2);
            
            foreach(var item in newPairs)
            {
                Console.WriteLine($"{item.first}, {item.second}");
            }
        }
    }
}
