using System.Security.Cryptography;
using System.Text;

namespace ProTips.Entity.Utils;

public static class Encrypter
{
    public static string Encrypt(string value)
    {
        byte[] data = Encoding.ASCII.GetBytes(value);
        data = new SHA256Managed().ComputeHash(data);
        return Encoding.ASCII.GetString(data);
    }
}