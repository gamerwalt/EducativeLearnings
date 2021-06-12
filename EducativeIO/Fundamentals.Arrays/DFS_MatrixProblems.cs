using System;
using System.Collections.Generic;
using System.Text;

namespace Fundamentals
{
    public class DFS_MatrixProblems
    {
        private static int rowLength;
        private static int colLength;

        public static int FindNumberOfIslands(char[][] grid)
        {
            int count = 0;

            rowLength = grid.Length;
            if (rowLength == 0) return 0;

            colLength = grid[0].Length;

            for(int i = 0; i<rowLength; i++)
            {
                for(int j = 0; j<colLength; j++)
                {
                    if(grid[i][j] == '1')
                    {
                        DFSAndSetAsVisisted(grid, i, j);
                        ++count;
                    }
                }
            }

            return count;
        }

        private static void DFSAndSetAsVisisted(char[][] grid, int i, int j)
        {
            //if we are at the boundaries or if we don't find a 1, we return
            if (i < 0 || j < 0 || i >= rowLength || j >= colLength || grid[i][j] != '1') return;

            grid[i][j] = '0'; //Set the already visited node to 1 so we don't visit again when we do a search

            DFSAndSetAsVisisted(grid, i + 1, j); //search the left of where we currenty are
            DFSAndSetAsVisisted(grid, i - 1, j); //search the right of where we currently are
            DFSAndSetAsVisisted(grid, i, j + 1); //search down of where we currently are
            DFSAndSetAsVisisted(grid, i, j - 1); //search up of where we currently are
        }
    }
}
