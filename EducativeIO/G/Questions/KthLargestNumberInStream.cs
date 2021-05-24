using Lucene.Net.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions
{

    /// <summary>
    /// Find the kth largest element in a number stream
    /// </summary>
    public class KthLargestNumberInStream
    {
        private int K;
        private SortedList<int, int> MinHeap;
        private int MinHeapSize;

        public KthLargestNumberInStream(int k, int[] nums)
        {
            K = k;
            MinHeap = new SortedList<int, int>();
            MinHeapSize = 0;
            foreach(var item in nums)
            {
                Add(item);
            }

        }

        private int Add(int num)
        {
            if(MinHeapSize < K || num > MinHeap.First().Key)
            {
                if(!MinHeap.ContainsKey(num))
                {
                    MinHeap.Add(num, 1);
                }
                else
                {
                    MinHeap[num]++;
                }
                MinHeapSize++;
            }
            if(MinHeapSize > K)
            {
                var firstElement = MinHeap.First();
                if (firstElement.Value > 1)
                    MinHeap[firstElement.Key]--;
                else
                    MinHeap.Remove(firstElement.Key);

                MinHeapSize--;
            }

            return MinHeap.First().Key;
        }
    }
}
