using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace App.Helpers
{
    public class PasswordHelper
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
            string newHashString = string.Concat(newHash.Select(b => b.ToString("X2")));
            return newHashString;
        }
    }
}
