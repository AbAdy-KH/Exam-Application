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
    public class AnswerConfiguration : IEntityTypeConfiguration<Domain.Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasData(
                new Answer()
                {
                    Id = 1,
                    ExamResultId = 1,
                    QuestionId = 1,
                    OptionId = 1,
                    CreatedBy = "1",
                },
                new Answer()
                {
                    Id = 2,
                    ExamResultId = 1,
                    QuestionId = 2,
                    OptionId = 4,
                    CreatedBy = "1",
                }
            );
        }
    }
}
