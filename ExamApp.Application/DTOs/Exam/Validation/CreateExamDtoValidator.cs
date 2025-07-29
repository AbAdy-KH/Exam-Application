using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.DTOs.Exam.Validation
{
    internal class CreateExamDtoValidator : AbstractValidator<CreateExamDto>
    {

        public CreateExamDtoValidator()
        {
            Include(new BaseExamValidator());
        }
    }
}
