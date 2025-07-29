using ExamApp.Application.Contracts.Identity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.DTOs.Exam.Validation
{
    internal class BaseExamValidator : AbstractValidator<IExamDto>
    {
        private readonly IUserRepository _userRepository;

        public BaseExamValidator()
        {
            RuleFor(e => e.Text)
                    .NotNull()
                    .MaximumLength(100).WithMessage("{PropertyName} must be less than {ComparisonValue}");

            RuleFor(e => e.Description)
                    .MaximumLength(500).WithMessage("{PropertyName} must be less than {ComparisonValue}");

            RuleFor(e => e.Duration)
                    .GreaterThan(TimeSpan.Zero).WithMessage("{PropertyName} must be greater than zero");

            RuleFor(e => e.IsVisible)
                    .NotNull();

            //RuleFor(e=>e.UserId)
            //    .MustAsync(async (userId, cancellationToken) =>
            //    {
            //        // Assuming you have a method to check if the user exists
            //        return await _userRepository.UserExistsAsync(userId);
            //    }).WithMessage("User with ID {PropertyValue} does not exist.");
        }
    }
}
