using System.Text;

namespace SqueakyClean;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        var sb = new StringBuilder();

        for (var i = 0; i < identifier.Length; i++)
        {
            var ch = identifier[i];
            if (char.IsWhiteSpace(ch))
                sb.Append('_');
            else if (char.IsControl(ch))
                sb.Append("CTRL");
            else if (ch == '-')
                sb.Append(char.ToUpper(identifier[++i]));
            else if (char.IsLetter(ch) && ch is < 'α' or > 'ω')
                sb.Append(ch);
        }

        return sb.ToString();
    }
}
