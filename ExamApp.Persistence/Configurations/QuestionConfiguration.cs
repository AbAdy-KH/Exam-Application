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
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasData(
                new Question
                {
                    Id = 1,
                    Text = "What is the capital of France?",
                    CreatedBy = "1",
                    ExamId = 1,
                    Grade = 1.0
                },
                new Question
                {
                    Id = 2,
                    Text = "What is the largest planet in our solar system?",
                    CreatedBy = "1",
                    ExamId = 1,
                    Grade = 1.0
                },
                new Question
                {
                    Id = 3,
                    Text = "What is the derivative of x^2?",
                    CreatedBy = "1",
                    ExamId = 2,
                    Grade = 1.0
                },
                new Question
                {
                    Id = 4,
                    Text = "What is the integral of 1/x?",
                    CreatedBy = "1",
                    ExamId = 2,
                    Grade = 1.0
                },
                new Question
                {
                    Id = 5,
                    Text = "What is the capital of Germany?",
                    CreatedBy = "1",
                    ExamId = 1,
                    Grade = 1.0
                }
            );
        }
    }
}
