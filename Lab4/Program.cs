using System.Collections.Generic;
using System.Text;

public class CodeWars
{
    static CodeWars()
    {
        for (int pin = 0; pin <= 99999; pin++)
            cachedHashes.Add(CreateMD5(pin.ToString("00000")), pin);
    }

    private static readonly Dictionary<string, int> cachedHashes =
      new Dictionary<string, int>();

    public static string crack(string hash)
    {
        return cachedHashes.TryGetValue(hash, out var pin)
          ? pin.ToString("00000")
          : "";
    }

    public static string CreateMD5(string input)
    {
        using System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
        byte[] inputBytes = Encoding.ASCII.GetBytes(input);
        byte[] hashBytes = md5.ComputeHash(inputBytes);
        var result = new StringBuilder();
        for (int i = 0; i < hashBytes.Length; i++)
            result.Append(hashBytes[i].ToString("x2"));
        return result.ToString();
    }
}