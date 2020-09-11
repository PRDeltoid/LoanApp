using App.Models;
using Microsoft.EntityFrameworkCore;

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
