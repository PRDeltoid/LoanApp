using App.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class UserModel 
    {
        private string salt;
        #region Members
        [Key]
        public Guid _id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string HashedPassword { get; set; }

        /// <summary>
        /// A virtual column (does not exist in the DB) which hashes the password using the user's salt and sets the value
        /// If the user has no salt, this will generate it first
        /// </summary>
        public string Password { 
            set
            {
                this.HashedPassword = PasswordHelper.GeneratePasswordHash(value, this.Salt);
            } 
        }

        public string Salt {
            get 
            { 
                // Generate a salt if one does not exist
                if (salt == null) { 
                    //TODO: Generate this salt per user
                    salt = "test12"; 
                } 
                return salt; 
            } 
            set 
            { 
                this.salt = value; 
            }
        }
        #endregion
    }
}
