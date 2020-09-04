using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly LoanAppDbContext _context;

        public AuthController(LoanAppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //POST: /auth/signin/
        public async Task<IActionResult> SignIn([Bind("Email,HashedPassword")] User user)
        {
            SHA1 sha = SHA1.Create();
           
            var authed = await _context.Users
                .FirstOrDefaultAsync(m => m.HashedPassword == sha.ComputeHash(System.Text.Encoding.ASCII.GetBytes(user.HashedPassword + user.Salt)).ToString());
            if (authed == null)
            {
                return NotFound();
            }

            return Ok(authed);
        }
    }
}
