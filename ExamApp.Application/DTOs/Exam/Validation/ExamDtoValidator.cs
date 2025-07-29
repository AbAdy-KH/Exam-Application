using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.DTOs.Exam.Validation
{
    internal class ExamDtoValidator : AbstractValidator<ExamDto>
    {
        public ExamDtoValidator() 
        {
            RuleFor(e => e.Id)
                .NotNull();
            
            Include(new BaseExamValidator());
        }
    }
}
