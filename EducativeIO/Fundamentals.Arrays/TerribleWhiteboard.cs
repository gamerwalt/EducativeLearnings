using System;
using System.Collections.Generic;
using System.Text;

namespace Fundamentals
{
    public class TerribleWhiteboard
    {
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
