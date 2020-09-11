using App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App
{
    public class LoanAppDbContext : DbContext
    {
        #region Members
        public DbSet<UserModel> Users { get; set; }
        #endregion

        #region Constructor
        public LoanAppDbContext(DbContextOptions<LoanAppDbContext> options) 
            : base(options)
        {
        }
        #endregion

        #region Protected Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().ToTable("Users");
        }
        #endregion
    }
}
