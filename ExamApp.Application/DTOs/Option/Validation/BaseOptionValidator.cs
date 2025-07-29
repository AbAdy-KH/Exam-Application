using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.DTOs.Option.Validation
{
    public class BaseOptionValidator : AbstractValidator<IOptionDto>
    {
        public BaseOptionValidator()
        {
            RuleFor(o => o.Text)
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be less than {ComparisonValue}");
            RuleFor(o => o.IsTrue)
                .NotNull();
            RuleFor(o => o.QuestionId)
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero");
        }
    }
}
