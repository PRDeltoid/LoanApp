using App.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace App.Managers
{
    public interface IAuthService
    {
        /// <summary>
        /// The secret key used to generate the authorization token
        /// </summary>
        string SecretKey { get; set; }

        /// <summary>
        /// Checks if a given token is valid
        /// </summary>
        /// <param name="token">The token to check</param>
        /// <returns>True if the token is valid, false otherwise</returns>
        bool IsTokenValid(string token);

        /// <summary>
        /// Generates a token using a given token generation model
        /// </summary>
        /// <param name="model">The token generation model to use</param>
        /// <returns>The generated authorization token</returns>
        string GenerateToken(IAuthContainerModel model);

        /// <summary>
        /// Returns all claims for a given authorization token
        /// </summary>
        /// <param name="token">The token to get claims for</param>
        /// <returns>A list of <c>Claim</c>s the token is associated with</returns>
        IEnumerable<Claim> GetTokenClaims(string token);
    }
}
