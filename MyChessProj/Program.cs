using System;

class Program
{
    static void Main()
    {
        PrintMatrixDiaganal();
        Console.WriteLine();
        PrintMatrixAuxiliary();
        Console.WriteLine();
        Console.WriteLine(PrintRook(2, 4, 3, 7));
        Console.WriteLine();
        Console.WriteLine(PrintKnight(1, 2, 5, 8));
    }

    #region Diaganal
    static void PrintMatrixDiaganal()
    {
        int n = 5;
        char[,] matrix = new char[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == j)
                    matrix[i, j] = '#';
                else
                    matrix[i, j] = '*';
            }
        }


        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }

            Console.WriteLine();
        }
    }
    #endregion Diaganal

    #region Auxiliary


    static void PrintMatrixAuxiliary()
    {
        int n = 4;
        char[,] matrix = new char[n, n];


        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i + j == n - 1)
                    matrix[i, j] = '#';
                else
                    matrix[i, j] = '*';
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }

            Console.WriteLine();
        }
    }
    #endregion Auxiliary

    #region Rook
    static bool PrintRook(int x0, int y0, int x1, int y1)
    {
        if ((x0 == x1) || (y0 == y1))
            return true;

        else
            return false;

    }

    #endregion Rook

    #region Knight
    static bool PrintKnight(int x0, int x1, int y0, int y1)
    {
        if (Math.Abs(x0 - x1) * Math.Abs(y0 - y1) == 2)
            return true;
        else
            return false;


    }
    #endregion Knight

}
