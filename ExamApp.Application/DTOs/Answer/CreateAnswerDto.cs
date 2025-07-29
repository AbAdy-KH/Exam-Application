using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.DTOs.Answer
{
    public class CreateAnswerDto
    {
        public required int QuestionId { get; set; }
        public required int OptionId { get; set; }
    }
}
