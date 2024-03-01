namespace LogAnalysis;

public static class LogAnalysis
{
    private static int GetStartIndex(this string logLine, string begin)
        => logLine.IndexOf(begin, StringComparison.OrdinalIgnoreCase)
           + begin.Length;

    public static string SubstringAfter(this string logLine, string fragment)
    {
        var beginIndex = logLine.GetStartIndex(fragment);
        return logLine[beginIndex..];
    }

    public static string SubstringBetween(this string logLine, string begin, string end)
    {
        var beginIndex = logLine.GetStartIndex(begin);
        var endIndex = logLine.IndexOf(end, StringComparison.OrdinalIgnoreCase);

        return logLine[beginIndex..endIndex];
    }

    public static string Message(this string logLine) =>
        logLine.SubstringAfter(":").Trim();

    public static string LogLevel(this string logLine) =>
        logLine.SubstringBetween("[", "]");
}
