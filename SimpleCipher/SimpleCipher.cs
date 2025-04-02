using System.Security.Cryptography;

namespace SimpleCipher;

public class SimpleCipher
{
    public SimpleCipher()
    {
        var chars = Enumerable.Range(97, 26).Select(x => (char)x).ToArray();
        Key = RandomNumberGenerator.GetString(chars, 10);
    }

    public SimpleCipher(string key) => Key = key;

    public string Key { get; }

    public string Encode(string plaintext) => Process(plaintext);

    public string Decode(string ciphertext) => Process(ciphertext, false);

    private string Process(string text, bool encode = true)
    {
        Span<char> arr = stackalloc char[text.Length];
        for (var i = 0; i < text.Length; i++)
        {
            var shift = (Key[i % Key.Length] - 'a') * (encode ? 1 : -1);
            var ch = text[i] + shift;
            if (encode && ch > 122) ch = ch - 123 + 97;
            if (!encode && ch < 97) ch = ch + 123 - 97;

            arr[i] = (char)ch;
        }

        return new string(arr);
    }
}