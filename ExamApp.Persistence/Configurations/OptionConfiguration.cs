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
    public class OptionConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.HasData(
                new Option
                {
                    Id = 1,
                    QuestionId = 1,
                    Text = "Paris",
                    IsTrue = true,
                    CreatedBy = "1",
                },
                new Option
                {
                    Id = 2,
                    QuestionId = 1,
                    Text = "London",
                    IsTrue = false,
                    CreatedBy = "1"
                },
                new Option
                {
                    Id = 3,
                    QuestionId = 2,
                    Text = "4",
                    IsTrue = true,
                    CreatedBy = "1"
                },
                new Option
                {
                    Id = 4,
                    QuestionId = 2,
                    Text = "5",
                    IsTrue = false,
                    CreatedBy = "1"
                },
                new Option
                {
                    Id = 5,
                    QuestionId = 3,
                    Text = "Blue",
                    IsTrue = true,
                    CreatedBy = "1"
                },
                new Option
                {
                    Id = 6,
                    QuestionId = 3,
                    Text = "Red",
                    IsTrue = false,
                    CreatedBy = "1"
                },
                new Option
                {
                    Id = 7,
                    QuestionId = 4,
                    Text = "Einstein",
                    IsTrue = true,
                    CreatedBy = "1"
                },
                new Option
                {
                    Id = 8,
                    QuestionId = 4,
                    Text = "Newton",
                    IsTrue = false,
                    CreatedBy = "1"
                },
                new Option
                {
                    Id = 9,
                    QuestionId = 5,
                    Text = "H2O",
                    IsTrue = true,
                    CreatedBy = "1"
                },
                new Option
                {
                    Id = 10,
                    QuestionId = 5,
                    Text = "CO2",
                    IsTrue = false,
                    CreatedBy = "1"
                }
            );
        }
    }
}
