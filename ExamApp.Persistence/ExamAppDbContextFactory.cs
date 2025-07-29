using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace ExamApp.Persistence
{
    public class ExamAppDbContextFactory : IDesignTimeDbContextFactory<ExamAppDbContext>
    {
        public ExamAppDbContext CreateDbContext(string[] args)
        {
            // هذا مهم: المسار يكون جذر مشروع الـ API غالبًا
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("\"C:\\Users\\Abd-Alrhman\\source\\repos\\ExamApp-CleanArchitecture\\ExamApp.Api\\appsettings.json\"")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ExamAppDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ExamAppConnectionString"));

            return new ExamAppDbContext(optionsBuilder.Options);
        }
    }
}
