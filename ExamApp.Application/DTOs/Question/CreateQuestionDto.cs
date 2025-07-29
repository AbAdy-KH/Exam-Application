using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.DTOs.Question
{
    public class CreateQuestionDto : IQuestionDto
    {
        public required string Text { get; set; }
        public int ExamId { get; set; }
        public double? Grade { get; set; }
    }
}
