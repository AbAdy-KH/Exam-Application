using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.DTOs.Exam
{
    internal interface IExamDto
    {
        public  string Text { get; set; }
        public string? Description { get; set; }
        public TimeSpan? Duration { get; set; }
        public  bool IsVisible { get; set; }
        //public string UserId { get; set; }
    }
}
