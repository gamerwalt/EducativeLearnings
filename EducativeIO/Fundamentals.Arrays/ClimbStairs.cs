using System;
using System.Collections.Generic;
using System.Text;

namespace Fundamentals
{
    public class ClimbStairs
    {
        /// <summary>
        /// Climb stairs using recurssion using Dynamic Programming
        /// </summary>
        /// <param name="stairCount"></param>
        /// <returns></returns>
        public static int ClimbNumberOfStairs(int stairCount)
        {
            var memo = new int[stairCount + 1];

            memo[0] = 1;
            memo[1] = 1;

            return RecurseClimbStair(stairCount, memo);
        }

        private static int RecurseClimbStair(int stairCount, int[] memo)
        {
            if (memo[stairCount] > 0)
                return memo[stairCount];

            var waysToCurrentStair = RecurseClimbStair(stairCount - 1, memo) + RecurseClimbStair(stairCount - 2, memo);
            memo[stairCount] = waysToCurrentStair;

            return waysToCurrentStair;
        }

        /// <summary>
        /// Solve iteratively using Dynamic Programming
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairsIteratively(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;

            for(int i = 2; i<n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n];
        }
    }
}
