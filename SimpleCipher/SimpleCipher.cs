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
            ch = encode switch
            {
                true when ch > 122 => ch - 123 + 97,
                false when ch < 97 => ch + 123 - 97,
                _ => ch
            };

            arr[i] = (char)ch;
        }

        return new string(arr);
    }
}