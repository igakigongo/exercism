using System.Numerics;

namespace GameOfLife;

public static class GameOfLife
{
    public static int[,] Tick(int[,] matrix)
    {
        var res = new int[matrix.GetLength(0), matrix.GetLength(1)];
        for (var row = 0; row < matrix.GetLength(0); row++)
        for (var col = 0; col < matrix.GetLength(1); col++)
            res[row, col] = ShouldLive(matrix, row, col) ? 1 : 0;

        return res;
    }

    private static bool ShouldLive(int[,] matrix, int row, int col)
    {
        var result = Check(matrix, row - 1, col - 1) << 7;
        result |= Check(matrix, row - 1, col) << 6;
        result |= Check(matrix, row - 1, col + 1) << 5;
        result |= Check(matrix, row, col - 1) << 4;
        result |= Check(matrix, row, col + 1) << 3;
        result |= Check(matrix, row + 1, col - 1) << 2;
        result |= Check(matrix, row + 1, col) << 1;
        result |= Check(matrix, row + 1, col + 1);

        var liveBits = BitOperations.PopCount(result);
        if (matrix[row, col] == 1 && liveBits is 2 or 3) return true;
        return matrix[row, col] == 0 && liveBits == 3;
    }

    private static uint Check(int[,] matrix, int row, int col) =>
        row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1)
            ? 0
            : (uint)matrix[row, col];
}