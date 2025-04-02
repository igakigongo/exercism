namespace GameOfLife;

public static class GameOfLife
{
    public static int[,] Tick(int[,] matrix)
    {
        int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
        var res = new int[rows, cols];
        for (var row = 0; row < rows; row++)
        for (var col = 0; col < cols; col++)
        {
            var count = 0;
            for (var r = -1; r <= 1; r++)
            for (var c = -1; c <= 1; c++)
            {
                if (r == 0 && c == 0) continue;
                int rr = row + r, cc = col + c;
                count += rr >= 0 && rr < rows && cc >= 0 && cc < cols ? matrix[rr, cc] : 0;
            }
            
            res[row, col] = (matrix[row, col] == 1 && count is 2 or 3) || 
                            (matrix[row, col] == 0 && count == 3) ? 1 : 0;
        }

        return res;
    }
}