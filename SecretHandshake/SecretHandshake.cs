namespace SecretHandshake;

public static class SecretHandshake
{
    private static readonly Dictionary<int, string> Dict = new()
    {
        { 1, "wink" },
        { 2, "double blink" },
        { 4, "close your eyes" },
        { 8, "jump" }
    };
    
    public static string[] Commands(int commandValue)
    {
        var commands = new List<string>();
        foreach (var (key, value) in Dict) 
            if ((commandValue & key) != 0)
                commands.Add(value);
        
        if ((commandValue & 16) == 16)
            commands.Reverse();

        return commands.ToArray();
    }
}