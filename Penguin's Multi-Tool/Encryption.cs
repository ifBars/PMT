using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Penguin_s_Multi_Tool
{
    public class Encryption
    {

        private readonly Aes aes;

        public Encryption()
        {
            aes = Aes.Create();
            aes.Padding = PaddingMode.PKCS7;
        }

        public static byte[] Encrypt(byte[] plainText, byte[] key, byte[] iv)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(plainText, 0, plainText.Length);
                        csEncrypt.FlushFinalBlock();
                        return msEncrypt.ToArray();
                    }
                }
            }
        }

        public static byte[] Decrypt(byte[] cipherText, byte[] key, byte[] iv)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            csDecrypt.CopyTo(ms);
                            return ms.ToArray();
                        }
                    }
                }
            }
        }

    }
}
