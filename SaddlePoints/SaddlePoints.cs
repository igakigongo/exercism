namespace SaddlePoints;

public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        if (matrix.Length == 0)
            return Enumerable.Empty<(int, int)>();

        Span<int> maxRows = stackalloc int[matrix.GetLength(0)];
        Span<int> minCols = stackalloc int[matrix.GetLength(1)];

        maxRows.Fill(int.MinValue);
        minCols.Fill(int.MaxValue);

        var saddlePoints = new List<(int, int)>();

        for (var row = 0; row < matrix.GetLength(0); row++)
        for (var col = 0; col < matrix.GetLength(1); col++)
        {
            if (matrix[row, col] >= maxRows[row]) maxRows[row] = matrix[row, col];
            if (matrix[row, col] <= minCols[col]) minCols[col] = matrix[row, col];
        }

        for (var row = 0; row < matrix.GetLength(0); row++)
        for (var col = 0; col < matrix.GetLength(1); col++)
        {
            var point = matrix[row, col];
            if (point <= minCols[col] && point >= maxRows[row])
                saddlePoints.Add((row + 1, col + 1));
        }

        return saddlePoints;
    }
}
