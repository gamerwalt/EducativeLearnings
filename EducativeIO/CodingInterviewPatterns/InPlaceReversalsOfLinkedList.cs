using Educative.IO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviewPatterns
{
    public class InPlaceReversalsOfLinkedList
    {
        public static ListNode Reverse(ListNode head)
        {
            var current = head;
            var previous = default(ListNode);

            while(current != null)
            {
                var temp = current.next;
                current.next = previous;
                previous = current;

                current = temp;
            }

            return previous;
        }

        public static ListNode ReverseSubList(ListNode head, int from, int to)
        {
            var current = head;
            var previous = default(ListNode);

            for(int i = 0; i<from -1 && current != null; ++i)
            {
                previous = current;
                current = current.next;
            }

            var firstNodeToReverseThatBecomesLast = current;
            var nodeToConnectRestOfReversedList = previous;

            var temp = default(ListNode);

            for(int i = 0; i< to - from + 1 && current != null; i++)
            {
                temp = current.next;
                current.next = previous;
                previous = current;

                current = temp;
            }

            if(firstNodeToReverseThatBecomesLast != null)
            {
                firstNodeToReverseThatBecomesLast.next = previous;
            }
            else
            {
                head = previous;
            }

            nodeToConnectRestOfReversedList.next = current;

            return head;
        }

        public static ListNode RevserseEveryKSizedSubList(ListNode head, int k)
        {

            return head;
        }
    }
}
