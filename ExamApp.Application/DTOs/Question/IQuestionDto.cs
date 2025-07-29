using ExamApp.Application.DTOs.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.DTOs.Question
{
    public interface IQuestionDto
    {
        public string Text { get; set; }
        public int ExamId { get; set; }
        public double? Grade { get; set; }
    }
}
