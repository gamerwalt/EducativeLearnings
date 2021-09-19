using System;
using System.Collections.Generic;
using System.Text;

namespace Fundamentals
{
    public class BitManipulation
    {
        
        public static int CountOnes(int n)
        {
            var count = 0;
            while(n != 0)
            {
                n &= n - 1;
                count++;
            }

            return count;
        }
    }
}
