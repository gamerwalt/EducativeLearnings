using Nito.Collections;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducativeArraysNetStandard
{
    public static class DequeExtensions
    {
        public static int PeekLast(this Deque<int> collection)
        {
            var value = collection.RemoveFromBack();

            collection.AddToBack(value);

            return value;
        }

        public static int PeekFirst(this Deque<int> collection)
        {
            var value = collection.RemoveFromFront();
            collection.AddToFront(value);

            return value;
        }
    }
}
