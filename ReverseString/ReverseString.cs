namespace ReverseString;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        var arr = input.ToCharArray();
        for (int i = 0, j = input.Length - 1; i <= j; i++, j--)
        {
            (arr[i], arr[j]) = (arr[j], arr[i]);
        }

        return new string(arr);
    }
}
