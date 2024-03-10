namespace MatchingBrackets;

public static class MatchingBrackets
{
    public static bool IsPaired(string input)
    {
        var stack = new Stack<char>();
        foreach (var ch in input)
            switch (ch)
            {
                case '{': stack.Push('}'); break;
                case '[': stack.Push(']'); break;
                case '(': stack.Push(')'); break;
                case '}' or ']' or ')':
                    if (stack.Count == 0 || stack.Pop() != ch) return false;
                    break;
            }

        return stack.Count == 0;
    }
}
