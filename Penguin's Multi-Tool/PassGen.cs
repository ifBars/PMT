using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Penguin_s_Multi_Tool
{
    public class PassGen
    {

        public string generatePass(int length, bool useSpecialChars)
        {

            if (length > 100000)
            {

                return "Error: This tool is limited to 100,000 character passwords.";

            }

            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            const string specialChars = "!@#$%^&*().,";

            StringBuilder sb = new StringBuilder();

            string chars = validChars;
            if (useSpecialChars)
            {
                chars += specialChars;
            }

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    sb.Append(chars[(int)(num % (uint)chars.Length)]);
                }
            }

            GC.Collect();
            return sb.ToString();
        }

    }
}
