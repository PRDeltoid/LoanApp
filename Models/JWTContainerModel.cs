using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace App.Models
{
    public class JWTContainerModel : IAuthContainerModel
    {
        #region Members
        public int ExpireMinutes { get; set;  } = 10880; //7 days
        //TODO: Move secret key to env variable
        public string SecretKey { get; set; } = "TW9zaGVFcmV6UHJpdmF0ZUtleQ==";
        public string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha256Signature;

        public Claim[] Claims { get; set; }
        #endregion
    }
}
