using System;

namespace CountSteps
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CountSteps(100));
        }

        private static int CountSteps(int steps)
        {
            if (steps < 0)
                return 0;
            else if (steps == 0)
                return 1;

            //if max steps to count is 3 at a time
            return CountSteps(steps - 1) + CountSteps(steps - 2) + CountSteps(steps - 3);            
        }

        //using memoization
        private static int CountStepsMemo(int steps)
        {
            return CountStepsMemoR(steps, new int[steps + 1]);
        }

        private static int CountStepsMemoR(int steps, int[] memo)
        {
            if (steps < 0)
                return 0;
            else if (steps == 0)
                return 1;

            if(memo[steps] == 0)
            {
                memo[steps] = CountStepsMemoR(steps - 1, memo) + CountStepsMemoR(steps - 2, memo) + CountStepsMemoR(steps - 3, memo);
            }

            return memo[steps];
        }
    }
}
