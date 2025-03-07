namespace Matrix;

public class Matrix
{
    private readonly int[][] _grid;

    public Matrix(string input)
    {
        var rows = input.Split('\n');
        var maxCols = rows[0].Split(' ').Length;
        
        _grid = new int[rows.Length][];

        for (var row = 0; row < rows.Length; row++)
        {
            _grid[row] = new int[maxCols];
            
            var col = 0;
            foreach (var val in rows[row].Split(' '))
            {
                _grid[row][col++] = int.Parse(val);
            }
        }
    }

    public int[] Row(int row)
    {
        return _grid[row - 1];
    }

    public IEnumerable<int> Column(int col)
    {
        for (var row = 0; row < _grid.GetLength(0); row++)
            yield return _grid[row][col - 1];    
    }
}