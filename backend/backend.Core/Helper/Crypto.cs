using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace backend.Core.Helper
{
    public class Crypto
    {
        public static readonly string Key = "MPSRenew";
        public static DESCryptoServiceProvider DesCsp = new DESCryptoServiceProvider();

        public static string DesEncrypt(string value)
        {
            var buffer = Encoding.UTF8.GetBytes(value);
            var ms = new MemoryStream();
            var encStream = new CryptoStream(ms, DesCsp.CreateEncryptor(Encoding.UTF8.GetBytes(Key), Encoding.UTF8.GetBytes(Key)), CryptoStreamMode.Write);
            encStream.Write(buffer, 0, buffer.Length);
            encStream.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray()).Replace("+", "%");
        }

        public static string DesDecrypt(string value)
        {
            value = value.Replace("%", "+");
            var buffer = Convert.FromBase64String(value);
            var ms = new MemoryStream();
            var decStream = new CryptoStream(ms,
                DesCsp.CreateDecryptor(Encoding.UTF8.GetBytes(Key), Encoding.UTF8.GetBytes(Key)),
                CryptoStreamMode.Read);
            decStream.Write(buffer, 0, buffer.Length);
            decStream.FlushFinalBlock();
            return Encoding.UTF8.GetString(ms.ToArray());
        }
    }
}
