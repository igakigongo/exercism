namespace LogLevels;

public static class LogLine
{
    public static string Message(string logLine)
    {
        var span = logLine.AsSpan();
        var index = span.IndexOf(':');

        var message = span[(index + 1)..];
        return message.ToString().Trim();
    }

    public static string LogLevel(string logLine)
    {
        var firstChar = logLine[1];
        return firstChar switch
        {
            'E' => "error",
            'I' => "info",
            'W' => "warning",
            _ => string.Empty
        };
    }

    public static string Reformat(string logLine) => $"{Message(logLine)} ({LogLevel(logLine)})";
}
