using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class LoginResultModel
    {
        public string JWTAccessToken { get; set; }
        public UserModel User { get; set; }
    }
}
