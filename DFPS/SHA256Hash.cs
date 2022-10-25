using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Linq;

namespace DFPS
{
    public static class SHA256Hash
    {
        public static string generateHash(byte[] input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                var hash = sha256.ComputeHash(input);
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public static byte[] Hash(string pass, byte[] salt)
        {
            return Hash(Encoding.UTF8.GetBytes(pass), salt);
        }

        public static byte[] Hash(byte[] pass, byte[] salt)
        {
            byte[] saltedValue = pass.Concat(salt).ToArray();
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(saltedValue);
            }
        }

        public static bool compareHash(string value, byte[] retrievedSalt, byte[] retrievedHash)
        {
            byte[] passwordHash = Hash(value, retrievedSalt);
            return retrievedHash.SequenceEqual(passwordHash);
        }
    }
}
