using ExamApp.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.DTOs.Exam
{
    public class UpdateExamVisiblity : BaseDto
    {
        public required bool IsVisible { get; set; }
    }
}
