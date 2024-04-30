
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace WebApplication5.Models
{
    public class BankContext : DbContext
    {
        public DbSet<BankBranch> BankBranches { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<UserAccounts> UserAccounts { get; set; }
        public BankContext(DbContextOptions<BankContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasIndex(r => r.civilId).IsUnique();
            modelBuilder.Entity<BankBranch>().Property(r => r.location).IsRequired();
        }
    }
}
