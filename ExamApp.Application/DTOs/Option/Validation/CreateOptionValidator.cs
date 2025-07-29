using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.DTOs.Option.Validation
{
    public class CreateOptionValidator : AbstractValidator<CreateOptionDto>
    {
        public CreateOptionValidator()
        {
            Include(new BaseOptionValidator());
        }
    }
}
