using Educative.IO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviewPatterns
{
    public class FastAndSlow
    {
        public static bool HasCycle(ListNode list)
        {
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
