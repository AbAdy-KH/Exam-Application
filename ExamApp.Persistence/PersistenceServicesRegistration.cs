using ExamApp.Application.Contracts.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ExamApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamApp.Persistence.Repository.Common;
using ExamApp.Persistence.Repository;
using ExamApp.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Http;

namespace ExamApp.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ExamAppDbContext>(
                options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("ExamAppConnectionString")
                )
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IOptionRepository, OptionRepository>();
            services.AddScoped<IExamResultRepository, ExamResultRepository>();
            return services;
        }
    }
}
