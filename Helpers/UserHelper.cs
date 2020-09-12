using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace App.Helpers
{
    public class UserHelper
    {
        /// <summary>
        /// Generates a SHA1 hash given a password and salt value
        /// </summary>
        /// <param name="pass">the password to hash</param>
        /// <param name="salt">the salt to use for the password</param>
        /// <returns>A string representing the SHA1 of the hash in bytes</returns>
        public static string GeneratePasswordHash(string pass, string salt="")
        { 
            SHA1 sha = SHA1.Create();
            string passAndSalt = pass + salt;
            byte[] passAndSaltBytes = Encoding.ASCII.GetBytes(passAndSalt);
            byte[] newHash = sha.ComputeHash(passAndSaltBytes);
            //Digest the bytes as a hex string (a string of hexcidecimals)
            string newHashString = string.Concat(newHash.Select(b => b.ToString("X2")));
            return newHashString;
        }

        public static string GenerateSalt()
        {
            //Our salt should be 6 characters long
            const int maxLength = 6;
            var random = new RNGCryptoServiceProvider();

            // Empty salt array
            byte[] salt = new byte[maxLength];

            // Build the random bytes
            random.GetNonZeroBytes(salt);

            // Return the string encoded salt
            return Convert.ToBase64String(salt).Substring(0, maxLength);
        }
    }
}
