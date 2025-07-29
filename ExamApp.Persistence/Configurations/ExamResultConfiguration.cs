using ExamApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Persistence.Configurations
{
    public class ExamResultConfiguration : IEntityTypeConfiguration<ExamResult>
    {
        public void Configure(EntityTypeBuilder<ExamResult> builder)
        {
            builder.HasData(
                new ExamResult()
                {
                    Id = 1,
                    ExamId = 1,
                    CreatedBy = "1",
                    Mark = 85,
                },
                new ExamResult()
                {
                    Id = 2,
                    ExamId = 2,
                    CreatedBy = "1",
                    Mark = 90
                }
            );
        }
    }
}
