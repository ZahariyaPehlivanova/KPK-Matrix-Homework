using System;

namespace Task3
{
    class WalkInMatrica
    {
        static void Main()
        {
            Console.WriteLine( "Enter a positive number" );
            string input = Console.ReadLine();
            int n = 0;
            while ( !int.TryParse( input, out n ) || n < 0 || n > 100 )
            {
                Console.WriteLine( "You haven't entered a correct positive number" );
                input = Console.ReadLine();
            }
            int[,] matrica = new int[n, n];
            int k = 1;
            int rows = 0;
            int cols = 0;
            int rotatedX = 1;
            int rotatedY = 1;

            k = ChangeMatrix(matrica, rows, cols, k, rotatedX, n, rotatedY);

            FindCell(matrica, out rows, out cols);

            if (rows != 0 && cols != 0)
            {
                rotatedX = 1;
                rotatedY = 1;

                ChangeMatrix(matrica, rows, cols, k, rotatedX, n, rotatedY);
                Console.WriteLine(  );
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        Console.Write("{0,3}", matrica[row, col]);
                    }

                    Console.WriteLine();
                }
            }
        }

        private static int ChangeMatrix(int[,] matrica, int rows, int cols, int k, int rotatedX, int n, int rotatedY)
        {
            while (true)
            {
                matrica[rows, cols] = k;

                if (!ShouldMadeZero(matrica, rows, cols))
                {
                    break;
                }

                while (IsInMatrix(rows, rotatedX, n, cols, rotatedY, matrica))
                {
                    ChangeRotatedXAndY(ref rotatedX, ref rotatedY);
                }

                rows += rotatedX;
                cols += rotatedY;
                k++;
            }
            return k;
        }
        
        static void ChangeRotatedXAndY(ref int dx, ref int dy)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            int cd = 0;

            for (int count = 0; count < 8; count++)
            {
                if (dirX[count] == dx && dirY[count] == dy)
                {
                    cd = count;
                    break;
                }
            }

            if (cd == 7)
            {
                {
                    dx = dirX[0];
                    dy = dirY[0];

                    return;
                }
            }

            dx = dirX[cd + 1];
            dy = dirY[cd + 1];
        }

        public  static bool ShouldMadeZero(int[,] arr, int x, int y)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < 8; i++)
            {
                if (x + dirX[i] >= arr.GetLength(0) || x + dirX[i] < 0)
                {
                    dirX[i] = 0;
                }

                if (y + dirY[i] >= arr.GetLength(0) || y + dirY[i] < 0)
                {
                    dirY[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (arr[x + dirX[i], y + dirY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        static void FindCell(int[,] arr, out int x, out int y)
        {
            x = 0;
            y = 0;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        x = i;
                        y = j;

                        return;
                    }
                }
            }
        }
        
        private static bool IsInMatrix(int i, int dx, int n, int j, int dy, int[,] matrica)
        {
            return i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrica[i + dx, j + dy] != 0;
        }
    }
}
