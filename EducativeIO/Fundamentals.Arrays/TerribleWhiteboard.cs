using System;
using System.Collections.Generic;
using System.Text;

namespace Fundamentals
{
    public class TerribleWhiteboard
    {
        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0) return "";

            return LongestCommonPrefix(strs, 0, strs.Length - 1);
        }

        private static string LongestCommonPrefix(string[] strs, int left, int right)
        {
            if (left == right) return strs[left];

            var mid = (left + right) / 2;
            var leftCommon = LongestCommonPrefix(strs, 0, mid);
            var rightCommon = LongestCommonPrefix(strs, mid + 1, right);

            return CommonPrefix(leftCommon, rightCommon);
        }

        private static string CommonPrefix(string leftCommon, string rightCommon)
        {
            var min = Math.Min(leftCommon.Length, rightCommon.Length);
            for(int i = 0; i<min; i++)
            {
                if (leftCommon[i] != rightCommon[i])
                    return leftCommon.Substring(0, i);
            }

            return leftCommon.Substring(0, min);
        }

        public static int ReverseInteger(int number)
        {
            var isNegative = false;
            if (number == 0) return 0;
            if (number < 0)
            {
                isNegative = true;
                number *= 1;
            }

            long result = 0;

            while(number > 0)
            {
                var remainder = number % 10;

                result = result * 10 + remainder;

                number /= 10;
            }

            if (result >= int.MaxValue) return 0;

            return isNegative  == true ? (int)result * -1 : (int)result;
        }

        public static bool ValidAnagram(string str1, string str2)
        {
            if (str1.Length != str2.Length) return false;

            var frequencies = new Dictionary<char, int>();

            foreach(var item in str1)
            {
                if(frequencies.TryGetValue(item, out var count))
                {
                    count++;
                    frequencies[item] = count;
                }
                else
                {
                    frequencies[item] = 1;
                }
            }

            foreach(var item in str2)
            {
                if(frequencies.TryGetValue(item, out var count))
                {
                    count--;
                    if (count < 0) return false;
                    frequencies[item] = count;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class MyStack
    {
        private Queue<int> Queue1;
        private Queue<int> Queue2;

        public MyStack() 
        {
            Queue1 = new Queue<int>();
            Queue2 = new Queue<int>();
        }

        public void Push(int x)
        {
            Queue2.Enqueue(x);
            
            while(Queue1.Count > 0)
            {
                Queue2.Enqueue(Queue1.Dequeue());
            }

            var tempQueue = Queue2;
            Queue2 = Queue1;
            Queue1 = tempQueue;
        }

        public int Pop()
        {
            return Queue1.Dequeue();
        }

        public int Top()
        {
            return Queue1.Peek();
        }

        public bool Empty()
        {
            return Queue1.Count == 0;
        }
    }
}
