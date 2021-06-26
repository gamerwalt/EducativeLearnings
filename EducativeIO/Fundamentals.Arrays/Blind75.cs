using Educative.IO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fundamentals
{
    public class Blind75
    {
        public static string LongestPalindromicSubstring(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return "";

            int start = 0;
            int end = 0;
            for(int i = 0; i<s.Length; i++)
            {
                var len1 = ExpandAroundCenter(s, i, i);
                var len2 = ExpandAroundCenter(s, i, i + 1);
                var len = Math.Max(len1, len2);

                if(len > end - start)
                {
                    start = i - ((len - 1) / 2);
                    end = i + (len / 2);
                }
            }

            return s.Substring(startIndex: start, end - start + 1);
        }

        private static int ExpandAroundCenter(string s, int left, int right)
        {
            while(left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }

            return right - left - 1;
        }

        //O(N2)
        public static int ContainerWithMostWater(int[] arr)
        {
            var overallWater = int.MinValue;

            for (int i = 0; i < arr.Length; i++)
            {
                var distance = 0;
                for (int x = i + 1; x < arr.Length; x++)
                {
                    distance++;
                    var currentWater = Math.Min(arr[i], arr[x]) * distance;

                    overallWater = Math.Max(currentWater, overallWater);
                }
            }

            return overallWater;
        }

        public static int ContainerWithMostWater2(int[] height)
        {
            var overallWater = int.MinValue;
            var left = 0;
            var right = height.Length - 1;

            while(left < right)
            {
                var distance = right - left;
                overallWater = Math.Max(Math.Min(height[right], height[left]) * distance, overallWater);
                if(height[right] > height[left])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return overallWater;
        }

        public static ListNode RemoveNthNodeFromEndOfList(ListNode head, int n)
        {
            var dummy = new ListNode(0);
            dummy.next = head;
            int length = 0;
            var first = head;
            while(first != null)
            {
                length++;
                first = first.next;
            }

            //at this point, we have the length of the linkedlist and first is at the end
            length -= n; //Get the position from the beginning where we need to actually get to
            first = dummy;

            while(length > 0)
            {
                length--;
                first = first.next;
            }

            first.next = first.next.next;

            return dummy.next;
        }


        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            var dummy = new ListNode(0);

            if (l1 == null && l2 == null) return dummy.next;

            var current1 = l1;
            var current2 = l2;
            var current3 = dummy;
            while(current1 != null && current2 != null)
            {
                if(current1.value < current2.value)
                {
                    current3.next = current1;
                    current1 = current1.next;
                }
                else
                {
                    current3.next = current2;
                    current2 = current2.next;
                }

                current3 = current3.next;
            }

            current3.next = current1 == null ? current2 : current1;

            return dummy.next;
        }
    }
}
