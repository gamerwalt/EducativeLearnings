using System;
using System.Collections.Generic;
using System.Text;

namespace Fundamentals
{
    public class CoinChange
    {
        public static int GetCoinChange(int amount, int[] coins)
        {
            var dp = new int[amount + 1];
            dp[0] = 0;

            for(int i = 1; i<dp.Length; i++)
            {
                dp[i] = dp[i - 1] + 1;

                if (i - 2 >= 0)
                    dp[i] = Math.Min(dp[i], dp[i - 2] + 1);

                if(i-5 >= 0)
                {
                    dp[i] = Math.Min(dp[i], dp[i - 5] + 1);
                }
            }

            return dp[amount];
        }
    }
}
