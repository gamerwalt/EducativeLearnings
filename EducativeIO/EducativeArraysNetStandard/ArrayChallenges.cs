using Nito.Collections;
using System;
using System.Collections.Generic;

namespace EducativeArraysNetStandard
{
    public class ArrayChallenges
    {
        public static Queue<int> FindMaxSlidingWindow(int[] arr, int windowSize)
        {
            Queue<int> vals = new Queue<int>();
            var list = new Deque<int>();

            for(int i = 0; i<windowSize; i++)
            {
                while(list.Count != 0 && arr[i] >= arr[list.PeekLast()])
                {
                    list.RemoveFromBack();
                }

                list.AddToBack(i);
            }

            for(int i = windowSize; i<arr.Length; i++)
            {
                vals.Enqueue(arr[list.PeekFirst()]);

                //remove the max we don't need anymore
                while (list.Count != 0 && list.PeekFirst() <= i-windowSize)
                {
                    list.RemoveFromFront();
                }

                while(list.Count != 0 && arr[i] >= arr[list.PeekLast()])
                {
                    list.RemoveFromBack();
                }

                list.AddToBack(i);
            }

            vals.Enqueue(arr[list.PeekFirst()]);

            return vals;
        }
    }
}
