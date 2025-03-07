namespace WordSearch;

public class WordSearch
{
    private readonly char[,] _grid;
    private readonly int _rows, _cols;

    public WordSearch(string grid)
    {
        var words = grid.Split('\n');
        _rows = words.Length;
        _cols = words[0].Length;

        _grid = new char[_rows, _cols];
        for (var i = 0; i < _rows; i++)
        for (var j = 0; j < _cols; j++)
            _grid[i, j] = words[i][j];
    }

    public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor)
    {
        var dict = new Dictionary<string, ((int, int), (int, int))?>();
        foreach (var word in wordsToSearchFor)
        {
            for (var row = 0; row < _rows; row++)
            for (var col = 0; col < _cols; col++)
            {
                foreach (var dir in Enum.GetValues<Direction>())
                {
                    var end = Search(word.AsSpan(), dir, row, col);
                    if (end == null) continue;

                    dict[word] = ((col + 1, row + 1), (end.Value.col + 1, end.Value.row + 1));
                    break;
                }
            }

            dict.TryAdd(word, null);
        }

        return dict;
    }

    private (int row, int col)? Search(ReadOnlySpan<char> word, Direction dir, int row, int col)
    {
        if (row < 0 || row >= _rows ||
            col < 0 || col >= _cols ||
            word.Length == 0 || word[0] != _grid[row, col]) return null;

        if (word.Length == 1 && _grid[row, col] == word[0]) return (row, col);

        return dir switch
        {
            Direction.LeftToRight => Search(word[1..], dir, row, col + 1),
            Direction.RightToLeft => Search(word[1..], dir, row, col - 1),
            Direction.TopToBottom => Search(word[1..], dir, row + 1, col),
            Direction.BottomToTop => Search(word[1..], dir, row - 1, col),
            Direction.BottomLeftToTopRight => Search(word[1..], dir, row - 1, col + 1),
            Direction.BottomLeftToTopLeft => Search(word[1..], dir, row - 1, col - 1),
            Direction.TopLeftToBottomRight => Search(word[1..], dir, row + 1, col + 1),
            Direction.TopLeftToBottomLeft => Search(word[1..], dir, row + 1, col - 1),
            _ => null
        };
    }
}

public enum Direction
{
    LeftToRight,
    RightToLeft,
    TopToBottom,
    BottomToTop,
    BottomLeftToTopRight,
    BottomLeftToTopLeft,
    TopLeftToBottomRight,
    TopLeftToBottomLeft
}