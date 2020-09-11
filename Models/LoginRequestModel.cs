using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class LoginRequestModel
    {
        #region Members
        public string Email { get; set; }
        public string Password { get; set; }
        #endregion
    }
}
