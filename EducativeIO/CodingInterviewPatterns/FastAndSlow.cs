using Educative.IO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviewPatterns
{
    public class FastAndSlow
    {
        /// <summary>
        /// Given the head of a Singly LinkedList, write a function to determine if the LinkedList has a cycle in it or not.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool HasCycle(ListNode list)
        {
            ///Solution:
            ///We should have 2 pointers. One that will move fast (2 nodes at a time) and one that moves slow (1 node at a time)
            ///at some point, the 2 pointers will meet. Once they meet, we can safely say the linked list has a cycle
            if (list == null || list.next == null) return false;

            var fast = list.next;
            var slow = list.next;

            while(fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
                if (slow == fast) return true;
            }

            return false;
        }
    }
}
