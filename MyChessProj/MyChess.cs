using System;
using System.Reflection;

class MyChess
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
        Console.WriteLine();
        Console.WriteLine(CanBishopMove(3, 2, 4, 3  ));
        Console.WriteLine();
        Console.WriteLine(CanBishopMoveWithObstacles);
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
    static int GetKnightMinSteps(int x0, int y0, int x1, int y1)
    {
        int[] dx = { 2, 2, -2, -2, 1, 1, -1, -1 };
        int[] dy = { 1, -1, 1, -1, 2, -2, 2, -2 };

        Queue<(int x, int y, int dist)> queue = new Queue<(int, int, int)>();
        queue.Enqueue((x0, y0, 0));

        bool[,] visited = new bool[9, 9];
        visited[x0, y0] = true;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current.x == x1 && current.y == y1)
                return current.dist;

            for (int i = 0; i < 8; i++)
            {
                int nextX = current.x + dx[i];
                int nextY = current.y + dy[i];

                if (nextX >= 1 && nextX <= 8 &&
                    nextY >= 1 && nextY <= 8 &&
                    !visited[nextX, nextY])
                {
                    visited[nextX, nextY] = true;
                    queue.Enqueue((nextX, nextY, current.dist + 1));
                }
            }
        }

        return -1;
    }


    static bool CanBishopMove(int x0, int y0, int x1, int y1)
    {
        if (x0 == x1 && y0 == y1)
            return false;

        return Math.Abs(x0 - x1) ==  Math.Abs(y0 - y1);
    }
    static bool CanBishopMoveWithObstacles(int startRow, int startCol, int targetRow, int targetCol, int[,] board)
    {
        if (!CanBishopMove(startRow, startCol, targetRow, targetCol)) return false;
        int rowStep = (targetRow > startRow) ? 1 : -1;
        int colStep = (targetCol > startCol) ? 1 : -1;
        int currentRow = startRow + rowStep;
        int currentCol = startCol + colStep;

        while (currentRow != targetRow && currentCol != targetCol)
        {
            if (board[currentRow, currentCol] != 0) return false;
            currentRow += rowStep;
            currentCol += colStep;
        }
        return true;
    }
}



