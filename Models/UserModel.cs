using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
    public class UserModel 
    {
        [Key]
        public Guid _id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string HashedPassword { get; set; }
        public string Password { set
            {
                //TODO: Generate this each time instead of using a hardcoded value
                this.Salt = "test12";

                SHA1 sha = SHA1.Create();
                string passAndSalt = value + this.Salt;
                byte[] passAndSaltBytes = Encoding.ASCII.GetBytes(passAndSalt);
                byte[] newHash = sha.ComputeHash(passAndSaltBytes);
                string newHashString = string.Concat(newHash.Select(b => b.ToString("X2")));
                this.HashedPassword = newHashString;
            } }
        public string Salt { get; set; }
    }
}
