using ExamApp.Application.DTOs.Common;
using ExamApp.Application.DTOs.Question;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.DTOs.Exam
{
    public class ExamDto : BaseDto, IExamDto
    {
        public required string Text { get; set; }
        public string? Description { get; set; }
        public TimeSpan? Duration { get; set; }
        public required bool IsVisible { get; set; }
        //public required string UserId { get; set; }
        public List<QuestionDto>? Questions { get; set; }
    }
}
