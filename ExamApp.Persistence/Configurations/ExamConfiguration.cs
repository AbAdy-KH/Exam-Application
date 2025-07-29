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
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.HasData(
                new Exam()
                {
                    Id = 1,
                    Text = "Programming 1",
                    Description = "---",
                    IsVisible = true,
                    CreatedBy = "1"
                },
                new Exam()
                {
                    Id = 2,
                    Text = "Calculase",
                    Description = "---",
                    IsVisible = false,
                    CreatedBy = "1"
                }
            );
        }
    }
}
