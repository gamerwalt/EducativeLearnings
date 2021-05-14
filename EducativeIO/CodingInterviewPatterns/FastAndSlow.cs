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

        /// <summary>
        /// Given the head of a LinkedList with a cycle, find the length of the cycle.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static int FindLinkedListCycleLength(ListNode list)
        {
            ///Solution:
            ///Just like above, we find if the linkedlist has a cycle, if it does, we calculate the length from there.
            ///Now, to calculate the length, we use another pointer to go through the loop/cycle again.
            ///The moment we hit the slow pointer used as the start to calculate the length, that's the current length
            if (list == null || list.next == null) return -1;

            var fast = list.next; var slow = list.next;

            while(fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;

                if(fast == slow)
                {
                    return CalculateLength(slow);
                }
            }

            return 0;
        }

        private static int CalculateLength(ListNode slow)
        {
            var current = slow;
            int cycleLength = 0;

            do
            {
                current = current.next;
                cycleLength++;
            } while (current != slow);

            /**
            we can do this also instead of a do while
            //We increment so we don't have a situation where current is stil = to slow
            current = current.next;
            cycleLength++;
            while (current != slow)
            {
                current = current.next;
                cycleLength++;
            }
            **/

            return cycleLength;
        }

        /// <summary>
        /// Given the head of a Singly LinkedList that contains a cycle, write a function to find the starting node of the cycle.
        /// </summary>
        /// <param name="list"></param>
        public ListNode FindCycleStart(ListNode list)
        {
            ///Solution
            ///We find the length of the cycle
            ///if we have a length of 4, We create 2 pointers to start from the beginning of the list
            ///we move a 1 pointer 4 nodes up
            ///Then once that's complete, we can then start moving 2 pointers one at a time.
            ///The moment they meet, that's the cycle start
            ///
        }
    }
}
