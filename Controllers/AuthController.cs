using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using App.Managers;
using App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Members
        private readonly LoanAppDbContext _context;
        #endregion

        #region Constructor
        public AuthController(LoanAppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods
        [HttpPost("signin")]
        //POST: /auth/signin/
        public async Task<IActionResult> SignIn([Bind("Email,Password")] LoginRequestModel login)
        {
            //Find a user with a matching email as entered
            var foundUser = await _context.Users
                .FirstOrDefaultAsync(m => m.Email == login.Email);

            //If no user was found, exit with error
            if(foundUser == null)
            {
                return NotFound("User not found");
            }

            //Otherwise, check the DB hash against our user's entered password's hash
            SHA1 sha = SHA1.Create();
            string passAndSalt = login.Password + foundUser.Salt;
            byte[] passAndSaltBytes = Encoding.ASCII.GetBytes(passAndSalt);
            byte[] newHash = sha.ComputeHash(passAndSaltBytes);
            string newHashString = string.Concat(newHash.Select(b => b.ToString("X2")));
            bool authed = (foundUser.HashedPassword == newHashString);

            //If they failed to hash to the same value, return an error
            if (!authed)
            {
                return NotFound("Password entered is incorrect");
            }

            IAuthContainerModel model = new JWTContainerModel()
            {
                Claims = new Claim[]
                {
                    new Claim(ClaimTypes.Email, login.Email)
                },
            };

            //Generate a JWT token for further authentication
            IAuthService jwt = new JWTService(model.SecretKey);
            string jwtToken = jwt.GenerateToken(model);

            //Add it as a cookie to the response
            Response.Cookies.Append("t", jwt.GenerateToken(model));

            //Return our JWT access token and the authenticated user's information
            //  Make a temporary user to strip out private info out of the user model (like passwords)
            UserModel returnUser = new UserModel
            {
                _id = foundUser._id,
                Name = foundUser.Name,
                Email = foundUser.Email,
            };
            return Ok(new { JWTAccessToken = jwtToken, User = returnUser});
        }

        [HttpGet("signout")]
        public IActionResult SignOut()
        {
            Response.Cookies.Delete("t");
            return Ok("Sign out successful!");
        }
        #endregion
    }
}
