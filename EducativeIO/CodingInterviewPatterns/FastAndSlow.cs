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
        public static ListNode FindCycleStart(ListNode list)
        {
            ///Solution
            ///We find the length of the cycle
            ///if we have a length of 4, We create 2 pointers to start from the beginning of the list
            ///we move a 1 pointer 4 nodes up
            ///Then once that's complete, we can then start moving 2 pointers one at a time.
            ///The moment they meet, that's the cycle start
            if (list == null || list.next == null) throw new ArgumentException();

            var fast = list.next; var slow = list.next;

            var cycleLength = 0;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;

                if (fast == slow)
                {
                    cycleLength = CalculateLength(slow);
                    break;
                }
            }

            fast = list;
            slow = list;
            for(int i = 0; i<cycleLength; i++)
            {
                fast = fast.next;
            }

            while(fast != null && fast.next != null)
            {
                fast = fast.next;
                slow = slow.next;
                if (fast == slow)
                    return fast;
            }

            return list;
        }

        /// <summary>
        /// Any number will be called a happy number if, after repeatedly replacing it with a number equal to the sum 
        /// of the square of all of its digits, leads us to number ‘1’. 
        /// All other (not-happy) numbers will never reach ‘1’. 
        /// Instead, they will be stuck in a cycle of numbers which does not include ‘1’.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool FindHappyNumber(int num)
        {
            ///Solution: we loop through the sums and create a hashmap to store the results
            ///as we go, if the sum is 1, we break and return true
            ///if it's not 1, we add it to our hashmap if we don't find it in there.
            ///if we do find it in there though, that means, we've come back in a cycle, we should return false
            var sum = num;
            var found = new Dictionary<int, bool>();

            while(sum != 1)
            {
                sum = GetSquareSum(sum);

                if (sum == 1) return true;

                found.TryGetValue(sum, out var value);

                if (value) return false;

                found[sum] = true;
            }

            return false;
        }

        private static int GetSquareSum(int num)
        {
            int sum = 0;
            int digit = 0;
            while(num > 0)
            {
                digit = num % 10;
                sum += digit * digit;

                num /= 10;
            }

            return sum;
        }

        public static bool FindHappyNumber2(int num)
        {
            var fast = num;
            var slow = num;
            do
            {
                slow = GetSquareSum(slow);
                fast = GetSquareSum(GetSquareSum(fast));

            } while (fast != slow);

            return slow == 1;
        }

        /// <summary>
        /// Given the head of a Singly LinkedList, write a method to return the middle node of the LinkedList.
        /// If the total number of nodes in the LinkedList is even, return the second middle node.
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static int FindMiddleOfLinkedList(ListNode head)
        {
            if (head == null || head.next == null) return -1;

            var slow = head;
            var fast = slow;

            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow.value;
        }

        public static bool IsPalindromeLinkedList(ListNode head)
        {
            if (head == null || head.next == null) return false;

            var slow = head;
            var fast = slow;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            var half = ReverseLinkedList(slow);
            var copyFromHalf = half;

            //compare both halves
            while (head != null && half != null)
            {
                if (head.value != half.value) break;
                head = head.next;
                half = half.next;
            }

            var node = ReverseLinkedList(copyFromHalf);

            if (head == null || half == null) return true;

            return false;
        }

        private static ListNode ReverseLinkedList(ListNode node)
        {
            ListNode previous = null;

            while (node != null)
            {
                var temp = node.next;

                node.next = previous;
                previous = node;

                node = temp;
            }

            return previous;
        }

        /// <summary>
        /// Given the head of a Singly LinkedList, write a method to modify the LinkedList such that the nodes from the 
        /// second half of the LinkedList are inserted alternately to the nodes from the first half in reverse order. 
        /// So if the LinkedList has nodes 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> null, 
        /// your method should return 1 -> 6 -> 2 -> 5 -> 3 -> 4 -> null.
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode RearrangeLinkedList(ListNode head)
        {
            //we get the middle of the list
            //then we reverse the 2nd half of the list
            //once we've reversed it, we have a new poitner at the beginning of the main list
            //and another at the start of the reversed list
            //then as we move in the main list, we store the next node, but the node of the previous should now point
            //to the value of the other half's node and we continue to loop

            if (head == null || head.next == null) throw new ArgumentException();

            //Find the middle
            var slow = head;
            var fast = slow;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            var headSecondHalf = ReverseLinkedList(slow);
            var headFirstHalf = head;

            while (headFirstHalf != null && headSecondHalf != null)
            {
                var temp = headFirstHalf.next;
                headFirstHalf.next = headSecondHalf;
                headFirstHalf = temp;

                temp = headSecondHalf.next;
                headSecondHalf.next = headFirstHalf;
                headSecondHalf = temp;
            }

            if (headFirstHalf != null) headFirstHalf.next = null;

            return head;
        }
    }
}
