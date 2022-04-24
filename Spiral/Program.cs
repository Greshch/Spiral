using System;

namespace Spiral
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.Error.WriteLine("Lack of args.... ERROR#");
                return;
            }
     
            int size = Int32.Parse(args[0]);
            var matrix = InitArray(size, size);
            //PrintArray2D(matrix);
            FillArray2D(matrix);
            PrintArray2D(matrix);
            
        }

        public static int[][] InitArray(int rows, int cols)
        {
            int[][] matrix = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new int[cols];
            }

            return matrix;
        }

        public static void PrintArray2D(int[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                { 
                    Console.Write("{0}\t", matrix[row][col]);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        
        public static void FillArray2D(int[][] matrix)
        {
            int n = matrix.Length * matrix[0].Length;
            int row = matrix.Length / 2;
            int col = matrix[0].Length / 2;
            int dd = 1;
            int dx = 0;
            int dy = -dd;
            matrix[row][col] = 1;
            bool added = false;
            int cur = 1;
            bool finish = false;
            while (true)
            {
                for (int j = 0; j < dd; j++)
                {
                    if (cur == n)
                    {
                        finish = true;
                        break;
                    }
                    matrix[row + dy][col + dx] = ++cur;
                    row += dy;
                    col += dx;
                }

                if (finish)
                {
                    break;
                }

                if (dy < 0) // UP
                {
                    added = false;
                    dx = -1;
                    dy = 0;
                }
                else if (dx < 0) // LEFT
                {
                    if (!added)
                    {
                        dd++;
                        added = true;
                    }
                    dx = 0;
                    dy = 1;
                }
                else if (dy > 0) // DOWN
                {
                    added = false;
                    dx = 1;
                    dy = 0;
                }
                else // RIGHT
                {
                    if (!added)
                    {
                        dd++;
                        added = true;
                    }
                    dx = 0;
                    dy = -1;
                }
            }
        }
    }
}