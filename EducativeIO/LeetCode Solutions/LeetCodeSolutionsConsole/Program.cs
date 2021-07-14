using LeetCodeSolutions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeSolutionsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = new string[] { "dog", "racecar", "car" };

            Console.WriteLine(StringProblems.LongestCommonPrefix(str));
        }
    }

    public class Solution
    {
        static Dictionary<string, List<string>> cache;
        const int size = 10;


        public Solution()
        {
            cache = new Dictionary<string, List<string>>();
        }

        public static List<string> Test(string value)
        {
            var cacheResult = cache.GetValueOrDefault(value);
            if (cacheResult != null)
            {
                return cacheResult;
            }
            else
            {
                var result = MyGetSuggestions(value);

                if (cache.Count() == size)
                {
                    cache.Remove(cache.FirstOrDefault().Key);
                }

                cache.Add(value, result);

                return result;
            }

        }

        public static List<string> MyGetSuggestions(string value)
        {
            if (value == "a") return new List<string>() { };

            return new List<string>() { };
        }
    }
}
