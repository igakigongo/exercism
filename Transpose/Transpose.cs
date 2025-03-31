namespace Transpose;

public static class Transpose
{
    public static string String(string input)
    {
        var wordsInput = input.Split('\n');
        var rows = wordsInput.Max(x => x.Length);
        var cols = wordsInput.Length;

        var array = new char[rows, cols];
        int col = 0, row = 0;
        foreach (var str in input.Split('\n'))
        {
            foreach (var ch in str)
                array[row++, col] = ch;

            col++;
            row = 0;
        }

        for (row = 0; row < rows; row++)
        for (col = cols - 1; col >= 0; col--)
        {
            if (array[row, col] == '\0') continue;
            for (; col >= 0; col--)
                if (array[row, col] == '\0')
                    array[row, col] = ' ';
        }

        List<string> words = [];
        for (row = 0; row < rows; row++)
        {
            var str = "";
            for (col = 0; col < cols; col++)
                if (array[row, col] != '\0')
                    str += array[row, col];

            words.Add(str);
        }

        return string.Join("\n", words);
    }
}