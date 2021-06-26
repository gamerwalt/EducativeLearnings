using Educative.IO.Common;
using Fundamentals;
using System;

namespace Fundamentals.OutputConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var listNode = new ListNode(1);
            listNode.next = new ListNode(2);
            listNode.next.next = new ListNode(3);
            listNode.next.next.next = new ListNode(4);
            listNode.next.next.next.next = new ListNode(5);

            var ls = new ListNode(1);

            var ls1 = new ListNode(1);
            ls1.next = new ListNode(2);

            var result = Blind75.RemoveNthNodeFromEndOfList(ls, 1); ;

        }
    }
}
