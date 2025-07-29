using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using ExamApp.Identity.Models;
using ExamApp.Identity.Configurations;

namespace ExamApp.Identity
{
    public class ExamAppIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ExamAppIdentityDbContext(DbContextOptions<ExamAppIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
