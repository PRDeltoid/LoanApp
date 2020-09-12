using App.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace App.Models
{
    public class UserModel 
    {
        private string salt;
        private string password;

        #region Members
        [Key]
        public Guid _id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string HashedPassword { get; set; }

        /// <summary>
        /// A virtual column (does not exist in the DB) which hashes the password using the user's salt and sets the HashedPassword property
        /// If the user has no salt, it will generate it first
        /// </summary>
        [NotMapped]
        public string Password {
            get
            {
                return this.password;

                }
            set
            {
                password = value;
                this.HashedPassword = UserHelper.GeneratePasswordHash(value, this.Salt);
            }
        }

        public string Salt {
            get 
            { 
                // Generate a salt if one does not exist
                if (salt == null) {
                    salt = UserHelper.GenerateSalt();
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
