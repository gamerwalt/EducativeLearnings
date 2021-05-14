using Educative.IO.Common;
using EducativeArrays;
using LeetCodeArrays;
using System;
using System.Collections.Generic;
using CodingInterviewPatterns;

namespace EducativeIO
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new ListNode(1);
            list.next = new ListNode(2);
            list.next.next = new ListNode(3);
            list.next.next.next = new ListNode(4);
            list.next.next.next.next = new ListNode(5);
            list.next.next.next.next.next = new ListNode(6);
            list.next.next.next.next.next.next = list.next.next;
            Console.WriteLine(FastAndSlow.FindCycleStart(list).value);

            list = new ListNode(1);
            list.next = new ListNode(2);
            list.next.next = new ListNode(3);
            list.next.next.next = new ListNode(4);
            list.next.next.next.next = new ListNode(5);
            list.next.next.next.next.next = new ListNode(6);
            list.next.next.next.next.next.next = list.next.next.next;
            Console.WriteLine(FastAndSlow.FindCycleStart(list).value);
        }
    }
}
