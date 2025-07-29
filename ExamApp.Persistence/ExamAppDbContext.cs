using ExamApp.Application.Constants;
using ExamApp.Domain;
using ExamApp.Domain.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Persistence
{
    public class ExamAppDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExamAppDbContext(DbContextOptions<ExamAppDbContext> options,
            IHttpContextAccessor? httpContextAccessor = null) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExamAppDbContext).Assembly);
        }

        public virtual async Task<int> SaveChangesAsync(string username = "SYSTEM")
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.UpdateDate = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreateDate = DateTime.Now;
                    //entry.Entity.CreatedBy = _httpContextAccessor?.HttpContext?.User?.FindFirst(CustomClaimTypes.Uid)?.Value;
                    entry.Entity.CreatedBy = "1";
                }
            }

            var result = await base.SaveChangesAsync();

            return result;
        }

        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}
