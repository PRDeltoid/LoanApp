using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App;
using App.Models;
using System.Linq.Expressions;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly LoanAppDbContext _context;

        public UsersController(LoanAppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        // GET: api/users/
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpGet("{id}")]
        // GET: api/users/{id}
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Email == id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/users/
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Email,Password")] UserModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                } catch
                {
                    return BadRequest("There was an error creating the user");
                }
                return RedirectToAction(nameof(Index));
            }
            return Ok(user);
        }

        // POST: api/users/edit/{id}
        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Email,Name,HashedPassword,Salt")] UserModel user)
        {
            if (id != user._id.ToString())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Email))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return Ok(user);
        }

        // POST: Users/Delete/{id}
        [HttpPost("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.Email == id);
        }
    }
}
