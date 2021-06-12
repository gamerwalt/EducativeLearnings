using System;
using System.Collections.Generic;
using System.Text;

namespace Fundamentals
{
    public class NQueens
    {
        private static int boardLength;
        /// <summary>
        /// Find a way on a matrix board of length n where placing queens do not attack each other
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static List<List<string>> SolveQueens(int n)
        {
            char[,] board = new char[n,n]; //set up an NxN board
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    board[i,j] = '.';

            boardLength = n;

            var result = new List<List<string>>();

            DFS_Queens(board, 0, result);

            return result;
        }

        private static void DFS_Queens(char[,] board, int colIndex, List<List<string>> result)
        {
            if(colIndex == boardLength)
            {
                result.Add(Construct(board));
                return;
            }

            for(int i = 0; i < boardLength; i++)
            {
                if(ValidatePosition(board, i, colIndex))
                {
                    board[i, colIndex] = 'Q';
                    DFS_Queens(board, colIndex + 1, result);
                    board[i, colIndex] = '.';
                }
            }
        }

        /// <summary>
        /// Validates on the board if we find a Queen diagonally or horizontally or we've reached the border of the board
        /// </summary>
        /// <param name="board"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static bool ValidatePosition(char[,] board, int x, int y)
        {
            for(int i = 0; i< boardLength; i++)
            {
                for(int j = 0; j<y; j++)
                {
                    if (board[i, j] == 'Q' && (x + j == y + i || x + y == i + j || x == i)) return false;
                }
            }

            return true;
        }

        private static List<string> Construct(char[,] board)
        {
            var result = new List<string>();

            for(int i = 0; i<boardLength; i++)
            {
                var value = board[i, 0];
                result.Add(value.ToString());
            }

            return result;
        }
    }
}
