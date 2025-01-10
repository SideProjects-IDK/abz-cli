using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;

namespace abz_cli.sex // [SEcurity eXtension]
{
    public class hashes
    {
        public static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                var builder = new StringBuilder();
                foreach (var t in bytes) builder.Append(t.ToString("x2"));
                return builder.ToString();
            }
        }
        public static string ComputeSha1Hash(string rawData)
        {
            using (SHA1 sha1Hash = SHA1.Create())
            {
                byte[] bytes = sha1Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                var builder = new StringBuilder();
                foreach (var t in bytes) builder.Append(t.ToString("x2"));
                return builder.ToString();
            }
        }
        public static string ComputeSha384Hash(string rawData)
        {
            using (SHA384 sha384Hash = SHA384.Create())
            {
                byte[] bytes = sha384Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                var builder = new StringBuilder();
                foreach (var t in bytes) builder.Append(t.ToString("x2"));
                return builder.ToString();
            }
        }

        public class Base64
        {
            public static string EncryptData(string plainText, string password)
            {
                byte[] data = Encoding.UTF8.GetBytes(plainText);
                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(password.PadRight(32));
                    aes.IV = new byte[16];
                    using var ms = new MemoryStream();
                    using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(data, 0, data.Length);
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }

            public static string DecryptData(string cipherText, string password)
            {
                byte[] data = Convert.FromBase64String(cipherText);
                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(password.PadRight(32));
                    aes.IV = new byte[16];
                    using var ms = new MemoryStream();
                    using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(data, 0, data.Length);
                    }
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }
    }
}
