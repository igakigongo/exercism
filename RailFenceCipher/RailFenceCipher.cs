using System.Text;

namespace RailFenceCipher;

public class RailFenceCipher(int rails)
{
    public string Encode(string input)
    {
        var arr = new (int d1, int d2)[rails];
        int i = 0, d = (rails - 1) * 2, d1 = d, d2 = d;
        while (d1 > 0)
        {
            arr[i++] = (d1, d2);
            d1 -= 2;
            d2 = d - d1;
        }

        arr[i] = (d, d);

        var sb = new StringBuilder();
        for (i = 0; i < rails; i++)
        {
            (d1, d2) = arr[i];
            int j = i, k = j + d1;
            while (j < input.Length)
            {
                sb.Append(input[j]);
                if (k < input.Length) sb.Append(input[k]);

                (j, k) = (k + d2, k + d2 + d1);
            }
        }

        return sb.ToString();
    }

    public string Decode(string input)
    {
        var pattern = new List<int>(input.Length);
        var rail = 0;
        var dir = 1;

        for (var i = 0; i < input.Length; i++)
        {
            pattern.Add(rail);
            rail += dir;

            if (rail == rails - 1 || rail == 0)
                dir *= -1;
        }

        var railCounts = new int[rails];
        foreach (var r in pattern)
            railCounts[r]++;

        var railChunks = new string[rails];
        var pos = 0;
        for (var i = 0; i < rails; i++)
        {
            railChunks[i] = input.Substring(pos, railCounts[i]);
            pos += railCounts[i];
        }
        
        var railIndices = new int[rails];
        var decoded = new StringBuilder();

        foreach (var r in pattern)
        {
            decoded.Append(railChunks[r][railIndices[r]]);
            railIndices[r]++;
        }

        return decoded.ToString();
    }
}