using System;


namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Generator.GenerateQueenAgain();
        }
    }
    static class Generator
    {
        public static void GenerateBoard(int[,] board)
        {
            int N = 8;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public static void GenerateQueenAgain()
        {
            int[,] board = new int[8, 8];
            int N = 8;
            int j = 0;
            GenerateQueen(board, j);
        }

        public static bool GenerateQueen(int[,] board, int j)
        {
            if (j >= 8)
            {
                GenerateBoard(board);
                return true;
            }

            bool result = false;
            for (int i = 0; i < 8; i++)
            {
                if (IsSafe(board, i, j))
                {
                    board[i, j] = 1;

                    result = GenerateQueen(board, j + 1);

                    board[i, j] = 0; 
                }
            }

            return result;
        }
        public static bool IsSafe(int[,] board, int row, int col)
        {
            int i, j;

            for (i = 0; i < col; i++)
            {
                if (board[row, i] == 1)
                {
                    return false; 
                }
            }

            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == 1)
                {
                    return false;
                }
            }

            for (i = row, j = col; j >= 0 && i < 8; i++, j--)
            {
                if (board[i, j] == 1)
                {
                    return false;
                }
            }
            return true;
        }
    }

}
