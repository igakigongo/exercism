namespace ParallelLetterFrequency;

public static class ParallelLetterFrequency
{
    public static Dictionary<char, int> Calculate(IEnumerable<string> texts)
    {
        var dict = new Dictionary<char, int>();
        var tasks = texts.Select(Count).ToArray();

        Task.WaitAll(tasks);
        foreach (var task in tasks)
        foreach (var (key, value) in task.Result)
        {
            if (dict.TryGetValue(key, out var count))
                dict[key] = count + value;
            else
                dict[key] = value;
        }

        return dict;
    }

    private static Task<Dictionary<char, int>> Count(string text)
    {
        var dict = new Dictionary<char, int>();
        for (var i = 0; i < text.Length; i++)
        {
            if (char.IsLetter(text[i]) == false) continue;
            var ch = char.ToLower(text[i]);
            dict[ch] = dict.TryGetValue(ch, out var count) ? count + 1 : 1;
        }

        return Task.FromResult(dict);
    }
}