using ExamApp.Application.DTOs.Common;
using ExamApp.Application.DTOs.Exam;
using ExamApp.Application.DTOs.Option;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.DTOs.Question
{
    public class QuestionDto : BaseDto, IQuestionDto
    {
        public required string Text { get; set; }
        public int ExamId { get; set; }
        //public ExamDto? Exam { get; set; }
        public double? Grade { get; set; }
        public List<OptionDto> Options { get; set; } = new List<OptionDto>();
    }
}
