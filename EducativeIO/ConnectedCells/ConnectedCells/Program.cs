using System;

namespace ConnectedCells
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new int[][]
            {
                new int[] {0, 0, 0, 1, 1, 0, 0 },
                new int[] {0, 1, 0, 0, 1, 1, 0 },
                new int[] {1, 1, 0, 1, 0, 0, 1 },
                new int[] {0, 0, 0, 0, 0, 1, 0 },
                new int[] {1, 1, 0, 0, 0, 0, 0 },
                new int[] {0, 0, 0, 1, 0, 0, 0 }
            };

            var result = getBiggestRegion(matrix);
        }

        private static int getBiggestRegion(int[][] matrix)
        {
            int maxRegion = 0;

            for(int row = 0; row < matrix.Length; row++)
            {
                for(int col = 0; col < matrix[row].Length; col++)
                {
                    if(matrix[row][col] == 1)
                    {
                        //do a dfs and turn it to -1/0 to denote visited array
                        var currentMax = DFS(matrix, row, col);
                        maxRegion = Math.Max(currentMax, maxRegion);
                    }
                }
            }

            return maxRegion;
        }

        private static int DFS(int[][] matrix, int row, int col)
        {
            var regionCount = 0;
            if (row == -1 || col == -1) return 0;
            if (row >= matrix.Length || col >= matrix[row].Length) return 0;
            if (matrix[row][col] == 0) return 0;

            matrix[row][col] = 0;
            regionCount++;

            //search up on same column
            regionCount += DFS(matrix, row + 1, col);
            //search down on same column
            regionCount += DFS(matrix, row - 1, col);

            //search forward on same row
            regionCount += DFS(matrix, row, col + 1);
            //search backward on same row
            regionCount += DFS(matrix, row, col - 1);

            //search diagonally
            //serch forward on up one row
            regionCount += DFS(matrix, row - 1, col + 1);
            //search backward down one row
            regionCount += DFS(matrix, row + 1, col - 1);
            //search backward up one row
            regionCount += DFS(matrix, row - 1, col - 1);
            //search forward down one row
            regionCount += DFS(matrix, row + 1, col + 1);

            return regionCount;
        }
    }
}
