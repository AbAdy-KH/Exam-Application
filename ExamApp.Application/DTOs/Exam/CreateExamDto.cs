using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.DTOs.Exam
{
    public class CreateExamDto : IExamDto
    {
        public required string Text { get; set; }
        public string? Description { get; set; }
        public TimeSpan? Duration { get; set; }
        public required bool IsVisible { get; set; }
        //public required string UserId { get; set; }
    }
}
